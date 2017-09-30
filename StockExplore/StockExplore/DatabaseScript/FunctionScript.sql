/*
***** �������ṹ *****
CREATE TYPE [dbo].[CodeParmTable] AS TABLE(
    [MarkType] [char](2) NOT NULL,
    [StkCode] [char](6) NOT NULL
)
GO
    
-- ȥ��ʱ��
IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
    SET @TradeDay = CAST(@TradeDay AS DATE)
    
MarkType    CHAR(2) NOT NULL,               -- �г����ͣ�����sh������sz��
StkType     CHAR(1) DEFAULT('1') NOT NULL,  -- 0 ָ����1 ��Ʊ

-- A�� �����б��޳� ST
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST

*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStockRatio]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStockRatio]
GO

-- *************** ��������: ���ظ���ĳ���Ƿ� ***************
CREATE FUNCTION [dbo].[GetStockRatio](@StkCode CHAR(6), @TradeDay SMALLDATETIME, @StkType CHAR(1) = 1)
RETURNS MONEY
AS 
BEGIN
DECLARE @ret MONEY

    -- ȥ��ʱ��
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)

    -- �Ƿ�������ָ��
    IF @StkType = 1
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



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllAStockCodeListExcST]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAllAStockCodeListExcST]
GO

-- *************** ��������: ����A��Ʊ�����б� ***************
CREATE FUNCTION [dbo].[GetAllAStockCodeListExcST]()
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





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetZTCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetZTCodeList]
GO

-- *************** ��������: ����ĳ����ͣ���б� ***************
CREATE FUNCTION [dbo].[GetZTCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    -- ȥ��ʱ��
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- û��������Ĭ�������һ��������
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')
    
    -- ��ʽ��䷵�ؼ�
    INSERT INTO @retTable
    SELECT curP.MarkType, curP.StkCode
    FROM KLineDay curP
    JOIN
    (
        SELECT a.StkCode, a.[Close] FROM KLineDay a
        JOIN (SELECT RecId = MAX(b0.RecId) FROM KLineDay b0
              WHERE b0.TradeDay < @TradeDay
                AND EXISTS (SELECT 1 FROM @RangeList WHERE MarkType = b0.MarkType AND StkCode = b0.StkCode) -- �����������б��ٶ�
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
        AND EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = curP.MarkType AND StkCode = curP.StkCode AND TradeDay = @TradeDay AND [High] = [Close]) -- ��ͣ�϶�������Ϊ��߼�
    
    RETURN
END
GO
/*
DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST
SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)
*/





IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetYZZTCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetYZZTCodeList]
GO

-- *************** ��������: ����ĳ��һ����ͣ���б� ***************
CREATE FUNCTION [dbo].[GetYZZTCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    -- ȥ��ʱ��
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- û��������Ĭ�������һ��������
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')

    -- �ȼ������ͣ�б�����������ľ�����ͣ�б�����Ҳ�����˶���ʱ�䣩
    DECLARE @ZTList AS [CodeParmTable]
    INSERT INTO @ZTList
    SELECT * FROM dbo.GetZTCodeList(@TradeDay, @RangeList)
    
    -- һ����ͣ����ͣ������ = ���� = ��� = ���
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

-- �˴��Ȼ����ͣ�б����ô��б������㣬Ҳ��ֱ�������� A���б�
DECLARE @ZTList AS [CodeParmTable]
INSERT INTO @ZTList SELECT * FROM dbo.GetZTCodeList('2017/09/21', @RangeList)

SELECT * FROM dbo.GetYZZTCodeList('2017/09/21', @ZTList)
*/







IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNewNotBrokenCodeList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetNewNotBrokenCodeList]
GO

-- *************** ��������: �����¹ɣ�δ���� �б� ***************
CREATE FUNCTION [dbo].[GetNewNotBrokenCodeList](@TradeDay SMALLDATETIME = '1900/01/01', @RangeList [CodeParmTable] READONLY)
RETURNS @retTable Table
    (
	    [MarkType] [char](2) NOT NULL,
	    [StkCode] [char](6) NOT NULL
    )
AS 
BEGIN
    
    -- ȥ��ʱ��
    IF DATEPART(hour, @TradeDay) + DATEPART(minute, @TradeDay) > 0
        SET @TradeDay = CAST(@TradeDay AS DATE)
    
    -- û��������Ĭ�������һ��������
    IF (@TradeDay = '1900/01/01')
        SET @TradeDay = (SELECT MAX(TradeDay) FROM KLineDayZS WHERE MarkType = 'sh' AND StkCode = '999999' OR StkCode = '000001')
        
    -- �������е�
    INSERT INTO @retTable
    SELECT DISTINCT a.MarkType, a.StkCode FROM KLineDay a
    WHERE   a.TradeDay = @TradeDay
        AND EXISTS (SELECT 1 FROM @RangeList WHERE MarkType = a.MarkType AND StkCode = a.StkCode)
        AND NOT EXISTS (SELECT 1 FROM KLineDay WHERE MarkType = a.MarkType AND StkCode = a.StkCode AND TradeDay < @TradeDay)
        
    -- �ȵõ�һ����ͣ�б�
    DECLARE @YZZTList AS [CodeParmTable]
    INSERT INTO @YZZTList
    SELECT * FROM dbo.GetYZZTCodeList(@TradeDay, @RangeList) yi
    WHERE NOT EXISTS (SELECT 1 FROM @retTable ret WHERE yi.MarkType = ret.MarkType AND yi.StkCode = ret.StkCode)

    -- ѭ����ǰ����
    DECLARE @MarkType [char](2)
    DECLARE @StkCode  [char](6)
    DECLARE curYZZT CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT MarkType, StkCode FROM @YZZTList
    OPEN curYZZT
        WHILE 1 = 1
            BEGIN
                FETCH curYZZT INTO @MarkType, @StkCode
                IF @@FETCH_STATUS <> 0
                    BREAK
    
                /*  do something  */
            END
    CLOSE curYZZT
    DEALLOCATE curYZZT

    RETURN
END
GO



DECLARE @RangeList AS [CodeParmTable]
INSERT INTO @RangeList SELECT * FROM cv_AStockCodeExcST

SELECT * FROM dbo.GetNewNotBrokenCodeList('2017/09/21', @RangeList)