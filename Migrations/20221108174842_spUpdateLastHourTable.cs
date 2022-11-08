using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class spUpdateLastHourTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC ('

                    CREATE PROCEDURE [dbo].[spUpdateLastHourTable] 
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

                IF EXISTS (SELECT * FROM LastHourData WITH(NOLOCK) WHERE [Minute] = DATEPART(MINUTE, @LoggedAt))
                BEGIN
                    IF EXISTS (SELECT * FROM LastHourData WITH(NOLOCK) WHERE [Minute] = DATEPART(MINUTE, @LoggedAt) AND [Hour] = DATEPART(HOUR, @LoggedAt) AND CustomerID = @CustomerID)
                    BEGIN
                        UPDATE LastHourData WITH(ROWLOCK)
                        SET AvgSolarOutputWatts = ((AvgSolarOutputWatts * (SampleCount)) + @SolarOutputWatts) / (SampleCount + 1)
                            , SolarGeneratedWh = SolarGeneratedWh + (@SolarOutputWatts * @TimeIntervalSec / 3600.0)
                            , AvgLoadWatts = ((AvgLoadWatts * (SampleCount)) + @LoadWatts) / (SampleCount + 1)
                            , ConsumptionWh = ConsumptionWh + (@LoadWatts * @TimeIntervalSec / 3600.0)
                            , BatteryPerc = @BatteryPerc
                            , PowerSource = @PowerSource
                            , LoggedAt = @LoggedAt
                            , SampleCount = SampleCount + 1
                        WHERE [Minute] = DATEPART(MINUTE, @LoggedAt) AND CustomerID = @CustomerID
                    END
                    ELSE IF EXISTS(SELECT * FROM LastHourData WITH(NOLOCK) WHERE [Minute] = DATEPART(MINUTE, @LoggedAt) AND ([Hour] < DATEPART(HOUR, @LoggedAt) OR CONVERT(DATE, LoggedAt) < CONVERT(DATE, @LoggedAt)) AND CustomerID = @CustomerID)
                    BEGIN
                        UPDATE LastHourData
                        SET SampleCount = 1
                            , AvgSolarOutputWatts = @SolarOutputWatts
                            , SolarGeneratedWh = @SolarOutputWatts * @TimeIntervalSec / 3600.0
                            , AvgLoadWatts = @LoadWatts
                            , ConsumptionWh = @LoadWatts * @TimeIntervalSec / 3600.0
                            , BatteryPerc = @BatteryPerc
                            , PowerSource = @PowerSource
                            , LoggedAt = @LoggedAt
                            , [Hour] = DATEPART(HOUR, @LoggedAt)
                        WHERE [Minute] = DATEPART(MINUTE, @LoggedAt) AND CustomerID = @CustomerID
                    END
                END
                ELSE
                BEGIN
                    INSERT INTO LastHourData
                            (SampleCount,    [Minute]                       , [Hour]                     , AvgSolarOutputWatts   , SolarGeneratedWh  , AvgLoadWatts  , ConsumptionWh     , BatteryPerc   , PowerSource   , LoggedAt     , CustomerID  )
                    VALUES  (1          ,    DATEPART(MINUTE, @LoggedAt)    , DATEPART(HOUR, @LoggedAt)  , @SolarOutputWatts     , @SolarGeneratedWh , @LoadWatts    , @ConsumptionWh    , @BatteryPerc  , @PowerSource  , @LoggedAt    , @CustomerID )

                END

                ')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC ('
                    DROP PROCEDURE [dbo].[spUpdateLastHourTable]
                ')
            ");
        }
    }
}
