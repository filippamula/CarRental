using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarRental.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
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

        public ActionResult ReserveConfirmation(int id, DateTime date_from, DateTime date_to)
        {
            Cars car = _context.cars.ToList().FirstOrDefault(x => x.id_car == id);
            if (date_from > DateTime.Now)
                return Reserve(id);

            return Fleet();
        }
    }
}
