using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models.Interfaces
{
   public interface ICountryStats
   {
        Task<List<CountryDTO>> GetCountryStats(string country, string fromDate, string toDate);

   }
}
