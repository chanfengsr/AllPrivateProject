-- 统计当天收盘收在最低价
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





-- 前后 10 条记录
SELECT TOP 10 cur.* 
FROM
(
    SELECT MarkType, StkCode, TradeDay, [Open], High, Low, [Close], Volume, Amount, RecId, 
        Prev1RecId,
        Prev2RecId = CASE WHEN t1.Prev2RecId = t1.Prev1RecId THEN -1 ELSE t1.Prev2RecId END,
        Prev3RecId = CASE WHEN t1.Prev3RecId = t1.Prev2RecId THEN -1 ELSE t1.Prev3RecId END,
        Prev4RecId = CASE WHEN t1.Prev4RecId = t1.Prev3RecId THEN -1 ELSE t1.Prev4RecId END,
        Prev5RecId = CASE WHEN t1.Prev5RecId = t1.Prev4RecId THEN -1 ELSE t1.Prev5RecId END,
        Prev6RecId = CASE WHEN t1.Prev6RecId = t1.Prev5RecId THEN -1 ELSE t1.Prev6RecId END,
        Prev7RecId = CASE WHEN t1.Prev7RecId = t1.Prev6RecId THEN -1 ELSE t1.Prev7RecId END,
        Prev8RecId = CASE WHEN t1.Prev8RecId = t1.Prev7RecId THEN -1 ELSE t1.Prev8RecId END,
        Prev9RecId = CASE WHEN t1.Prev9RecId = t1.Prev8RecId THEN -1 ELSE t1.Prev9RecId END,
        Prev10RecId = CASE WHEN t1.Prev10RecId = t1.Prev9RecId THEN -1 ELSE t1.Prev10RecId END,
        
        Next1RecId,
        Next2RecId = CASE WHEN t1.Next2RecId = t1.Next1RecId THEN -1 ELSE t1.Next2RecId END,
        Next3RecId = CASE WHEN t1.Next3RecId = t1.Next2RecId THEN -1 ELSE t1.Next3RecId END,
        Next4RecId = CASE WHEN t1.Next4RecId = t1.Next3RecId THEN -1 ELSE t1.Next4RecId END,
        Next5RecId = CASE WHEN t1.Next5RecId = t1.Next4RecId THEN -1 ELSE t1.Next5RecId END,
        Next6RecId = CASE WHEN t1.Next6RecId = t1.Next5RecId THEN -1 ELSE t1.Next6RecId END,
        Next7RecId = CASE WHEN t1.Next7RecId = t1.Next6RecId THEN -1 ELSE t1.Next7RecId END,
        Next8RecId = CASE WHEN t1.Next8RecId = t1.Next7RecId THEN -1 ELSE t1.Next8RecId END,
        Next9RecId = CASE WHEN t1.Next9RecId = t1.Next8RecId THEN -1 ELSE t1.Next9RecId END,
        Next10RecId = CASE WHEN t1.Next10RecId = t1.Next9RecId THEN -1 ELSE t1.Next10RecId END
    FROM
    (
        SELECT MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount,RecId,
            Prev1RecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC), -1),
            Prev2RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 2 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev3RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 3 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev4RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 4 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev5RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 5 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev6RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 6 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev7RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 7 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev8RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 8 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev9RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 9 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            Prev10RecId = ISNULL((SELECT TOP 1 RecId FROM (SELECT TOP 10 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay < t0.TradeDay ORDER BY TradeDay DESC) a ORDER BY a.TradeDay ASC), -1),
            
            Next1RecId = ISNULL((SELECT TOP 1 RecId FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC), -1),
            Next2RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 2 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next3RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 3 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next4RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 4 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next5RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 5 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next6RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 6 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next7RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 7 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next8RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 8 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next9RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 9 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1),
            Next10RecId = ISNULL((SELECT TOP 1 a.RecId FROM (SELECT TOP 10 RecId, TradeDay FROM KLineDay WHERE MarkType = t0.MarkType AND StkCode = t0.StkCode AND TradeDay > t0.TradeDay ORDER BY TradeDay ASC) a ORDER BY a.TradeDay DESC), -1)
        FROM KLineDay t0
    ) t1
) cur
JOIN KLineDay prev1 ON prev1.RecId = cur.Prev1RecId
JOIN KLineDay prev2 ON prev2.RecId = cur.Prev2RecId
JOIN KLineDay prev3 ON prev3.RecId = cur.Prev3RecId
JOIN KLineDay prev4 ON prev4.RecId = cur.Prev4RecId
JOIN KLineDay prev5 ON prev5.RecId = cur.Prev5RecId
JOIN KLineDay prev6 ON prev6.RecId = cur.Prev6RecId
JOIN KLineDay prev7 ON prev7.RecId = cur.Prev7RecId
JOIN KLineDay prev8 ON prev8.RecId = cur.Prev8RecId
JOIN KLineDay prev9 ON prev9.RecId = cur.Prev9RecId
JOIN KLineDay prev10 ON prev10.RecId = cur.Prev10RecId
JOIN KLineDay next1 ON next1.RecId = cur.Next1RecId
JOIN KLineDay next2 ON next2.RecId = cur.Next2RecId
JOIN KLineDay next3 ON next3.RecId = cur.Next3RecId
JOIN KLineDay next4 ON next4.RecId = cur.Next4RecId
JOIN KLineDay next5 ON next5.RecId = cur.Next5RecId
JOIN KLineDay next6 ON next6.RecId = cur.Next6RecId
JOIN KLineDay next7 ON next7.RecId = cur.Next7RecId
JOIN KLineDay next8 ON next8.RecId = cur.Next8RecId
JOIN KLineDay next9 ON next9.RecId = cur.Next9RecId
JOIN KLineDay next10 ON next10.RecId = cur.Next10RecId


