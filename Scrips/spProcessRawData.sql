SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProcessRawData] 
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
    
    EXEC dbo.spUpdateCurrentData @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

    EXEC dbo.spUpdateLastHourTable @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

    EXEC dbo.spUpdateLastDayTable @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

    EXEC dbo.spUpdateLastMonthTable @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

    EXEC dbo.spUpdateLastYearTable @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

    EXEC dbo.spUpdateLastDecadeTable @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID

GO
