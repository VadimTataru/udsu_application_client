using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using udsu_application_client.APIServices;
using udsu_application_client.Models;

namespace udsu_application_client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Country> Countries;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(Countries == null)
            {
                //Получить все страны https://localhost:44336/api/country
                GetData();                
            }
            ViewBag.CountryList = Countries;

            //Получить дефолтные данные о ковиде по России

            return View();
        }

        [HttpPost]
        public IActionResult Index(string country, DateTime date_from, DateTime date_to)
        {
            GetData();
            ViewBag.Data = string.Format("data is: {0}, {1}, {2}", country, date_from.ToString("yyyy-MM-ddTHH:mm:ssZ"), date_to.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            ViewBag.CountryList = Countries;
            return View();
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

        public void GetData()
        {
            var request = new RequestToAPI("https://localhost:44336/api/country");
            request.RunGet();
            var response = request.Response;
            var json = JArray.Parse(response);
            Countries = JsonConvert.DeserializeObject<List<Country>>(json.ToString());
        }
    }
}
