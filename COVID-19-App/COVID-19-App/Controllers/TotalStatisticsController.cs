using COVID_19_App.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Controllers
{
   
    public class TotalStatisticsController : ControllerBase
    {
        private readonly ITotalStatistics _TotalStatistics;

        public TotalStatisticsController(ITotalStatistics TotalStatistics)
        {
            _TotalStatistics = TotalStatistics;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetTotalStatistics()
        {
            var result = await _TotalStatistics.GetTotalStatistics();
            return Ok(result);
        }
    }
}
