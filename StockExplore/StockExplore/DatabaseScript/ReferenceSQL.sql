-- ͳ�Ƶ�������������ͼۣ�
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
            FROM KLineDay WHERE TradeDay >= '2010/1/1' AND [Close] = [Low]    -- ��ͼ�����
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
WHERE  cur.[Close] > prev.[Close] * 0.901   -- ȥ����ͣ 
--AND    cur.[Close] < prev.[Close]         -- �ڶ���������
AND    cur.[Close] < prev.[Close] * 0.98    -- ���յ������� 2%
AND    cur.[Close] > nxt.[Open]             -- �ڶ���Ϳ�
AND    nxt.[Close] < nxt2.[Close]           -- ����������