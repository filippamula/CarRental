using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Data;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocalisationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalisationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalisationsController
        public ActionResult Index()
        {
            return View(_context.localisations.ToList());
        }

        // GET: LocalisationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalisationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Localisations localisation)
        {
            try
            {
                _context.Add(localisation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalisationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.localisations.ToList().FirstOrDefault(x => x.id_localisation == id));
        }

        // POST: LocalisationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Localisations localisation)
        {
            try
            {
                _context.Update(localisation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocalisationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.localisations.ToList().FirstOrDefault(x => x.id_localisation == id));
        }

        // POST: LocalisationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Localisations localisation)
        {
            try
            {
                _context.localisations.Remove(localisation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
