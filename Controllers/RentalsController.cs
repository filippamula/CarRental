using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Areas.Identity.Data;
using CarRental.Data;
using CarRental.Migrations;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using CarRental.Models;

namespace CarRental.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalsController
        public ActionResult Index()
        {
            return View(_context.rentals.ToList());
        }

        // GET: RentalsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rentals rental)
        {
            try
            {
                _context.Add(rental);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.rentals.ToList().FirstOrDefault(x => x.id_rental == id));
        }

        // POST: RentalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rentals rental)
        {
            try
            {
                _context.Update(rental);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.rentals.ToList().FirstOrDefault(x => x.id_rental == id));
        }

        // POST: RentalsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rentals rental)
        {
            try
            {
                _context.Remove(rental);
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
