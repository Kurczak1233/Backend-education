﻿using EntiryFramework.Database;
using EntiryFramework.Database.Repositiories.SettingsRepository;
using EntityFramework.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly ILogger<HomeController> _logger;
        private readonly EntityFrameworkDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, EntityFrameworkDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            //signInManager.SignInAsync(user,false,"Haslo") //Przykład użycia.
        }
        //private readonly IServiceProvider _serviceProvider;
        //public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider)
        //{
        //    _logger = logger;
        //    _serviceProvider = serviceProvider;
        //}

        public async Task<IActionResult> Index()
        {
            var repository = new SettingsRepository(_db);
            repository.UpdateSettings(new Setting
            {
                Name = "TextColor",
                Value = "Black"

            });
            var settings = repository.GetAllSettings();
            return Ok(settings);
            //var user = new ApplicationUser()
            //{
            //    FirstName = "Michał2",
            //    LastName = "Kupczak1",
            //    PhoneNumber = "5555555",
            //    UserName = "Kuczak12333",
                
            //};
            //var result = await _userManager.CreateAsync(user, "123456"); //Tutaj dodawany jest użytkownik do bazy i baza jest zapisywana.
            //if(result.Succeeded)
            //{
            //    return View();
            //}
            //else
            //{
            //    return Ok("Nie udało się stworzyć użytkownika");
            //}
            //var database = _serviceProvider.GetService(typeof(EntityFrameworkDbContext)) as EntityFrameworkDbContext;
            //var settingsTable = database.Settings;
            ////var newSettings = new Setting()
            ////{
            ////    Name = "Background",
            ////    Value = "Black",
            ////};

            ////Usuwanie rekordu

            //var firstBackGroundSettings = settingsTable.Where(c => c.Name == "Background").FirstOrDefault();
            //settingsTable.Remove(firstBackGroundSettings);
            ////settingsTable.Add(newSettings);
            //database.SaveChanges();
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
