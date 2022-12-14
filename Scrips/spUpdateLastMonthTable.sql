SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateLastMonthTable] 
    @SolarOutputWatts [decimal] (18,2),
	@SolarGeneratedWh [decimal] (18,2),
	@LoadWatts [decimal] (18,2),
	@ConsumptionWh [decimal] (18,2),
	@BatteryPerc [decimal] (18,2),
	@PowerSource [nvarchar](max),
	@LoggedAt [datetime2],
	@TimeIntervalSec [int],
    @CustomerID [int]
AS 
--DECLARE @SampleCount INT

IF EXISTS (SELECT * FROM LastMonthData WITH(NOLOCK) WHERE [Day] = DATEPART(DAY, @LoggedAt) AND CustomerID = @CustomerID)
BEGIN
    IF EXISTS (SELECT * FROM LastMonthData WITH(NOLOCK) WHERE [Day] = DATEPART(DAY, @LoggedAt) AND [Month] = DATEPART(MONTH, @LoggedAt) AND CustomerID = @CustomerID)
    BEGIN
        UPDATE LastMonthData WITH(ROWLOCK)
        SET AvgSolarOutputWatts = ((AvgSolarOutputWatts * (SampleCount)) + @SolarOutputWatts) / (SampleCount + 1)
            , SolarGeneratedWh = SolarGeneratedWh + (@SolarOutputWatts * @TimeIntervalSec / 3600.0)
            , AvgLoadWatts = ((AvgLoadWatts * (SampleCount)) + @LoadWatts) / (SampleCount + 1)
            , ConsumptionWh = ConsumptionWh + (@LoadWatts * @TimeIntervalSec / 3600.0)
            , BatteryPerc = @BatteryPerc
            , PowerSource = @PowerSource
            , LoggedAt = @LoggedAt
            , SampleCount = SampleCount + 1
        WHERE [Day] = DATEPART(DAY, @LoggedAt) AND CustomerID = @CustomerID
    END
    ELSE IF EXISTS(SELECT * FROM LastMonthData WITH(NOLOCK) WHERE [Day] = DATEPART(DAY, @LoggedAt) AND ([Month] < DATEPART(MONTH, @LoggedAt) OR DATEPART(YEAR, LoggedAt) < DATEPART(YEAR, @LoggedAt)) AND CustomerID = @CustomerID)
    BEGIN
        UPDATE LastMonthData
        SET SampleCount = 1
            , AvgSolarOutputWatts = @SolarOutputWatts
            , SolarGeneratedWh = @SolarOutputWatts * @TimeIntervalSec / 3600.0
            , AvgLoadWatts = @LoadWatts
            , ConsumptionWh = @LoadWatts * @TimeIntervalSec / 3600.0
            , BatteryPerc = @BatteryPerc
            , PowerSource = @PowerSource
            , LoggedAt = @LoggedAt
            , [Month] = DATEPART(MONTH, @LoggedAt)
        WHERE [Day] = DATEPART(DAY, @LoggedAt) AND CustomerID = @CustomerID
    END
END
ELSE
BEGIN
    INSERT INTO LastMonthData
            (SampleCount,    [Day]                       , [Month]                     , AvgSolarOutputWatts   , SolarGeneratedWh  , AvgLoadWatts  , ConsumptionWh     , BatteryPerc   , PowerSource   , LoggedAt   , CustomerID    )
    VALUES  (1          ,    DATEPART(DAY, @LoggedAt)    , DATEPART(MONTH, @LoggedAt)  , @SolarOutputWatts     , @SolarGeneratedWh , @LoadWatts    , @ConsumptionWh    , @BatteryPerc  , @PowerSource  , @LoggedAt  , @CustomerID   )

END


GO
