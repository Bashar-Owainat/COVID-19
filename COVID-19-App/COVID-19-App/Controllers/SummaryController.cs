using COVID_19_App.Models;
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
    public class SummaryController : ControllerBase
    {
        private readonly ISummary _summary;
      
        public SummaryController(ISummary summary)
        {
            _summary = summary;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetSummary()
        {
            var result = await _summary.GetSummary();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSummary(SummaryDTO summaryDTO)
        {
            SummaryDTO newSummary = await _summary.AddSummary(summaryDTO);
            return Ok(newSummary);
        }

        [HttpDelete("{name}")]
        [Route("delete")]
        public async Task<IActionResult> DeleteSummary(string name)
        {
            await _summary.DeleteSummary(name);

            return NoContent();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<IEnumerable<SummaryDTO>>> GetSummariesFromDB()
        {
            var summaries = await _summary.GetSummariesFromDB();
            return Ok(summaries);
        }
    }
}
