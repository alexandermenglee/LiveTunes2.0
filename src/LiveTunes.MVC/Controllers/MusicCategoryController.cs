using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveTunes.MVC.Data;
using LiveTunes.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveTunes.MVC.Controllers
{
    public class MusicCategoryController : Controller
    {
        private ApplicationDbContext _context;
        public MusicCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MusicCategory>> List()
        {
            return _context.MusicCategories.Where(x => true).ToList();
        }
        // GET: MusicCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}