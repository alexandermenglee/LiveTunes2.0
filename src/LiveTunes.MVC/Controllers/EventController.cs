using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiveTunes.MVC.Models;
using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using LiveTunes.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using LiveTunes.MVC.Class;

namespace LiveTunes.MVC.Controllers
{
    public class EventController : Controller
    {
        private static HttpClient client;
        private readonly ApplicationDbContext _context;
        /*public dynamic results;*/
        private Coordinate coordinates;

        /*public IEnumerable<Event> events;*/
        public EventController(ApplicationDbContext context)
        {
            client = new HttpClient();
            _context = context;


			/*if (context.Events.Count() <= 1)
			{
				context.Events.Add(new Event { Latitude = 49.2746619, Longitude = -123.10921740000003, EventName = "King Gizzard and the Lizard Wizard", DateTime = DateTime.Now, Genre = "Post Punk" });
				context.Events.Add(new Event { Latitude = 49.2746619, Longitude = -123.0451041, EventName = "King Gizzard and the Lizard Wizard", DateTime = DateTime.Now, Genre = "Post Punk" });
			}
			context.SaveChangesAsync();*/ /*Comment this back out*/
		}

        [HttpPost]
        static async Task<object> GetEventsByCoordinates(Coordinate coordinate)
        {
            try
            {   
                //EventBriteApi
                var result = await client.GetStringAsync($"https://www.eventbriteapi.com/v3/events/search?location.longitude={coordinate.Longitude}&location.latitude={coordinate.Latitude}&expand=venue&location.within=&token={EventbriteAPIToken.Token}");

                var data = JsonConvert.DeserializeObject<JObject>(result);
                var eventName = data["events"];
                return data;
            }
            catch (HttpRequestException e)
            {
                return e;
            }
        }

        public async void Handoff([FromBody] Coordinate coordinate)
        {
            await GetEventsByCoordinates(coordinate);
            RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {

            /*var results = await GetEvents();*/
            /*var events = await _context.Events.FirstOrDefaultAsync();*/
            var listOfGenres = await _context.MusicCategories.Where(x => true).ToListAsync();

            return View(listOfGenres);

        }

        

        public async Task<IActionResult> Details(int id)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (evnt == null) return NotFound();

            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfileId = _context.UserProfiles.Where(x => x.UserId == userId).FirstOrDefault().UserProfileId;
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
            ViewBag.UserFirstName = userProfile.FirstName;
            ViewBag.UserLastName = userProfile.LastName;


            evnt.LikeCount = await _context.Likes.CountAsync(x => x.EventId == id);
            evnt.UserLiked = await _context.Likes.AnyAsync(x => x.EventId == id && x.UserId == userProfileId);
            evnt.Comments = await _context.Comments.Where(x => x.EventId == id).ToListAsync();

            return View(evnt);
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (evnt == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
            // var userProfileId = userProfile.UserProfileId;
            var userProfileId = 2;

            var like = await _context.Likes.FirstOrDefaultAsync(x => x.UserId == userProfileId && x.EventId == id);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id });
            }

            like = new Like
            {
                EventId = id,
                UserId = userProfileId
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id });
        }
    }
}