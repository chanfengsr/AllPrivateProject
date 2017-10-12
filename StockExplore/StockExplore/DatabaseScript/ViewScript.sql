SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.cv_AStockCode'))
DROP VIEW dbo.cv_AStockCode
GO

-- *************** 功能描述: 沪深 A股代码列表 ***************
CREATE VIEW cv_AStockCode AS

    SELECT MarkType, StkCode FROM StockHead
    WHERE StkType = 1
    AND   ( (MarkType = 'sh' AND StkCode LIKE '60%') OR
            (MarkType = 'sz' AND (StkCode LIKE '00%' OR StkCode LIKE '30%'))
    )

GO
--SELECT * FROM cv_AStockCode





IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.cv_AStockCodeExcST'))
DROP VIEW dbo.cv_AStockCodeExcST
GO

-- *************** 功能描述: 沪深 A股代码列表，剔除 ST ***************
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






IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.cv_NeighbourKLineDayRecId'))
DROP VIEW dbo.cv_NeighbourKLineDayRecId
GO

-- *************** 功能描述: KLineDay 相邻 RecId ***************
CREATE VIEW cv_NeighbourKLineDayRecId AS

    SELECT *,
        PrevRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay < t.TradeDay ORDER BY TradeDay DESC), -1),
        NextRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay > t.TradeDay ORDER BY TradeDay ASC), -1)            
    FROM KLineDay t

GO
-- SELECT TOP 100 * FROM cv_NeighbourKLineDayRecId WHERE StkCode = '000001'






IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.cv_NeighbourKLineDayZSRecId'))
DROP VIEW dbo.cv_NeighbourKLineDayZSRecId
GO

-- *************** 功能描述: KLineDayZS 相邻 RecId ***************
CREATE VIEW cv_NeighbourKLineDayZSRecId AS

    SELECT *,
        PrevRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDayZS WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay < t.TradeDay ORDER BY TradeDay DESC), -1),
        NextRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDayZS WHERE MarkType = t.MarkType AND StkCode = t.StkCode AND TradeDay > t.TradeDay ORDER BY TradeDay ASC), -1)            
    FROM KLineDayZS t

GO
-- SELECT TOP 100 * FROM cv_NeighbourKLineDayZSRecId WHERE StkCode = '000001'