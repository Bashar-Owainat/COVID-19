using COVID_19_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace COVID_19_App.covid19
{
    public class GetCountryStats : IGetCountryStats
    {
       
        public async Task<List<CountryDTO>> ReturnCountryStats(string country, string fromDate, string toDate)
        {
           using(var client = new HttpClient())
           {
                var url = new Uri($"https://api.covid19api.com/country/{country}/status/confirmed?from={fromDate}&to={toDate}");
               


                var response = await client.GetAsync(url);
                string json;

                using(var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                List <CountryData> countries= JsonConvert.DeserializeObject<List<CountryData>>(json);
                List<CountryDTO> countryDTOs = countries.Select(c => new CountryDTO
                {
                    Cases = c.Cases,
                    Date = c.Date
                }).ToList();
                return countryDTOs;
           }
        }
    }
}
