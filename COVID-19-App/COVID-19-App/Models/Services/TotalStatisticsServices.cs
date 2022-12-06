using COVID_19_App.covid19;
using COVID_19_App.Models;
using COVID_19_App.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Services
{
    public class TotalStatisticsServices : ITotalStatistics 
    {
        private static IGetTotalStatistics _getTotalStatistics;
        public TotalStatisticsServices(IGetTotalStatistics getTotalStatistics)
        {
            _getTotalStatistics = getTotalStatistics;
        }

        public async Task<TotalStatistic> GetTotalStatistics()
        {
            return await _getTotalStatistics.ReturnTotalStatistics();
        }
    }
}
