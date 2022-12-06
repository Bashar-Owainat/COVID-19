using COVID_19_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace COVID_19_App.covid19
{
    public class GetSpecificSummary: IGetSpecificSummary
    {
        public async Task<CountrySummary> ReturnSpecificSummary(string ID)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://api.covid19api.com/summary");

                var response = await client.GetAsync(url);
                string json;

                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                var wholeSummary = JsonConvert.DeserializeObject<WholeSummary>(json);

                List<CountrySummary> countrySummaries = wholeSummary.Countries;

                CountrySummary countrySummary = countrySummaries.Find(c => c.Country == ID);
                Console.WriteLine(countrySummary.ID);

                return countrySummary;

            }

        }
    }
}
