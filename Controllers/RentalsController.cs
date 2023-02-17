using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Areas.Identity.Data;
using CarRental.Data;
using CarRental.Migrations;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

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
            return View(_context.rentals
                .Include(u => u.customer)
                .Include(c => c.car)
                .Include(p => p.payment)
                .ToList());
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
            
            rental.customer = _context.customers.ToList().FirstOrDefault(x => x.Id == rental.customer.Id);
            rental.car = _context.cars.ToList().FirstOrDefault(x => x.id_car == rental.car.id_car);
            rental.payment = _context.payments.ToList().FirstOrDefault(x => x.id_payment == rental.payment.id_payment);
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
            var rentalDB = _context.rentals.ToList().FirstOrDefault(x => x.id_rental == id);
            rentalDB.customer = _context.customers.ToList().FirstOrDefault(x => x.Id == rental.customer.Id);
            rentalDB.car = _context.cars.ToList().FirstOrDefault(x => x.id_car == rental.car.id_car);
            rentalDB.payment = _context.payments.ToList().FirstOrDefault(x => x.id_payment == rental.payment.id_payment);
            rentalDB.date_from = rental.date_from;
            rentalDB.date_to = rental.date_to;
            try
            {
                _context.Update(rentalDB);
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
