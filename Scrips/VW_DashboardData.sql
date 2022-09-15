SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_DashboardData] AS

    SELECT ROUND(LY.SolarGeneratedWh, 2) AS PowerGeneratedThisMonth , ROUND(LY.ConsumptionWh, 2) AS PowerConsumedThisMonth
        , ROUND(LM1.SolarGeneratedWh, 2) AS PowerGeneratedToday     , ROUND(LM1.ConsumptionWh, 2) AS PowerConsumedToday
        , ROUND(LM2.PowerGeneratedPerDay, 2) AS PowerGeneratedPerDay, ROUND(LM2.PowerConsumedPerDay, 2) AS PowerConsumedPerDay
        , CD.PowerSource, CD.BatteryPerc, CD.CurrentLoadWatts, CD.CurrentSolarOutputWatts, CD.CustomerID, CD.LoggedAt
    FROM CurrentData CD
    LEFT JOIN (
        SELECT CustomerID, ROW_NUMBER() OVER(PARTITION BY CustomerID ORDER BY LoggedAt DESC) Rank, SolarGeneratedWh, ConsumptionWh 
        FROM LastYearData
    ) LY ON LY.CustomerID = CD.CustomerID AND LY.Rank = 1
    LEFT JOIN (
        SELECT CustomerID, ROW_NUMBER() OVER(PARTITION BY CustomerID ORDER BY LoggedAt DESC) Rank, SolarGeneratedWh, ConsumptionWh
        FROM LastMonthData
    ) LM1 ON LM1.CustomerID = CD.CustomerID AND LM1.Rank = 1
    LEFT JOIN (
        SELECT CustomerID, AVG(SolarGeneratedWh) AS PowerGeneratedPerDay, AVG(ConsumptionWh) AS PowerConsumedPerDay 
        FROM LastMonthData GROUP BY CustomerID 
    ) LM2 ON LM2.CustomerID = CD.CustomerID
    WHERE CD.CustomerID = 610
GO
