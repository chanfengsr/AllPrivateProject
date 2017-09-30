SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[cv_AStockCodeExcST]'))
DROP VIEW [dbo].[cv_AStockCodeExcST]
GO

-- *************** ��������: ���� A�ɴ����б����޳� ST ***************
CREATE VIEW cv_AStockCodeExcST AS

    SELECT MarkType, StkCode FROM StockHead
    WHERE StkType = 1
    AND   ( (MarkType = 'sh' AND StkCode LIKE '60%') OR
            (MarkType = 'sz' AND (StkCode LIKE '00%' OR StkCode LIKE '30%'))
    )
    AND   StkName NOT LIKE 'ST%'
    AND   StkName NOT LIKE '*ST%'

GO
--SELECT * FROM cv_AStockCodeExcST






IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[cv_NeighbourKLineDayRecId]'))
DROP VIEW [dbo].[cv_NeighbourKLineDayRecId]
GO

-- *************** ��������: KLineDay ���� RecId ***************
CREATE VIEW cv_NeighbourKLineDayRecId AS

    SELECT *,
        PrevRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay < t.TradeDay ORDER BY TradeDay DESC), -1),
        NextRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay > t.TradeDay ORDER BY TradeDay ASC), -1)            
    FROM KLineDay t

GO
-- SELECT TOP 100 * FROM cv_NeighbourKLineDayRecId WHERE StkCode = '000001'