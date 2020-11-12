using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Power_Monitoring.Models;
using Power_Monitoring.Data;
using Power_Monitoring.ViewModels;


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
            var bands = context.FavoriteBands.Include(user => user.Fans).ToList();
            var years = bands.SelectMany(m => m.Fans).Select(f => f.Year).Distinct();
            var viewYearModel = new BandYearModel()
            {
                BandModels = new List<BandModel>(),
                Years = years.ToList()
            };

            foreach (var band in bands)
            {
                var model = new BandModel
                {
                    Name = $"{band.FirstName} {band.SecondName}", Years = new int[years.Count()].ToList()
                };
                for (var y = 0; y < years.Count(); y++)
                {
                    var year = years.ToArray()[y];
                    model.Years[y] = band.Fans.Where(f => f.Year == year).Select(m => m.FansCount)
                        .FirstOrDefault();
                }
                viewYearModel.BandModels.Add(model);
            }
            return View(viewYearModel);
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
