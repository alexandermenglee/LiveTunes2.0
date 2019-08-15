using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using System.Security.Claims;

namespace LiveTunes.MVC.Controllers
{
    public class LikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Like
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Likes.Include(l => l.Event).Include(l => l.UserProfile);
            return View(await applicationDbContext.ToListAsync());
        }

        // public async Task<IActionResult> Details(int? id)
        // {
        //     Event e;
        //     e = await _context.Events.Where(x => x.EventId == id).FirstOrDefaultAsync();
        //     var likes = _context.Likes.Where(x => x.EventId == id);
        //     return View(likes);
        // }
        // GET: Like/Create
        /*public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId");
            return View();
        }*/


        [HttpGet, ActionName("dolike")]
        public async Task Create(int id)
        {
            Event likedEvent = _context.Events.Where(x => x.EventId == id).FirstOrDefault();
            if (likedEvent != null)
            {
                await Delete(id);
                return;
            }
            Like likeObject = new Like();
            likeObject.EventId = id;
            likeObject.Event = likedEvent;
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.Where(x => x.UserId == userid).FirstOrDefault();
            likeObject.UserId = userProfile.UserProfileId;

            //forget how to do this
            // likeObject.UserId;
            if (ModelState.IsValid)
            {
                _context.Likes.Add(likeObject);
                await _context.SaveChangesAsync();

            }
        }

        private async Task Delete(int? id)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfileId = _context.UserProfiles.Where(x => x.UserId == userid).FirstOrDefault().UserProfileId;
            var removeLike = await _context.Likes.Where(x => x.UserId == userProfileId && x.EventId == id).FirstOrDefaultAsync();
            _context.Likes.Remove(removeLike);
            await _context.SaveChangesAsync();
        }

        // GET: Like/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", like.EventId);
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId", like.UserId);
            return View(like);
        }

        // POST: Like/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        // POST: Like/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikeExists(int id)
        {
            return _context.Likes.Any(e => e.LikeId == id);
        }
    }
}
