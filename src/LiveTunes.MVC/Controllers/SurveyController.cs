using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveTunes.MVC.Models;
using LiveTunes.MVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace LiveTunes.MVC.Controllers
{
    public class SurveyController : Controller
    {
        private ApplicationDbContext _context;
        private HttpClient client;

        //private JToken suggestedSongs;
        public SurveyController(ApplicationDbContext context)
        {
            client = new HttpClient();
            _context = context;
        }

        // GET: Survey
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);
            var surveyList = _context.Surveys.Where(x => x.UserId == userProfile.UserProfileId).ToList();
            return View(surveyList);
        }
        
        // GET: Survey/Create
        public ActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);
            var newsurvey = _context.Surveys.FirstOrDefault(x => x.UserId == userProfile.UserProfileId);

            if (newsurvey != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Survey survey)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);
            var newSurvey = _context.Surveys.FirstOrDefault(x => x.UserId == userProfile.UserProfileId);

            newSurvey.ArtistName = survey.ArtistName;
            newSurvey.FavoriteGenre1 = survey.FavoriteGenre1;
            newSurvey.FavoriteGenre2 = survey.FavoriteGenre2;
            newSurvey.FavoriteGenre3 = survey.FavoriteGenre3;
            newSurvey.UserId = userProfile.UserProfileId;

            await _context.AddAsync(newSurvey);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Event");
        }
    }
}