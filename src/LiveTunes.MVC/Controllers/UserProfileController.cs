using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveTunes.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private ApplicationDbContext _context;
        public UserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            //UserProfile add = new UserProfile();
            
            return View();
        }

        // POST: UserProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserProfile profile)
        {
            UserProfile add = new UserProfile();
            add.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            add.FirstName = profile.FirstName;
            add.LastName = profile.LastName;
            _context.UserProfiles.Add(add);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); ;
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            /*try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
            return View();
        }

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfile/Delete/5
        
    }
}