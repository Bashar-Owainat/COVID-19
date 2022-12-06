using COVID_19_App.Models;
using COVID_19_App.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace COVID_19_App.covid19
{
    public class GetTotalStatistics : IGetTotalStatistics
    {
        public async Task<TotalStatistic> ReturnTotalStatistics()
        {
            using(var client = new HttpClient())
            {
                var url = new Uri($"https://api.covid19api.com/world/total");
                var response = await client.GetAsync(url);
                string json;

                using(var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<TotalStatistic>(json);
            }
        }
    }
}
