/*
***** 参数表表结构 *****
CREATE TYPE dbo.CodeParmTable AS TABLE(
    [MarkType] [char](2) NOT NULL,
    [StkCode] [char](6) NOT NULL
)
GO
    
-- 去掉时间
IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
    SET @TradeDay = CAST(@TradeDay AS DATE)
    
MarkType    CHAR(2) NOT NULL,               -- 市场类型（沪市sh、深市sz）
StkType     CHAR(1) DEFAULT('1') NOT NULL,  -- 0 指数，1 股票

-- A股 代码列表，剔除 ST
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST

*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetStockRatio') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetStockRatio
GO

-- *************** 功能描述: 返回个股某日涨幅 ***************
CREATE FUNCTION dbo.GetStockRatio(@StkCode CHAR(6), @TradeDay SMALLDATETIME = '1900/01/01', @StkType CHAR(1) = '1')
RETURNS MONEY
AS 
BEGIN
DECLARE @ret MONEY

    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- 没填日期则默认是最后一个交易日
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')

    -- 是否日线是指数
    IF @StkType = '1'
        /*
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
        */
        SELECT @ret = (cur.[Close] - prev.[Close]) / prev.[Close] * 100
        FROM cv_NeighbourKLineDayRecId cur
        JOIN KLineDay prev ON cur.prevRecId = prev.RecId
        WHERE   cur.StkCode = @StkCode
            AND cur.TradeDay = @TradeDay
    ELSE
        /*
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
        */
        SELECT @ret = (cur.[Close] - prev.[Close]) / prev.[Close] * 100
        FROM cv_NeighbourKLineDayRecId cur
        JOIN KLineDay prev ON cur.prevRecId = prev.RecId
        WHERE   cur.StkCode = @StkCode
            AND cur.TradeDay = @TradeDay

    /*
    IF (@ret IS NULL) 
        SET @ret = 0
    */

    RETURN @ret
END

GO
--SELECT dbo.GetStockRatio('600056', '2017/09/21', '1')



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetAllAStockCodeListExcST') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetAllAStockCodeListExcST
GO

-- *************** 功能描述: 返回A股票代码列表 ***************
CREATE FUNCTION dbo.GetAllAStockCodeListExcST()
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN

    INSERT INTO @retTable
    SELECT MarkType, StkCode FROM cv_AStockCodeExcST
    
    RETURN
END
GO
-- SELECT * FROM dbo.GetAllAStockCodeListExcST()





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetZTCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetZTCodeList
GO

-- *************** 功能描述: 返回某日涨停板列表 ***************
CREATE FUNCTION dbo.GetZTCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)
*/





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetYZZTCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetYZZTCodeList
GO

-- *************** 功能描述: 返回某日一字涨停板列表 ***************
CREATE FUNCTION dbo.GetYZZTCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST

-- 此处先获得涨停列表，再用此列表做计算，也可直接用所有 A股列表
DECLARE @ZTList AS [CodeParmTable]
INSERT INTO @ZTList SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)

SELECT * FROM dbo.GetYZZTCodeList('2017/09/21', @ZTList)
*/







IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetNewNotBrokenCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetNewNotBrokenCodeList
GO

-- *************** 功能描述: 返回新股，未开板 列表 ***************
CREATE FUNCTION dbo.GetNewNotBrokenCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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

    -- 当天上市的
    INSERT INTO @retTable
    SELECT DISTINCT a.MarkType, a.StkCode FROM KLineDay a
    WHERE   a.TradeDay = @TradeDay
        AND EXISTS (SELECT 1 FROM @RangeList WHERE MarkType = a.MarkType AND StkCode = a.StkCode)
        AND NOT EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = a.MarkType AND StkCode = a.StkCode AND TradeDay < @TradeDay)

    -- 先得到一字涨停列表
    DECLARE @YZZTList AS [CodeParmTable]
    INSERT INTO @YZZTList
    SELECT * FROM dbo.GetYZZTCodeList(@TradeDay, @RangeList) yi
    WHERE NOT EXISTS (SELECT 1 FROM @retTable ret WHERE yi.MarkType = ret.MarkType AND yi.StkCode = ret.StkCode)

    -- 循环往前查找
    DECLARE @MarkType [char](2)
    DECLARE @StkCode  [char](6)
    DECLARE @minDate  SMALLDATETIME
    DECLARE curYZZT CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT MarkType, StkCode FROM @YZZTList
    OPEN curYZZT
        WHILE 1 = 1
            BEGIN
                FETCH curYZZT INTO @MarkType, @StkCode
                IF @@FETCH_STATUS <> 0
                    BREAK

                -- 直接查找当日之前是否有 开收盘，最高、最低 不一致的，如果有，则表示已经开过板了。

                -- 得到上市首日，因为上市首日可能开收盘价不一致（肯定找得到的）
                SELECT @minDate = MIN(TradeDay) FROM KLineDay WHERE MarkType = @MarkType AND StkCode = @StkCode AND TradeDay < @TradeDay

                IF NOT EXISTS(SELECT 1 FROM KLineDay 
                              WHERE MarkType = @MarkType AND StkCode = @StkCode AND TradeDay < @TradeDay AND TradeDay > @minDate
                                AND NOT ([Open] = [High] AND [High] = [Low] AND [Low] = [Close]))
                    INSERT INTO @retTable VALUES (@MarkType, @StkCode)
            END
    CLOSE curYZZT
    DEALLOCATE curYZZT

    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST

