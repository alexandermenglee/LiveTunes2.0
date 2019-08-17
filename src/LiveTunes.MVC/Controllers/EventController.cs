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


			//if (context.Events.Count() <= 1)
			//{
			//	context.Events.Add(new Event { Latitude = 49.2746619, Longitude = -123.10921740000003, EventName = "King Gizzard and the Lizard Wizard", DateTime = DateTime.Now, Genre = "Post Punk" });
			//	context.Events.Add(new Event { Latitude = 49.2746619, Longitude = -123.0451041, EventName = "King Gizzard and the Lizard Wizard", DateTime = DateTime.Now, Genre = "Post Punk" });
			//}
			//context.SaveChangesAsync();
		}

        

        private double getDistance(Coordinates g1, Coordinates g2)
        {
           
            return g1.DistanceTo(g2);
        }

        public async Task<List<Event>> getEventsByDistance(Coordinate coordinate, double d)
        {
            var sCoord = new Coordinates(double.Parse(coordinate.Latitude), double.Parse(coordinate.Longitude));
            return await _context.Events.Where(x => getDistance(sCoord, new Coordinates(x.Latitude, x.Longitude)) < d).ToListAsync();
        }

        [HttpPost]
        public async Task<List<Event>> GetEventsByCoordinates(Coordinate coordinate)
        {
            List<Event> returnEvents = new List<Event>();
            try
            {
                var result = await client.GetStringAsync($"https://www.eventbriteapi.com/v3/events/search?location.longitude={coordinate.Longitude}&location.latitude={coordinate.Latitude}&expand=venue&location.within=50km&token={EventbriteAPIToken.Token}");
                var data = JsonConvert.DeserializeObject<JObject>(result);
                int ObjectCount = (int)data["pagination"]["object_count"];

                for (int j = 1; j <= (double)ObjectCount / 50; j++)
                {
                    result = await client.GetStringAsync($"https://www.eventbriteapi.com/v3/events/search?location.longitude={coordinate.Longitude}&location.latitude={coordinate.Latitude}&expand=venue&location.within=50km&token={EventbriteAPIToken.Token}&page={j}");

                    data = JsonConvert.DeserializeObject<JObject>(result);

                    var events = data["events"];

                    //for (int i = 0; i < (int)data["pageCount"]; i++) { Console.WriteLine(i); }
                    List<JToken> EVENTS = new List<JToken>();
                    EVENTS = data["events"].Where(e => (string)e["category_id"] == "103").ToList();

                    Event add = new Event();
                    for (int i = 0; i < EVENTS.Count; i++)
                    {
                        var eventFromDB = _context.Events.Where(e => e.EventbriteEventId.Equals((string)EVENTS[i]["id"])).FirstOrDefault();

                        if (eventFromDB != null)
                        {
                            returnEvents.Add(eventFromDB);
                            continue;
                        }

                        Event newEvent = new Event();

                        newEvent.EventName = (string)EVENTS[i]["name"]["text"];
                        newEvent.VenueId = (int)EVENTS[i]["venue"]["id"];
                        newEvent.Latitude = (double)EVENTS[i]["venue"]["latitude"];
                        newEvent.Longitude = (double)EVENTS[i]["venue"]["longitude"];
                        newEvent.EventbriteEventId = (string)EVENTS[i]["id"];
                        newEvent.Description = (string)EVENTS[i]["description"]["text"];
                        newEvent.DateTime = (DateTime)EVENTS[i]["start"]["local"];

                        returnEvents.Add(newEvent);

                        if ((string)EVENTS[i]["subcategory_id"] == null)
                        {
                            newEvent.Genre = 3019;
                        }
                        else
                        {
                            newEvent.Genre = int.Parse((string)EVENTS[i]["subcategory_id"]);
                        }

                        await _context.Events.AddAsync(newEvent);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (HttpRequestException e)
            {
                return null;
            }

            return returnEvents;
        }


        [HttpPost]
        public async Task<List<Event>> Handoff([FromBody] Coordinate coordinate)
        {
          //return await GetEventsByCoordinates(coordinate);
            return await getEventsByDistance(coordinate, 30);
        }

        public IActionResult Index()
        {
            return View();
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
            evnt.CommentCount = await _context.Comments.CountAsync(x => x.EventId == id);
            evnt.UserLiked = await _context.Likes.AnyAsync(x => x.EventId == id && x.UserId == userProfileId);
            evnt.Comments = await _context.Comments.Where(x => x.EventId == id).ToListAsync();

            return View(evnt);
        }

        //get by preferences
        public async Task List(Coordinate location)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfileId = _context.UserProfiles.Where(x => x.UserId == userId).FirstOrDefault().UserProfileId;
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);

            // get User Preferences
            // and query Event brite based on location
            // query returned data based on preferences
            return;
        }


        public async Task List(int GenreId, Coordinate location)
        {
            // api call to get List of events by genre and location
            return;
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (evnt == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
            var userProfileId = userProfile.UserProfileId;

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

        [HttpPost]
        public async Task<IActionResult> Comment(int id, string commentText)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (evnt == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
            var userProfileId = userProfile.UserProfileId;

            var newComment = new Comment();
            newComment.DateTime = DateTime.Now;
            newComment.UserId = userProfileId;
            newComment.EventId = evnt.EventId;
            newComment.CommentText = commentText;

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id });
        }
    }
}