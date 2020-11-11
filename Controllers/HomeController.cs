using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Power_Monitoring.Models;
using Power_Monitoring.Data;



namespace Power_Monitoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
            public User viewModel = new User();

        private readonly PowerMonitoringContext context;


        public HomeController(ILogger<HomeController> logger, PowerMonitoringContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            Console.WriteLine(viewModel.FirstName);
            return View(context.FavoriteBands.FirstOrDefault());
        }

        public IActionResult Privacy()
        {
            ViewBag.Data = $"'{context.FavoriteBands.FirstOrDefault()?.FirstName}','{context.FavoriteBands.FirstOrDefault()?.SecondName}','Value2','Value3'"; //list of strings that you need to show on the chart. as mentioned in the example from c-sharpcorner
            ViewBag.ObjectName = "'1','14','17','17'";
            return View();
        }

        public IActionResult About()
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