SELECT * FROM dbo.GetNewNotBrokenCodeList('2017/09/21', @RangeList)
*/










IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetTouchZTCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetTouchZTCodeList
GO

-- *************** 功能描述: 返回某日达到过涨停板列表 ***************
CREATE FUNCTION dbo.GetTouchZTCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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
        AND ((curP.[High] - prepP.[Close]) / prepP.[Close] * 100) >= 9.9
        AND EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = curP.MarkType AND StkCode = curP.StkCode AND TradeDay = @TradeDay AND [High] > [Close])
    
    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT * FROM dbo.GetTouchZTCodeList('2017/09/21', @RangeList)
*/






IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetDTCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetDTCodeList
GO

-- *************** 功能描述: 返回某日跌停板列表 ***************
CREATE FUNCTION dbo.GetDTCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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
        AND ((prepP.[Close] - curP.[Close]) / prepP.[Close] * 100) >= 9.9
        AND EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = curP.MarkType AND StkCode = curP.StkCode AND TradeDay = @TradeDay AND [Low] = [Close]) -- 跌停肯定是收盘为最低价
    
    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT * FROM dbo.GetDTCodeList('2017/09/21', @RangeList)
*/










IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetTouchDTCodeList') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetTouchDTCodeList
GO

-- *************** 功能描述: 返回某日达到过跌停板列表 ***************
CREATE FUNCTION dbo.GetTouchDTCodeList(@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
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
        AND ((prepP.[Close] - curP.[Low]) / prepP.[Close] * 100) >= 9.9
        AND EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = curP.MarkType AND StkCode = curP.StkCode AND TradeDay = @TradeDay AND [Low] < [Close])
    
    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT * FROM dbo.GetTouchDTCodeList('2017/09/21', @RangeList)
*/







IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetRatioContinueCount') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetRatioContinueCount
GO

