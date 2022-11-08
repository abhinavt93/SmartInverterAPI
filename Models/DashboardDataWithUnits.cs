using System;
namespace SmartInverterAPI.Models
{
    public class DashboardDataWithUnits : DashboardData
    {
        public DashboardDataWithUnits(DashboardData dashboardData)
        {
            if(dashboardData != null)
            {
                this.BatteryPerc = dashboardData.BatteryPerc;
                this.CurrentLoadWatts = dashboardData.CurrentLoadWatts;
                this.CurrentSolarOutputWatts = dashboardData.CurrentSolarOutputWatts;

                this.CustomerID = dashboardData.CustomerID;
                this.LoggedAt = dashboardData.LoggedAt;
                this.PowerConsumedPerDay = dashboardData.PowerConsumedPerDay;

                this.PowerConsumedThisMonth = dashboardData.PowerConsumedThisMonth;
                this.PowerConsumedToday = dashboardData.PowerConsumedToday;
                this.PowerGeneratedPerDay = dashboardData.PowerGeneratedPerDay;

                this.PowerGeneratedThisMonth = dashboardData.PowerGeneratedThisMonth;
                this.PowerGeneratedToday = dashboardData.PowerGeneratedToday;
                this.PowerSource = dashboardData.PowerSource;
            }

        }
        public string PowerGeneratedThisMonthUnit { get; set; }

        public string PowerConsumedThisMonthUnit { get; set; }

        public string PowerGeneratedTodayUnit { get; set; }

        public string PowerConsumedTodayUnit { get; set; }

        public string PowerGeneratedPerDayUnit { get; set; }

        public string PowerConsumedPerDayUnit { get; set; }

        public string BatteryPercUnit { get; set; }

        public string CurrentLoadWattsUnit { get; set; }

        public string CurrentSolarOutputWattsUnit { get; set; }

    }
}
