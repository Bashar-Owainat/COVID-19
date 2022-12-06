using COVID_19_App.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryStatsController : ControllerBase
    {
        private readonly ICountryStats _countryStats;

        public CountryStatsController(ICountryStats countryStats)
        {
            _countryStats = countryStats;
        }


        [HttpGet("{country}/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetCountryStats(string country, string fromDate, string toDate)
        {
            var result = await _countryStats.GetCountryStats(country, fromDate, toDate);
            return Ok(result);
        }
        
    }
}
