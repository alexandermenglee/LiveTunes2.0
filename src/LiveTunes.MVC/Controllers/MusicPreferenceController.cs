using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace LiveTunes.MVC.Controllers
{
    public class MusicPreferenceController : Controller
    {
        private HttpClient client;
        private ApplicationDbContext _context;

        public MusicPreferenceController(ApplicationDbContext context)
        {
            client = new HttpClient();
            // GetSongs("Rock");
            _context = context;
        }

        // public async void GetSongs(string genre)
        // {
        //     client.DefaultRequestHeaders.Add(new MediaTypeWithQualityHeaderValue("jsonp"));
        //     HttpResponseMessage response = await client.GetAsync("http://itunes.apple.com/search?term=Jack+Johnson?callback=?");
        //     suggestedSongs = await response.Content.ReadAsAsync<String>();
        // }

        //Main View Where it Goes thru songs based on genres they like
        public async Task<ActionResult> Index()
        {
            List<MusicPreference> suggestedSongs = await GetPreferences();

            //TODO: List of all suggested songs
            return View(suggestedSongs);
        }

        public async Task Create(string artist, string songName, string genre)
        {
            MusicPreference preference = new MusicPreference();
            preference.SongName = songName;
            preference.ArtistName = artist;
            preference.Genre = genre;
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.UserProfiles.Where(x => x.UserId == userid).FirstOrDefaultAsync();
            preference.UserId = user.UserProfileId;
            preference.User = user;
            await _context.MusicPreferences.AddAsync(preference);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<MusicPreference>> GetPreferences() {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.UserProfiles.Where(x => x.UserId == userid).FirstOrDefaultAsync();
            var musicPreferenceData = _context.MusicPreferences.Where(x => x.UserId == user.UserProfileId);
            //JArray data = new JArray(musicPreferenceData);
            return musicPreferenceData.ToList();
        }

        public ActionResult SongSamples()
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var userProfileId = _context.UserProfiles.Where(x => x.UserId == userId).FirstOrDefault();
			var survey = _context.Surveys.Where(s => s.UserId == userProfileId.UserProfileId).Single();
			return View();
        }

        //Will write Some Jquery to go along with this
        //Pretty Much adding the song liked to MusicPreferences table
        [HttpPost]
        public async Task Like([FromBody] MusicPreference likedSong)
        {
            await _context.MusicPreferences.AddAsync(likedSong);
            await _context.SaveChangesAsync();
        }

        // GET: MusicPreference/Details/5
        // Would get music preferences by percentage of genre
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}