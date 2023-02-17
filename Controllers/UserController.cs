using CarRental.Areas.Identity.Data;
using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarRental.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;

        public UserController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: UserController
        public ActionResult Fleet()
        {
            return View(_context.cars
                .Include(t => t.type)
                .Include(l => l.localisation)
                .ToList());
        }

        public ActionResult Localisations()
        {
            return View(_context.localisations.ToList());
        }

        public ActionResult Available_cars(int id)
        {
            return View(_context.cars
                .Include(t => t.type)
                .Include(l => l.localisation)
                .Where(c => c.localisation.id_localisation == id)
                .ToList());
        }
 
        public ActionResult Reserve(int id)
        {
            return View(_context.cars.ToList().FirstOrDefault(x => x.id_car == id));
        }

        public async Task<ActionResult> ReserveConfirmation(int id, DateTime date_from, DateTime date_to)
        {
            Cars car = _context.cars.ToList().FirstOrDefault(x => x.id_car == id);
            if (date_from < DateTime.Now)
                return RedirectToAction(nameof(Error));
            if (date_to < date_from)
                return RedirectToAction(nameof(Fleet));

            foreach (var x in _context.rentals.ToList().Where(x => x.car == car))
            {
                if (date_from >= x.date_from && date_from <= x.date_to)
                    return RedirectToAction(nameof(Fleet));
                if (date_to <= x.date_to && date_to >= x.date_from)
                    return RedirectToAction(nameof(Fleet));
            }
            
            Rentals rental = new Rentals();
            rental.car = car;
            rental.date_from = date_from;
            rental.date_to = date_to;
            rental.customer = await _userManager.GetUserAsync(User);
            Payments payment = new Payments();
            payment.amount = (double)car.price_per_day * ((date_to - date_from).TotalDays);
            rental.payment = payment;
            _context.Add(payment);
            _context.SaveChanges();
            _context.Add(rental);
            _context.SaveChanges();

            return RedirectToAction(nameof(Reservations));
        }
        
        public async Task<ActionResult> Reservations()
        {
            Customer user = await _userManager.GetUserAsync(User);
            return View(
                _context.rentals
                .Include(u => u.customer)
                .Include(u => u.car)
                .Include(l => l.car.localisation)
                .Include(p => p.payment)
                .ToList()
                .Where(x => x.customer == user)
                );
        }

        public ActionResult Pay(int id)
        {
            Payments payment = _context.payments.ToList().FirstOrDefault(x => x.id_payment == id);
            payment.payment_date = DateTime.Now;
            _context.Update(payment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Reservations));
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
