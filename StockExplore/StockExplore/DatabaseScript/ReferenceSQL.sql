-- 统计当天收盘收在最低价，
WITH RelateRecord (MarkType, StkCode, TradeDay, [Open], [High], [Low], [Close], Volume, Amount, RecId, PrevRecId, NextRecId) AS
(
    SELECT MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount,RecId,
        PrevRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = LowClose.MarkType AND StkCode = LowClose.StkCode AND TradeDay < LowClose.TradeDay ORDER BY TradeDay DESC), -1),
        NextRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = LowClose.MarkType AND StkCode = LowClose.StkCode AND TradeDay > LowClose.TradeDay ORDER BY TradeDay ASC), -1)
    FROM (
            SELECT MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount,RecId 
            FROM KLineDay WHERE TradeDay >= '2010/1/1' AND [Close] = [Low]    
        ) LowClose
)
SELECT COUNT(1)
FROM   RelateRecord cur
JOIN   KLineDay prev
  ON   cur.PrevRecId = prev.RecId 
JOIN   KLineDay nxt
  ON   cur.NextRecId = nxt.RecId
WHERE  cur.[Close] > prev.[Close] * 0.901 -- 去掉跌停 
AND    cur.[Close] < prev.[Close]
AND    cur.[Close] < prev.[Close] * 0.98 -- 当日跌幅大于 2%

AND    cur.[Close] > nxt.[Open]
--ORDER BY cur.TradeDay DESC