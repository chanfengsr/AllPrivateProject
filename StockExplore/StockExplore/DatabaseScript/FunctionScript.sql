
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStockRatio]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStockRatio]
GO

--功能描述: 返回个股某日涨幅
CREATE FUNCTION [dbo].[GetStockRatio](@StkCode CHAR(6), @TradeDay SMALLDATETIME, @StkType CHAR(1) = 1)
RETURNS MONEY
AS 
BEGIN
DECLARE @ret MONEY

IF @StkType = 1
    SELECT @ret = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 FROM 
    (
        SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay), TradeDay, [Close] FROM KLineDay
        WHERE StkCode = @StkCode
    ) curP
    JOIN 
    (
        SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay) + 1, TradeDay, [Close] FROM KLineDay
        WHERE StkCode = @StkCode
    ) prepP
    ON curP.RowNum = prepP.RowNum
    WHERE curP.TradeDay = @TradeDay
ELSE
    SELECT @ret = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 FROM 
    (
        SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay), TradeDay, [Close] FROM KLineDayZS
        WHERE StkCode = @StkCode
    ) curP
    JOIN 
    (
        SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay) + 1, TradeDay, [Close] FROM KLineDayZS
        WHERE StkCode = @StkCode
    ) prepP
    ON curP.RowNum = prepP.RowNum
    WHERE curP.TradeDay = @TradeDay

/*
IF (@ret IS NULL) 
    SET @ret = 0
*/

RETURN @ret
END

GO








IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllStockCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAllStockCodeList]
GO

--功能描述: 返回A股票代码列表
CREATE FUNCTION [dbo].[GetAllStockCodeList]()
RETURNS @ret [CodeParmTable]
AS 
BEGIN
--DECLARE @ret [CodeParmTable]
    
    BEGIN
    INSERT INTO @ret
    SELECT MarkType, StkCode FROM StockHead
    WHERE StkType = 1
    AND   ( (MarkType = 'sh' AND StkCode LIKE '60%') OR
            (MarkType = 'sz' AND (StkCode LIKE '00%' OR StkCode LIKE '30%')));
        
    END
    
--RETURN (SELECT * FROM @ret)
END
GO




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetZTCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetZTCodeList]
GO

--功能描述: 返回某日涨停板列表
CREATE FUNCTION [dbo].[GetZTCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] = NULL)
RETURNS [CodeParmTable]
AS 
BEGIN
DECLARE @ret [CodeParmTable]

RETURN @ret
END