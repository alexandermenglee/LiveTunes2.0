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
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comment
        public async Task<IActionResult> Index(int eventId)
        {
            var applicationDbContext = _context.Comments.Include(c => c.Event).Include(c => c.UserProfile);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Event)
                .Include(c => c.UserProfile)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comment/Create
        /*public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId");
            return View();
        }*/

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,CommentText,DateTime,UserId,EventId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                var applicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == applicationUserId);
                
                comment.UserId = userProfile.UserProfileId;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", comment.EventId);
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId", comment.UserId);
            return View(comment);
        }*/

        [HttpGet]
        public async Task Create( int EventId, string text )
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfileId = _context.UserProfiles.Where(x => x.UserId == userid).FirstOrDefault().UserProfileId;

            Comment createComment = new Comment();
            createComment.CommentText = text;
            createComment.EventId = EventId;
            createComment.UserId = userProfileId;

            _context.Comments.Add(createComment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> List( int id )
        {
            var comments = _context.Comments.Where(x => x.EventId == id);
            return await comments.ToListAsync();
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", comment.EventId);
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId", comment.UserId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,CommentText,DateTime,UserId,EventId")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", comment.EventId);
            ViewData["UserId"] = new SelectList(_context.UserProfiles, "UserProfileId", "UserProfileId", comment.UserId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Event)
                .Include(c => c.UserProfile)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
