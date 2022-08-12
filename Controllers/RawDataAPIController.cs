using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartInverterAPI.Data;
using SmartInverterAPI.Models;

namespace SmartInverterAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RawDataAPIController : ControllerBase
    {

        private readonly ILogger<RawDataAPIController> _logger;
        private InverterContext dbContext;

        public RawDataAPIController(ILogger<RawDataAPIController> logger)
        {
            _logger = logger;
            dbContext = new InverterContext();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessRawData(RawData data)
        {
            try
            {
                await dbContext.RawData.AddAsync(data);
                await dbContext.SaveChangesAsync();

                var pSolarOutputWatts = new SqlParameter("@SolarOutputWatts", data.SolarOutputWatts);
                var pSolarGeneratedWh = new SqlParameter("@SolarGeneratedWh", data.SolarGeneratedWh);
                var pLoadWatts = new SqlParameter("@LoadWatts", data.LoadWatts);
                var pConsumptionWh = new SqlParameter("@ConsumptionWh", data.ConsumptionWh);
                var pBatteryPerc = new SqlParameter("@BatteryPerc", data.BatteryPerc);
                var pPowerSource = new SqlParameter("@PowerSource", data.PowerSource);
                var pLoggedAt = new SqlParameter("@LoggedAt", data.LoggedAt);
                var pTimeIntervalSec = new SqlParameter("@TimeIntervalSec", data.TimeIntervalSec);
                var pCustomerID = new SqlParameter("@CustomerID", data.CustomerID);

                await dbContext.Database.ExecuteSqlRawAsync("EXEC spProcessRawData @SolarOutputWatts, @SolarGeneratedWh, @LoadWatts, @ConsumptionWh, @BatteryPerc, @PowerSource, @LoggedAt, @TimeIntervalSec, @CustomerID"
                    , pSolarOutputWatts, pSolarGeneratedWh, pLoadWatts, pConsumptionWh, pBatteryPerc, pPowerSource, pLoggedAt, pTimeIntervalSec, pCustomerID
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                string st = ex.ToString();
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult GetDashboardData()
        {
            var dashboardData = new DashboardDataWithUnits(dbContext.DashboardData.ToList().FirstOrDefault());
            var result = getFormattedValuesAndUnits(dashboardData);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGraphData(string input)
        {
            var lstGraphData = new List<GraphData>(5);
            if (input.ToUpper().Equals("avgSolarOutputWatts".ToUpper()) || input.ToUpper().Equals("avgLoadWatts".ToUpper()))
            {
                lstGraphData = getAvgSolarOutputAndLoad(lstGraphData);
            }
            else if (input.ToUpper().Equals("solarGeneratedWh".ToUpper()) || input.ToUpper().Equals("powerConsumedWh".ToUpper()))
            {
                lstGraphData = getSolarGeneratedAndConsumption(lstGraphData);
            }
            else if (input.ToUpper().Equals("inputbatteryPerc".ToUpper()) || input.ToUpper().Equals("inputbatteryPerc".ToUpper()))
            {
                lstGraphData = getBatteryUsageData(lstGraphData);
            }

            return Ok(lstGraphData);
        }

        [HttpGet]
        public IActionResult GetUserDataAndConfig(int customerID)
        {
            var result = dbContext.UserDataAndConfig.Where(s => s.CustomerID == customerID).ToList().FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult UpdateNextGridCutOffTime(UserDataAndConfig userData)
        {
            dbContext.UserDataAndConfig.Attach(userData);
            dbContext.Entry(userData).Property(x => x.NextGridCutOffTime).IsModified = true;
            dbContext.Entry(userData).Property(x => x.IsNextGridCutOffTimeUpdated).IsModified = true;
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateIsFirstRun(UserDataAndConfig userData)
        {
            dbContext.UserDataAndConfig.Attach(userData);
            dbContext.Entry(userData).Property(x => x.IsFirstRun).IsModified = true;
            dbContext.SaveChanges();

            return Ok();
        }

        private List<GraphData> getAvgSolarOutputAndLoad(List<GraphData> lstGraphData)
        {
            GraphData graphData = new GraphData();
            graphData.TitleMain = "Average Solar Power (Watts)";
            graphData.DataMain = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgSolarOutputWatts).ToList();
            graphData.Label = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ':' + s.Minute.ToString("D2")).ToList();
            graphData.TitleSecondary = "Average Load (Watts)";
            graphData.DataSecondary = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgLoadWatts).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Average Solar Power (Watts)";
            graphData.DataMain = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgSolarOutputWatts).ToList();
            graphData.Label = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ":00").ToList();
            graphData.TitleSecondary = "Average Load (Watts)";
            graphData.DataSecondary = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgLoadWatts).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Average Solar Power (Watts)";
            graphData.DataMain = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgSolarOutputWatts).ToList();
            graphData.Label = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("dd-MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Average Load (Watts)";
            graphData.DataSecondary = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgLoadWatts).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Average Solar Power (Watts)";
            graphData.DataMain = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgSolarOutputWatts).ToList();
            graphData.Label = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Average Load (Watts)";
            graphData.DataSecondary = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgLoadWatts).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Average Solar Power (Watts)";
            graphData.DataMain = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgSolarOutputWatts).ToList();
            graphData.Label = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Year.ToString()).ToList();
            graphData.TitleSecondary = "Average Load (Watts)";
            graphData.DataSecondary = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.AvgLoadWatts).ToList();
            lstGraphData.Add(graphData);

            return lstGraphData;
        }

        private List<GraphData> getSolarGeneratedAndConsumption(List<GraphData> lstGraphData)
        {
            GraphData graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ':' + s.Minute.ToString("D2")).ToList();
            graphData.TitleSecondary = "Consumption (Wh)";
            graphData.DataSecondary = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.ConsumptionWh).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ":00").ToList();
            graphData.TitleSecondary = "Consumption (Wh)";
            graphData.DataSecondary = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.ConsumptionWh).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("dd-MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Consumption (Wh)";
            graphData.DataSecondary = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.ConsumptionWh).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Consumption (Wh)";
            graphData.DataSecondary = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.ConsumptionWh).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Year.ToString()).ToList();
            graphData.TitleSecondary = "Consumption (Wh)";
            graphData.DataSecondary = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.ConsumptionWh).ToList();
            lstGraphData.Add(graphData);

            return lstGraphData;
        }

        private List<GraphData> getBatteryUsageData(List<GraphData> lstGraphData)
        {
            GraphData graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ':' + s.Minute.ToString("D2")).ToList();
            graphData.TitleSecondary = "Battery (%)";
            graphData.DataSecondary = dbContext.LastHourData.OrderBy(s => s.LoggedAt)
                .Select(s => s.BatteryPerc).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Hour.ToString("D2") + ":00").ToList();
            graphData.TitleSecondary = "Battery (%)";
            graphData.DataSecondary = dbContext.LastDayData.OrderBy(s => s.LoggedAt)
                .Select(s => s.BatteryPerc).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("dd-MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Battery (%)";
            graphData.DataSecondary = dbContext.LastMonthData.OrderBy(s => s.LoggedAt)
                .Select(s => s.BatteryPerc).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.LoggedAt.ToString("MMM-yyyy")).ToList();
            graphData.TitleSecondary = "Battery (%)";
            graphData.DataSecondary = dbContext.LastYearData.OrderBy(s => s.LoggedAt)
                .Select(s => s.BatteryPerc).ToList();
            lstGraphData.Add(graphData);

            graphData = new GraphData();
            graphData.TitleMain = "Solar Power Generated (Wh)";
            graphData.DataMain = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.SolarGeneratedWh).ToList();
            graphData.Label = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.Year.ToString()).ToList();
            graphData.TitleSecondary = "Battery (%)";
            graphData.DataSecondary = dbContext.LastDecadeData.OrderBy(s => s.LoggedAt)
                .Select(s => s.BatteryPerc).ToList();
            lstGraphData.Add(graphData);

            return lstGraphData;
        }

        private DashboardDataWithUnits getFormattedValuesAndUnits(DashboardDataWithUnits dashboardData)
        {
            string unit = "";
            dashboardData.CurrentLoadWatts = formattingByUnits(ref unit, dashboardData.CurrentLoadWatts);
            dashboardData.CurrentLoadWattsUnit = unit + "W";

            dashboardData.CurrentSolarOutputWatts = formattingByUnits(ref unit, dashboardData.CurrentSolarOutputWatts);
            dashboardData.CurrentSolarOutputWattsUnit = unit + "W";

            dashboardData.PowerConsumedPerDay = formattingByUnits(ref unit, dashboardData.PowerConsumedPerDay);
            dashboardData.PowerConsumedPerDayUnit = unit + "Wh";

            dashboardData.PowerConsumedThisMonth = formattingByUnits(ref unit, dashboardData.PowerConsumedThisMonth);
            dashboardData.PowerConsumedThisMonthUnit = unit + "Wh";

            dashboardData.PowerConsumedToday = formattingByUnits(ref unit, dashboardData.PowerConsumedToday);
            dashboardData.PowerConsumedTodayUnit = unit + "Wh";

            dashboardData.PowerGeneratedPerDay = formattingByUnits(ref unit, dashboardData.PowerGeneratedPerDay);
            dashboardData.PowerGeneratedPerDayUnit = unit + "Wh";

            dashboardData.PowerGeneratedThisMonth = formattingByUnits(ref unit, dashboardData.PowerGeneratedThisMonth);
            dashboardData.PowerGeneratedThisMonthUnit = unit + "Wh";

            dashboardData.PowerGeneratedToday = formattingByUnits(ref unit, dashboardData.PowerGeneratedToday);
            dashboardData.PowerGeneratedTodayUnit = unit + "Wh";

            dashboardData.BatteryPercUnit = "%";
            return dashboardData;
        }

        private decimal formattingByUnits(ref string unit, decimal input)
        {
            if (input >= 1000000000)
            {
                input = input / 1000000000.0m;
                unit = "G";
                return Math.Round(input, 2);
            }
            else if (input >= 1000000)
            {
                input = input / 1000000.0m;
                unit = "M";
                return Math.Round(input, 2);
            }
            else if (input >= 1000)
            {
                input = input / 1000.0m;
                unit = "k";
                return Math.Round(input, 2);
            }

            unit = "";
            return input;
        }
    }
}
