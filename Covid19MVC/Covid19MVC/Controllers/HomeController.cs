using Covid19MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Data;
using COVID_19_App.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Http;

namespace Covid19MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //string country, fromDate, toDate; 

        string baseUrl = "http://localhost:33902/";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public async Task<ActionResult> Index()
        {
            //calling the web api

            TotalStatistic TotalStatsData = new TotalStatistic();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("");

                if (getData.IsSuccessStatusCode)
                {
                    var result = getData.Content.ReadAsStringAsync().Result;
                    TotalStatsData = JsonConvert.DeserializeObject<TotalStatistic>(result);
                }
                else
                {
                    Console.WriteLine("An Error occured while calling the Api");
                }
                List<StatsDTO> statsDTOs = new List<StatsDTO>();
                statsDTOs.Add(new StatsDTO { Name = "TotalConfirmed", Value = TotalStatsData.TotalConfirmed });

                statsDTOs.Add(new StatsDTO { Name = "TotalDeaths", Value = TotalStatsData.TotalDeaths });

                statsDTOs.Add(new StatsDTO { Name = "TotalRecovered", Value = TotalStatsData.TotalRecovered });

                return View(statsDTOs);


            }
      
            
        }

      

        public async Task<IActionResult> Country(string Country, string FromDate, string ToDate)
        {
            //calling the web api
            List<CountryDTO> CountryData = new List<CountryDTO>();

            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(baseUrl);
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData2 = await client2.GetAsync("api/countrystats/"+ Country + "/"+ FromDate + "/"+ ToDate);
             

                if (getData2.IsSuccessStatusCode)
                {
                    var result2 = getData2.Content.ReadAsStringAsync().Result;
                    CountryData = JsonConvert.DeserializeObject<List<CountryDTO>>(result2);
                }
                else
                {
                    Console.WriteLine("An Error occured while calling the Api");
                }


             return View(CountryData);
            }
        }

        public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    } 

