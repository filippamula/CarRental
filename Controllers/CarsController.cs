using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Areas.Identity.Data;
using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            return View(_context.cars
                .Include(t => t.type)
                .Include(l => l.localisation)
                .ToList());
        }


        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars car)
        {
            car.localisation = _context.localisations.ToList().FirstOrDefault(x => x.id_localisation == car.localisation.id_localisation);
            car.type = _context.types.ToList().FirstOrDefault(x => x.id_type == car.type.id_type);
            try
            {
                _context.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cars car)
        {
            try
            {
                _context.Update(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cars car)
        {
            try
            {
                _context.Remove(car);
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
