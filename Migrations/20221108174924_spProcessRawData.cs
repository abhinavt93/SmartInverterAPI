using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class spProcessRawData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

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

                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC ('
                    DROP PROCEDURE [dbo].[spProcessRawData]
                ')
            ");
        }
    }
}
