SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateLastDayTable] 
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

IF EXISTS (SELECT * FROM LastDayData WITH(NOLOCK) WHERE [Hour] = DATEPART(HOUR, @LoggedAt))
BEGIN
    IF EXISTS (SELECT * FROM LastDayData WITH(NOLOCK) WHERE [Day] = DATEPART(DAY, @LoggedAt) AND [Hour] = DATEPART(HOUR, @LoggedAt) AND CustomerID = @CustomerID)
    BEGIN
        UPDATE LastDayData WITH(ROWLOCK)
        SET AvgSolarOutputWatts = ((AvgSolarOutputWatts * (SampleCount)) + @SolarOutputWatts) / (SampleCount + 1)
            , SolarGeneratedWh = SolarGeneratedWh + (@SolarOutputWatts * @TimeIntervalSec / 3600.0)
            , AvgLoadWatts = ((AvgLoadWatts * (SampleCount)) + @LoadWatts) / (SampleCount + 1)
            , ConsumptionWh = ConsumptionWh + (@LoadWatts * @TimeIntervalSec / 3600.0)
            , BatteryPerc = @BatteryPerc
            , PowerSource = @PowerSource
            , LoggedAt = @LoggedAt
            , SampleCount = SampleCount + 1
        WHERE [Hour] = DATEPART(HOUR, @LoggedAt) AND CustomerID = @CustomerID
    END
    ELSE IF EXISTS(SELECT * FROM LastDayData WITH(NOLOCK) WHERE [Hour] = DATEPART(HOUR, @LoggedAt) AND ([Day] < DATEPART(DAY, @LoggedAt) OR CONVERT(DATE, LoggedAt) < CONVERT(DATE, @LoggedAt)) AND CustomerID = @CustomerID)
    BEGIN
        UPDATE LastDayData
        SET SampleCount = 1
            , AvgSolarOutputWatts = @SolarOutputWatts
            , SolarGeneratedWh = @SolarOutputWatts * @TimeIntervalSec / 3600.0
            , AvgLoadWatts = @LoadWatts
            , ConsumptionWh = @LoadWatts * @TimeIntervalSec / 3600.0
            , BatteryPerc = @BatteryPerc
            , PowerSource = @PowerSource
            , LoggedAt = @LoggedAt
            , [Day] = DATEPART(DAY, @LoggedAt)
        WHERE [Hour] = DATEPART(HOUR, @LoggedAt) AND CustomerID = @CustomerID
    END
END
ELSE
BEGIN
    INSERT INTO LastDayData
            (SampleCount,    [Hour]                       , [Day]                     , AvgSolarOutputWatts   , SolarGeneratedWh  , AvgLoadWatts  , ConsumptionWh     , BatteryPerc   , PowerSource   , LoggedAt    , CustomerID    )
    VALUES  (1          ,    DATEPART(HOUR, @LoggedAt)    , DATEPART(DAY, @LoggedAt)  , @SolarOutputWatts     , @SolarGeneratedWh , @LoadWatts    , @ConsumptionWh    , @BatteryPerc  , @PowerSource  , @LoggedAt   , @CustomerID   )

END


GO
