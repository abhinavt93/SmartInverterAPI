using System;
namespace SmartInverterAPI.Models
{
    public class DashboardData
    {
        public int CustomerID { get; set; }

        public decimal PowerGeneratedThisMonth { get; set; }

        public decimal PowerConsumedThisMonth { get; set; }

        public decimal PowerGeneratedToday { get; set; }

        public decimal PowerConsumedToday { get; set; }

        public decimal PowerGeneratedPerDay { get; set; }

        public decimal PowerConsumedPerDay { get; set; }

        public decimal BatteryPerc { get; set; }

        public decimal CurrentLoadWatts { get; set; }

        public decimal CurrentSolarOutputWatts { get; set; }

        public string PowerSource { get; set; }

        public DateTime LoggedAt { get; set; }

        
    }
}
