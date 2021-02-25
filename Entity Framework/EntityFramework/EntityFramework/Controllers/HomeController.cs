using EntiryFramework.Database;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        //private readonly EntityFrameworkDbContext _db; PIERWSZA OPCJA LEPSZA!
        //public HomeController(EntityFrameworkDbContext db)
        //{
        //    _db = db;        
        //}
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceProvider _serviceProvider;
        public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            var database = _serviceProvider.GetService(typeof(EntityFrameworkDbContext)) as EntityFrameworkDbContext;
            var settingsTable = database.Settings;
            //var newSettings = new Setting()
            //{
            //    Name = "Background",
            //    Value = "Black",
            //};

            //Usuwanie rekordu

            var firstBackGroundSettings = settingsTable.Where(c => c.Name == "Background").FirstOrDefault();
            settingsTable.Remove(firstBackGroundSettings);
            //settingsTable.Add(newSettings);
            database.SaveChanges();
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
    }
}
