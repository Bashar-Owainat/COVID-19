using COVID_19_App.covid19;
using COVID_19_App.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models.Services
{
    public class CountryStatsServices : ICountryStats
    {
        private static IGetCountryStats _getCountryStats;

        public CountryStatsServices(IGetCountryStats getCountryStats)
        {
            _getCountryStats = getCountryStats;
        }
        public async Task<List<CountryDTO>> GetCountryStats(string country, string fromDate, string toDate)
        {
            return await _getCountryStats.ReturnCountryStats(country, fromDate, toDate);
        }
    }
}
