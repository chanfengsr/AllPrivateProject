-- 统计当天收盘收在最低价，
WITH RelateRecord (MarkType, StkCode, TradeDay, [Open], [High], [Low], [Close], Volume, Amount, RecId, PrevRecId, NextRecId, Next2RecId) AS
(
    SELECT MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount,RecId,
        PrevRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = LowClose.MarkType AND StkCode = LowClose.StkCode AND TradeDay < LowClose.TradeDay ORDER BY TradeDay DESC), -1),
        NextRecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = LowClose.MarkType AND StkCode = LowClose.StkCode AND TradeDay > LowClose.TradeDay ORDER BY TradeDay ASC), -1),
        Next2RecId = ISNULL((SELECT TOP 1 a.RecId FROM (    SELECT TOP 2 RecId, TradeDay FROM KLineDay 
                                                            WHERE MarkType = LowClose.MarkType AND StkCode = LowClose.StkCode AND TradeDay > LowClose.TradeDay 
                                                            ORDER BY TradeDay ASC
                                                      ) a ORDER BY a.TradeDay DESC), -1)
    FROM (
            SELECT MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount,RecId 
            FROM KLineDay WHERE TradeDay >= '2010/1/1' AND [Close] = [Low]    -- 最低价作收
        ) LowClose
)
SELECT COUNT(1)
FROM   RelateRecord cur
JOIN   KLineDay prev
  ON   cur.PrevRecId = prev.RecId 
JOIN   KLineDay nxt
  ON   cur.NextRecId = nxt.RecId
JOIN   KLineDay nxt2
  ON   cur.Next2RecId = nxt2.RecId
WHERE  cur.[Close] > prev.[Close] * 0.901   -- 去掉跌停 
--AND    cur.[Close] < prev.[Close]         -- 第二天真阳线
AND    cur.[Close] < prev.[Close] * 0.98    -- 当日跌幅大于 2%
AND    cur.[Close] > nxt.[Open]             -- 第二天低开
AND    nxt.[Close] < nxt2.[Close]           -- 第三天阳线