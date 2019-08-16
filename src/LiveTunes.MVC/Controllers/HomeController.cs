using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiveTunes.MVC.Models;
using LiveTunes.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace LiveTunes.MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext a)
        {
            //using (var transaction = a.Database.BeginTransaction())
            //{
            //    a.MusicCategories.Add(new Models.MusicCategory(3001, "Alternative"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3002, "Blues & Jazz"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3003, "Classical"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3004, "Country"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3005, "Cultural"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3006, "EDM / Electronic"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3007, "Folk"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3008, "Hip Hop / Rap"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3009, "Indie"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3010, "Latin"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3011, "Metal"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3012, "Opera"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3013, "Pop"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3014, "R&B"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3015, "Reggae"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3016, "Religious/Spirtual"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3017, "Rock"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3018, "Top 40"));
            //    a.MusicCategories.Add(new Models.MusicCategory(3019, "Other"));

            //    a.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MusicCategories ON;");
            //    a.SaveChanges();
            //    a.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MusicCategories OFF");
            //    transaction.Commit();
            //}
        }
        public IActionResult Index()
        {
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
