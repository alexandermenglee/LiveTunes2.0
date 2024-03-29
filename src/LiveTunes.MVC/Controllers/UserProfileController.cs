﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveTunes.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        private ApplicationDbContext _context;
        public UserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);

            if (userProfile == null)
            {
                return RedirectToAction("Create","UserProfile");
                
            }
            else
            {
                return RedirectToAction("Index", new { id = userProfile.UserProfileId });
            }
        }

        // GET: UserProfile
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);
            
            return View(userProfile);
        }

        // GET: UserProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newUserProfile = _context.UserProfiles.FirstOrDefault(x => x.UserId == userId);

            if (newUserProfile != null)
            {
                return RedirectToAction("Create", "Survey");
            }

            return View();
        }

        // POST: UserProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserProfile profile)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newUserProfile = new UserProfile();
                
            newUserProfile.UserId = userId;
            newUserProfile.FirstName = profile.FirstName;
            newUserProfile.LastName = profile.LastName;

            _context.UserProfiles.Add(newUserProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Survey"); 
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.UserProfileId == id && x.UserId == userId);

            if (userProfile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProfile.UserId);
            
            return View(userProfile);
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