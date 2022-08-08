using System;
namespace SmartInverterAPI.Models
{
    public class RawData
    {
        public int id { get; set; }

        public Decimal SolarOutputWatts { get; set; }

        public Decimal SolarGeneratedWh { get; set; }

        public Decimal LoadWatts { get; set; }

        public Decimal ConsumptionWh { get; set; }

        public Decimal BatteryPerc { get; set; }

        public string PowerSource { get; set; }

        public DateTime LoggedAt { get; set; }

        public int TimeIntervalSec { get; set; }

        public int CustomerID { get; set; }

    }
}
