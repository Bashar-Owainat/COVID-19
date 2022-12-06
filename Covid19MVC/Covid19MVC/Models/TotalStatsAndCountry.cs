using COVID_19_App.Models;
using Covid19MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19MVC.Models
{
    public class TotalStatsAndCountry
    {
         
            public List<StatsDTO> totalStatistic { get; set; }
            public List<CountryDTO> countryDTOs { get; set; }
    }
}