-- *************** 功能描述: 返回某个涨跌幅持续天数 ***************
-- @StkType     0:指数，1:股票
-- @Ratio       涨跌幅
-- @Direction   0:小于，1:大于
-- @Ratio       = 9.9 / -9.9 时默认为：涨停板/跌停板
CREATE FUNCTION dbo.GetRatioContinueCount(@StkCode CHAR(6), @Ratio MONEY, @Direction INT, @TradeDay SMALLDATETIME = '1900/01/01', @StkType CHAR(1) = '1')
RETURNS INT
AS 
BEGIN
DECLARE @ret INT = 0

    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)

    -- 没填日期则默认是最后一个交易日
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')

    DECLARE @curRecId INT, @preRecId INT
    DECLARE @curPrice MONEY, @prePrice MONEY
    DECLARE @RatioCalc MONEY
    IF @StkType = '1'
        BEGIN            
            SELECT TOP 1 @curRecId = RecId, @curPrice = [Close]
            FROM KLineDay
            WHERE StkCode = @StkCode AND TradeDay = @TradeDay
            ORDER BY RecId DESC

            WHILE 1 = 1 AND @curRecId IS NOT NULL
                BEGIN
                    SET @preRecId = NULL
                    SET @prePrice = NULL
                    SELECT TOP 1 @preRecId = RecId, @prePrice = [Close]
                    FROM KLineDay 
                    WHERE StkCode = @StkCode AND RecId < @curRecId
                        -- 极大提高查找到上市第一天后速度变慢的问题，50000 条记录肯定能跳出 10 天的范围。因为隔好几天才导入
                        -- 可能会碰到停牌前涨停，停牌后继续涨停的问题，这里暂时过滤掉了。反正导入 KLineDay 时都是覆盖导入的。
                        AND RecId > @curRecId - 50000
                    ORDER BY RecId DESC
                    
                    IF @preRecId IS NULL OR @prePrice IS NULL
                        BREAK

                    SET @RatioCalc = (@curPrice - @prePrice) / @prePrice * 100
                    
                    IF @Direction = 0
                        -- 跌幅
                        BEGIN
                            IF @RatioCalc > @Ratio
                                BREAK

                            IF @Ratio = -9.9 AND NOT EXISTS(SELECT 1 FROM KLineDay WHERE RecId = @curRecId AND [Close] = [Low])
                                BREAK
                        END
                    ELSE
                        -- 涨幅
                        BEGIN
                            IF @RatioCalc < @Ratio
                                BREAK

                            IF @Ratio = 9.9 AND NOT EXISTS(SELECT 1 FROM KLineDay WHERE RecId = @curRecId AND [Close] = [High])
                                BREAK
                        END

                    SET @ret = @ret + 1
                    SET @curRecId = @preRecId
                    SET @curPrice = @prePrice
                END
        END
    ELSE
        BEGIN            
            SELECT TOP 1 @curRecId = RecId, @curPrice = [Close]
            FROM KLineDayZS
            WHERE StkCode = @StkCode AND TradeDay = @TradeDay
            ORDER BY RecId DESC

            WHILE 1 = 1 AND @curRecId IS NOT NULL
                BEGIN
                    SET @preRecId = NULL
                    SET @prePrice = NULL
                    SELECT TOP 1 @preRecId = RecId, @prePrice = [Close]
                    FROM KLineDayZS 
                    WHERE StkCode = @StkCode AND RecId < @curRecId
                        AND RecId > @curRecId - 10000 -- 极大提高查找到上市第一天后速度变慢的问题
                    ORDER BY RecId DESC
                    
                    IF @preRecId IS NULL OR @prePrice IS NULL
                        BREAK

                    SET @RatioCalc = (@curPrice - @prePrice) / @prePrice * 100
                    
                    IF @Direction = 0
                        -- 跌幅
                        BEGIN
                            IF @RatioCalc > @Ratio
                                BREAK

                            IF @Ratio = -9.9 AND NOT EXISTS(SELECT 1 FROM KLineDayZS WHERE RecId = @curRecId AND [Close] = [Low])
                                BREAK
                        END
                    ELSE
                        -- 涨幅
                        BEGIN
                            IF @RatioCalc < @Ratio
                                BREAK

                            IF @Ratio = 9.9 AND NOT EXISTS(SELECT 1 FROM KLineDayZS WHERE RecId = @curRecId AND [Close] = [High])
                                BREAK
                        END

                    SET @ret = @ret + 1
                    SET @curRecId = @preRecId
                    SET @curPrice = @prePrice
                END
        END
        
    RETURN @ret
END

GO
--SELECT dbo.GetRatioContinueCount('300654', 9.9, 1, '2017/10/09', '1')






IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetBKStockCodeInRange') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetBKStockCodeInRange
GO

-- *************** 功能描述: 返回指定范围内板块所包含的股票代码及名称 ***************
CREATE FUNCTION dbo.GetBKStockCodeInRange(@BKType NVARCHAR(20), @BKName NVARCHAR(20), @RangeList [CodeParmTable] READONLY)
RETURNS NVARCHAR(MAX)
AS 
BEGIN
    DECLARE @ret NVARCHAR(MAX) = ''
    
    SELECT @ret = STUFF((
        SELECT ', ' + comb.StkComb FROM
        (
            SELECT StkComb = b.StkCode + ' ' + b.StkName
            FROM StockBlock a JOIN StockHead b ON b.StkCode = a.StkCode AND b.StkType = 1
            WHERE   a.BKType = @BKType AND a.BKName = @BKName
                AND a.StkCode IN (SELECT StkCode FROM @RangeList)
        ) comb FOR XML PATH('')
    ),1,1,'')

    
    RETURN @ret
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT dbo.GetBKStockCodeInRange(N'行业', N'小家电', @RangeList)
*/





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetStockBlockFormat') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetStockBlockFormat
GO

