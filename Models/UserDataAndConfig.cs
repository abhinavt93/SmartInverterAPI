using System;
using System.ComponentModel.DataAnnotations;

namespace SmartInverterAPI.Models
{
    public class UserDataAndConfig
    {
        [Key]
        public int CustomerID { get; set; }

        public decimal MinimumBatteryPerc { get; set; }

        public decimal BatteryCapacitykWh { get; set; }

        public decimal SolarPanelCapacityWatts { get; set; }

        public DateTime NextGridCutOffTime { get; set; }

        public string IsFirstRun { get; set; }

        public DateTime LoggedAt { get; set; }
    }
}
