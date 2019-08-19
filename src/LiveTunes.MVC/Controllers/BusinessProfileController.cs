using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using LiveTunes.MVC.ViewModels;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LiveTunes.MVC.Controllers
{
    public class BusinessProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessProfile
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BusinessProfiles.Include(b => b.User);
			SeedDatabase();
			return View(await applicationDbContext.ToListAsync());
        }

        // GET: BusinessProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BusinessProfileId == id);
            if (businessProfile == null)
            {
                return NotFound();
            }

            return View(businessProfile);
        }

        // GET: BusinessProfile/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: BusinessProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessProfileId,VenueId,BusinessName,UserId")] BusinessProfile businessProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", businessProfile.UserId);
            return View(businessProfile);
        }

        // GET: BusinessProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles.FindAsync(id);
            if (businessProfile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", businessProfile.UserId);
            return View(businessProfile);
        }

        // POST: BusinessProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessProfileId,VenueId,BusinessName,UserId")] BusinessProfile businessProfile)
        {
            if (id != businessProfile.BusinessProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessProfileExists(businessProfile.BusinessProfileId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", businessProfile.UserId);
            return View(businessProfile);
        }

        // GET: BusinessProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BusinessProfileId == id);
            if (businessProfile == null)
            {
                return NotFound();
            }

            return View(businessProfile);
        }

        // POST: BusinessProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessProfile = await _context.BusinessProfiles.FindAsync(id);
            _context.BusinessProfiles.Remove(businessProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessProfileExists(int id)
        {
            return _context.BusinessProfiles.Any(e => e.BusinessProfileId == id);
        }

		//**********************************************************
		//D3 Graph method

		public IActionResult BarGraph(int venueId)
		{
			return View();
		}

		public string CreateGraph(int id)
		{
			List<EventUserEngagement> aggregateEventWithHitsList = new List<EventUserEngagement>();

			var foundEvents = _context.Events.Where(e => Convert.ToInt32(e.VenueId) == id).ToList();
			foreach (var item in foundEvents)
			{
				EventUserEngagement eventsWithHits = new EventUserEngagement();
				var totalLikes = _context.Likes.Where(e => e.EventId == item.EventId).Count();
				var totalComments = _context.Comments.Where(e => e.EventId == item.EventId).Count();
				var totalUserEngagement = 0;
				totalUserEngagement = totalLikes + totalComments;
				eventsWithHits.EventName = item.EventName;
				eventsWithHits.EventDate = item.DateTime;
				eventsWithHits.UserEngagement = totalUserEngagement;
				aggregateEventWithHitsList.Add(eventsWithHits);
			}
			return JsonConvert.SerializeObject(aggregateEventWithHitsList);
		}

		public void SeedDatabase()
		{
			var eventCount = _context.Events.Count();
			var totalEvents = 5;
			if (eventCount == 0)
			{
				for (int i = 0; i < totalEvents; i++)
				{
					Event newEvent = new Event();
					newEvent.VenueId = 12345678;
					newEvent.Venue = "Hyatt";
					newEvent.Latitude = 43.039;
					newEvent.Longitude = -87.907;
					newEvent.EventName = $"Event{i}";
					newEvent.DateTime = DateTime.Now;
					_context.Events.Add(newEvent);
					_context.SaveChanges();
				}
			}
		}

	}
}
