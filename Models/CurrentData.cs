using System;
namespace SmartInverterAPI.Models
{
    public class CurrentData
    {
        public int Id { get; set; }

        public Decimal CurrentSolarOutputWatts { get; set; }

        public Decimal CurrentLoadWatts { get; set; }

        public Decimal BatteryPerc { get; set; }

        public string PowerSource { get; set; }

        public DateTime LoggedAt { get; set; }

        public int CustomerID { get; set; }
    }
}
