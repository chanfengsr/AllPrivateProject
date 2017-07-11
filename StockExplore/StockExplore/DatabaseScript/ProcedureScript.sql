IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcKLineWeek]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CalcKLineWeek]
GO

CREATE PROCEDURE [dbo].[CalcKLineWeek]
    @ReCalcAll INT = 0
AS
SET NOCOUNT ON

DECLARE @startDay DATETIME
DECLARE @endDay   DATETIME

-- 最后一个交易周的最后一天
SET @endDay   = (SELECT TOP 1 TradeDay FROM KLineDayZS WHERE StkCode = '999999' AND (DATEPART(weekday, TradeDay) = 6 OR DATEDIFF(week, TradeDay, GETDATE()) > 0) ORDER BY TradeDay DESC)

IF @ReCalcAll = 1
    BEGIN
        TRUNCATE TABLE KLineWeek
        SET @startDay = (SELECT TOP 1 TradeDay FROM KLineDayZS WHERE StkCode = '999999' ORDER BY TradeDay)
    END
ELSE
    BEGIN
        SET @startDay = (SELECT TOP 1 TradeDay
                         FROM   KLineDayZS
                         WHERE  StkCode = '999999'
                         AND    TradeDay > ISNULL((SELECT TOP 1 TradeDay FROM KLineWeek WHERE StkCode = '999999' ORDER BY TradeDay DESC), 0)
                         ORDER BY TradeDay)
    END

IF @startDay = NULL OR @endDay = NULL OR @startDay > @endDay
    RETURN



DECLARE @weekDiff INT
DECLARE @minWeekDiff INT = DATEDIFF(week, 0, @startDay)
DECLARE @maxWeekDiff INT = DATEDIFF(week, 0, @endDay)
DECLARE @weekStartDay DATETIME, @weekEndDay DATETIME  

SET @weekDiff = @minWeekDiff    
WHILE @weekDiff <= @maxWeekDiff
    BEGIN
        -- 取到每一个周一和周五
        SET @weekStartDay = DATEADD(week, @weekDiff, 0)
        SET @weekEndDay   = DATEADD(week, @weekDiff, 4)
        
        -- 批量插入所有股票一周的 K 线数据
        --PRINT CONVERT(CHAR(10), @weekStartDay, 111) + ' - ' + CONVERT(CHAR(10), @weekEndDay, 111)
        INSERT INTO KLineWeek(MarkType,StkCode,TradeDay,[Open],[High],[Low],[Close],Volume,Amount)
        SELECT b.MarkType, b.StkCode, c.TradeDay, b.[Open], a.[High], a.[Low], c.[Close], a.Volume, a.Amount
          FROM
        (
            SELECT [High] = MAX([High]), [Low] = MIN([Low]), Volume = SUM(Volume), Amount = SUM(Amount), OpenDayId = MIN(RecId), CloseDayId = MAX(RecId)
              FROM KLineDay WHERE TradeDay BETWEEN @weekStartDay AND @weekEndDay GROUP BY StkCode
        ) a
        JOIN (SELECT MarkType, StkCode, [Open], RecId FROM KLineDay) b
        ON a.OpenDayId = b.RecId
        JOIN (SELECT TradeDay, [Close], RecId FROM KLineDay) c
        ON a.CloseDayId = c.RecId
        UNION ALL
        SELECT b.MarkType, b.StkCode, c.TradeDay, b.[Open], a.[High], a.[Low], c.[Close], a.Volume, a.Amount
          FROM
        (
            SELECT [High] = MAX([High]), [Low] = MIN([Low]), Volume = SUM(Volume), Amount = SUM(Amount), OpenDayId = MIN(RecId), CloseDayId = MAX(RecId)
              FROM KLineDayZS WHERE TradeDay BETWEEN @weekStartDay AND @weekEndDay GROUP BY StkCode
        ) a
        JOIN (SELECT MarkType, StkCode, [Open], RecId FROM KLineDayZS) b
        ON a.OpenDayId = b.RecId
        JOIN (SELECT TradeDay, [Close], RecId FROM KLineDayZS) c
        ON a.CloseDayId = c.RecId
        
        SET @weekDiff = @weekDiff + 1
    END

SET NOCOUNT OFF
GO
--EXEC [CalcKLineWeek] 1