-- *************** 功能描述: 返回个股所属板块的格式化字符串 ***************
CREATE FUNCTION dbo.GetStockBlockFormat(@StkCode CHAR(6))
RETURNS NVARCHAR(MAX)
AS 
BEGIN
    DECLARE @ret        NVARCHAR(MAX) = ''

    DECLARE @BKType     NVARCHAR(20)
    DECLARE @BKName     NVARCHAR(20)
    DECLARE @OrdNum     INT
    DECLARE @isFirst    INT = 1

    DECLARE cur1 CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
            SELECT BKType, BKName, OrdNum = ROW_NUMBER() OVER (PARTITION BY BKType ORDER BY BKType) 
            FROM StockBlock
            WHERE StkCode = @StkCode --'600050'
            ORDER BY
                    CASE BKType
                        WHEN N'地区'     THEN '0'
                        WHEN N'行业'     THEN '1'
                        WHEN N'行业细分' THEN '2'
                        WHEN N'概念'     THEN '3'
                        WHEN N'风格'     THEN '4'
                        WHEN N'指数'     THEN '5'
                        ELSE BKType
                    END
    OPEN cur1
        WHILE 1 = 1
            BEGIN
                FETCH cur1 INTO @BKType, @BKName, @OrdNum
                IF @@FETCH_STATUS <> 0
                    BREAK

                IF @OrdNum = 1 AND @isFirst = 0
                    SET @ret = @ret + ';' + CHAR(13) + CHAR(10)

                IF @OrdNum = 1
                    SET @ret = @ret + @BKType + ': ' + @BKName
                ELSE
                    SET @ret = @ret + ', ' + @BKName

                IF @isFirst = 1
                    SET @isFirst = 0
            END
    CLOSE cur1
    DEALLOCATE cur1
    
    --SELECT @ret
    RETURN @ret
END
GO
/*
SELECT dbo.GetStockBlockFormat('600050')
PRINT dbo.GetStockBlockFormat('600050')
*/







IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetMAValueByData') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.GetMAValueByData
GO

-- *************** 功能描述: 返回简单移动平均线值 ***************
-- @AvgNum  均线参数
-- @MAType  O: 开盘价, H: 最高价, L: 最低价, C: 收盘价
CREATE FUNCTION dbo.GetMAValueByData(@StkCode CHAR(6), @AvgNum INT, @TradeDay SMALLDATETIME = '1900/01/01', @MAType CHAR(1) = 'C', @StkType CHAR(1) = '1')
RETURNS MONEY
AS 
BEGIN
DECLARE @ret MONEY = 0

    -- 去掉时间
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)

    -- 没填日期则默认是最后一个交易日
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')

    IF @StkType = '1'
    BEGIN
        IF EXISTS(SELECT 1 FROM KLineDay WHERE StkCode = @StkCode AND TradeDay = @TradeDay) AND
           (SELECT COUNT(1) FROM KLineDay WHERE StkCode = @StkCode AND TradeDay <= @TradeDay) = @AvgNum 
        BEGIN
            IF @MAType = 'C'
                SELECT @ret = SUM([Close]) / @AvgNum FROM
                (
                    SELECT [Close], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDay 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) C
                WHERE C.rowNum <= @AvgNum
            ELSE IF @MAType = 'O'
                SELECT @ret = SUM([Open]) / @AvgNum FROM
                (
                    SELECT [Open], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDay 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) O
                WHERE O.rowNum <= @AvgNum
            ELSE IF @MAType = 'H'
                SELECT @ret = SUM([High]) / @AvgNum FROM
                (
                    SELECT [High], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDay 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) H
                WHERE H.rowNum <= @AvgNum
            ELSE IF @MAType = 'L'
                SELECT @ret = SUM([Low]) / @AvgNum FROM
                (
                    SELECT [Low], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDay 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) L
                WHERE L.rowNum <= @AvgNum
        END
    END
        IF EXISTS(SELECT 1 FROM KLineDayZS WHERE StkCode = @StkCode AND TradeDay = @TradeDay) AND
           (SELECT COUNT(1) FROM KLineDayZS WHERE StkCode = @StkCode AND TradeDay <= @TradeDay) = @AvgNum 
        BEGIN
            IF @MAType = 'C'
                SELECT @ret = SUM([Close]) / @AvgNum FROM
                (
                    SELECT [Close], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDayZS 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) C
                WHERE C.rowNum <= @AvgNum
            ELSE IF @MAType = 'O'
                SELECT @ret = SUM([Open]) / @AvgNum FROM
                (
                    SELECT [Open], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDayZS 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) O
                WHERE O.rowNum <= @AvgNum
            ELSE IF @MAType = 'H'
                SELECT @ret = SUM([High]) / @AvgNum FROM
                (
                    SELECT [High], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDayZS 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) H
                WHERE H.rowNum <= @AvgNum
            ELSE IF @MAType = 'L'
                SELECT @ret = SUM([Low]) / @AvgNum FROM
                (
                    SELECT [Low], rowNum = ROW_NUMBER() OVER (ORDER BY RecId DESC) FROM KLineDayZS 
                    WHERE   StkCode = @StkCode AND TradeDay <= @TradeDay
                ) L
                WHERE L.rowNum <= @AvgNum
        END


    RETURN @ret
END

GO
--SELECT dbo.GetMAValueByData('300654', 5, '2017/10/09', 'C', '1')
