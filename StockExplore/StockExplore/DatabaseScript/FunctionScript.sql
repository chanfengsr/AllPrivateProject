
/****** Object:  UserDefinedFunction [dbo].[GetStockRatio]    Script Date: 09/05/2017 10:54:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStockRatio]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStockRatio]
GO


/****** Object:  UserDefinedFunction [dbo].[GetStockRatio]    Script Date: 09/05/2017 10:54:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--****************************************************************
--
--��������(Object Name):    
--
--��������(Description):    ���ظ���ĳ���Ƿ�
--
--����(Parameters):         
--
--����(Author):             ����
--
--����(ALTER  Date):        2017/09/05
--
--ʾ��(Example):            
--
--�޸ļ�¼(Revision History):
--
--****************************************************************
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


IF (@ret IS NULL) 
    SET @ret = 0

RETURN @ret
END

GO