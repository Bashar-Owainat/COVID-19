using COVID_19_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Covid19MVC.Controllers
{
    public class SummaryController : Controller
    {
        string baseUrl = "http://localhost:33902/";

        private readonly ILogger<SummaryController> _logger;

        public SummaryController(ILogger<SummaryController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Summary> list = new List<Summary>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("api/summary");

                if (getData.IsSuccessStatusCode)
                {
                    var result = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Summary>>(result);
                }
                else
                {
                    Console.WriteLine("An Error occured while calling the Api");
                }
                return View(list);
            }
        }

        public ActionResult Delete(string Name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("delete/" + Name);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
