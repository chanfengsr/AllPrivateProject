/*
***** 参数表表结构 *****
    CREATE TYPE [dbo].[CodeParmTable] AS TABLE(
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
    GO
        
    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
        
    MarkType    CHAR(2) NOT NULL,               -- 市场类型（沪市sh、深市sz）
    StkType     CHAR(1) DEFAULT('1') NOT NULL,  -- 0 指数，1 股票
*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStockRatio]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStockRatio]
GO

-- *************** 功能描述: 返回个股某日涨幅 ***************
CREATE FUNCTION [dbo].[GetStockRatio](@StkCode CHAR(6), @TradeDay SMALLDATETIME, @StkType CHAR(1) = 1)
RETURNS MONEY
AS 
BEGIN
DECLARE @ret MONEY

    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)

    -- 是否日线是指数
    IF @StkType = 1
        SELECT @ret = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 
        FROM KLineDay curP
        JOIN
        (
            SELECT a.StkCode, a.[Close] FROM KLineDay a
            JOIN (SELECT RecId = MAX(b0.RecId) FROM KLineDay b0
                  WHERE b0.TradeDay < @TradeDay
                    AND b0.StkCode = @StkCode
                  GROUP BY b0.MarkType, b0.StkCode
            ) b
            ON a.RecId = b.RecId
        ) prepP
        ON curP.StkCode = prepP.StkCode
        WHERE   curP.StkCode = @StkCode
            AND curP.TradeDay = @TradeDay
    ELSE
        SELECT @ret = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 
        FROM KLineDayZS curP
        JOIN
        (
            SELECT a.StkCode, a.[Close] FROM KLineDayZS a
            JOIN (SELECT RecId = MAX(b0.RecId) FROM KLineDayZS b0
                  WHERE b0.TradeDay < @TradeDay
                    AND b0.StkCode = @StkCode
                  GROUP BY b0.MarkType, b0.StkCode
            ) b
            ON a.RecId = b.RecId
        ) prepP
        ON curP.StkCode = prepP.StkCode
        WHERE   curP.StkCode = @StkCode
            AND curP.TradeDay = @TradeDay

    /*
    IF (@ret IS NULL) 
        SET @ret = 0
    */

    RETURN @ret
END

GO
--SELECT dbo.GetStockRatio('600056', '2017/09/21', '1')



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllStockCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAllStockCodeList]
GO

-- *************** 功能描述: 返回A股票代码列表 ***************
CREATE FUNCTION [dbo].[GetAllStockCodeList]()
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    BEGIN
    INSERT INTO @retTable
    SELECT MarkType, StkCode FROM StockHead
    WHERE StkType = 1
    AND   ( (MarkType = 'sh' AND StkCode LIKE '60%') OR
            (MarkType = 'sz' AND (StkCode LIKE '00%' OR StkCode LIKE '30%'))
          )
        
    END
    
    RETURN
END
GO
-- SELECT * FROM dbo.GetAllStockCodeList()





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetZTCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetZTCodeList]
GO

-- *************** 功能描述: 返回某日涨停板列表 ***************
CREATE FUNCTION [dbo].[GetZTCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- 没填日期则默认是最后一个交易日
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')
    
    -- 正式填充返回集
    INSERT INTO @retTable
    SELECT curP.MarkType, curP.StkCode
    FROM KLineDay curP
    JOIN
    (
        SELECT a.StkCode, a.[Close] FROM KLineDay a
        JOIN (SELECT RecId = MAX(b0.RecId) FROM KLineDay b0
              WHERE b0.TradeDay < @TradeDay
                AND EXISTS (SELECT 1 FROM @RangeList WHERE MarkType = b0.MarkType AND StkCode = b0.StkCode) -- 大幅提高已有列表速度
              GROUP BY b0.MarkType, b0.StkCode
        ) b
        ON a.RecId = b.RecId
    ) prepP
    ON curP.StkCode = prepP.StkCode
    JOIN @RangeList rangLst
    ON   rangLst.MarkType = curP.MarkType AND rangLst.StkCode = curP.StkCode
    WHERE   curP.TradeDay = @TradeDay
        AND prepP.[Close] > 0
        AND ((curP.[Close] - prepP.[Close]) / prepP.[Close] * 100) >= 9.9
        AND EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = curP.MarkType AND StkCode = curP.StkCode AND TradeDay = @TradeDay AND [High] = [Close]) -- 涨停肯定是收盘为最高价
    
    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM dbo.GetAllStockCodeList()
SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)
*/





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetYZZTCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetYZZTCodeList]
GO

-- *************** 功能描述: 返回某日一字涨停板列表 ***************
CREATE FUNCTION [dbo].[GetYZZTCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- 没填日期则默认是最后一个交易日
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')

    -- 先计算出涨停列表（如果传进来的就是涨停列表，反正也花不了多少时间）
    DECLARE @ZTList AS [CodeParmTable]
    INSERT INTO @ZTList
    SELECT * FROM dbo.GetZTCodeList(@TradeDay, @RangeList)
    
    -- 一字涨停：涨停、开盘 = 收盘 = 最高 = 最低
    INSERT INTO @retTable
    SELECT * FROM @ZTList zt
    WHERE EXISTS (SELECT 1 FROM KLineDay 
                  WHERE MarkType = zt.MarkType AND StkCode = zt.StkCode AND TradeDay = @TradeDay
                    AND [Open] = [Close]
                    AND [Open] = [High]
                    AND [Open] = [Low])

    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM dbo.GetAllStockCodeList()
-- 此处先获得涨停列表，再用此列表做计算，也可直接用所有 A股列表
DECLARE @ZTList AS [CodeParmTable]
INSERT INTO @ZTList SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)

SELECT * FROM dbo.GetYZZTCodeList('2017/09/21', @ZTList)
*/





DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM dbo.GetAllStockCodeList()

SELECT * FROM dbo.GetYZZTCodeList('2017/09/21', @RangeList)