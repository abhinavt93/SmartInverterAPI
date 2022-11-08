using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using SmartInverterAPI.Models;

#nullable disable

namespace SmartInverterAPI.Migrations
{
    public partial class spUpdateLastYearTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                EXEC ('
                    
                    CREATE PROCEDURE[dbo].[spUpdateLastYearTable]
                    @SolarOutputWatts[decimal](18, 2),
	                @SolarGeneratedWh[decimal](18, 2),
	                @LoadWatts[decimal](18, 2),
	                @ConsumptionWh[decimal](18, 2),
	                @BatteryPerc[decimal](18, 2),
	                @PowerSource[nvarchar](max),
	                @LoggedAt[datetime2],
	                @TimeIntervalSec[int],
                    @CustomerID[int]
                AS
                --DECLARE @SampleCount INT

                IF EXISTS(SELECT * FROM LastYearData WITH(NOLOCK) WHERE[Month] = DATEPART(MONTH, @LoggedAt) AND[Year] = DATEPART(YEAR, @LoggedAt) AND CustomerID = @CustomerID)
                BEGIN
                    UPDATE LastYearData WITH(ROWLOCK)
                    SET AvgSolarOutputWatts = ((AvgSolarOutputWatts * (SampleCount)) + @SolarOutputWatts) / (SampleCount + 1)
                        , SolarGeneratedWh = SolarGeneratedWh + (@SolarOutputWatts * @TimeIntervalSec / 3600.0)
                        , AvgLoadWatts = ((AvgLoadWatts * (SampleCount)) + @LoadWatts) / (SampleCount + 1)
                        , ConsumptionWh = ConsumptionWh + (@LoadWatts * @TimeIntervalSec / 3600.0)
                        , BatteryPerc = @BatteryPerc
                        , PowerSource = @PowerSource
                        , LoggedAt = @LoggedAt
                        , SampleCount = SampleCount + 1
                    WHERE[Month] = DATEPART(MONTH, @LoggedAt) AND[Year] = DATEPART(YEAR, @LoggedAt) AND CustomerID = @CustomerID
                END
                ELSE
                BEGIN
                    INSERT INTO LastYearData
                            (SampleCount, [Month]                      , [Year]                    , AvgSolarOutputWatts   , SolarGeneratedWh  , AvgLoadWatts  , ConsumptionWh     , BatteryPerc   , PowerSource   , LoggedAt    , CustomerID    )
                    VALUES(1, DATEPART(MONTH, @LoggedAt), DATEPART(YEAR, @LoggedAt), @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @CustomerID)

                END
                ')

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC ('
                    DROP PROCEDURE [dbo].[spUpdateLastYearTable]
                ')
            ");
        }
    }
}
