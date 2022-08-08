using System;
using System.Collections.Generic;
using System.Linq;
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
            catch(Exception ex)
            {
                string st = ex.ToString();
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult GetDashboardData()
        {
            var result = dbContext.DashboardData.ToList().FirstOrDefault();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetGraphData(string input)
        {
            var lstGraphData = new List<GraphData>(5);
            if (input.ToUpper().Equals("avgSolarOutputWatts".ToUpper()) || input.ToUpper().Equals("avgLoadWatts".ToUpper()))
            {
                lstGraphData = GetAvgSolarOutputAndLoad(lstGraphData);
            }
            else if (input.ToUpper().Equals("solarGeneratedWh".ToUpper()) || input.ToUpper().Equals("powerConsumedWh".ToUpper()))
            {
                lstGraphData = GetSolarGeneratedAndConsumption(lstGraphData);
            }


            return Ok(lstGraphData);
        }


        private List<GraphData> GetAvgSolarOutputAndLoad(List<GraphData> lstGraphData)
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

        private List<GraphData> GetSolarGeneratedAndConsumption(List<GraphData> lstGraphData)
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

    }
}
