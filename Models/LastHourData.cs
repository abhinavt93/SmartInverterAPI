using System;
namespace SmartInverterAPI.Models
{
    public class LastHourData
    {
        public int Id { get; set; }

        public int SampleCount { get; set; }

        public int Minute { get; set; }

        public int Hour { get; set; }

        public Decimal AvgSolarOutputWatts { get; set; }

        public Decimal SolarGeneratedWh { get; set; }

        public Decimal AvgLoadWatts { get; set; }

        public Decimal ConsumptionWh { get; set; }

        public Decimal BatteryPerc { get; set; }

        public string PowerSource { get; set; }

        public DateTime LoggedAt { get; set; }

        public int CustomerID { get; set; }
    }
}
