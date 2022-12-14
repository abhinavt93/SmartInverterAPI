SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateCurrentData] 
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

SELECT * FROM CurrentData

IF EXISTS (SELECT * FROM CurrentData WITH(NOLOCK))
BEGIN
    IF (@LoggedAt > (SELECT LoggedAt FROM CurrentData WITH(NOLOCK)))
    BEGIN
        UPDATE CurrentData WITH(ROWLOCK)
        SET CurrentSolarOutputWatts = @SolarOutputWatts
            , CurrentLoadWatts = @LoadWatts
            , BatteryPerc = @BatteryPerc
            , PowerSource = @PowerSource
            , LoggedAt = @LoggedAt
        WHERE CustomerID = @CustomerID
    END
END
ELSE
BEGIN
    INSERT INTO CurrentData
            (CurrentSolarOutputWatts    ,    CurrentLoadWatts   , BatteryPerc   , PowerSource   , LoggedAt  , CustomerID    )
    VALUES  (@SolarOutputWatts          ,    @LoadWatts         , @BatteryPerc  , @PowerSource  , @LoggedAt , @CustomerID   )

END


GO
