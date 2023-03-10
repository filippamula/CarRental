using CarRental.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CarRental.Controllers
{
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guest
        public ActionResult Index()
        {
            return View(_context.cars.ToList());
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.cars
                .Include(t => t.type)
                .Include(l => l.localisation)
                .FirstOrDefault(x => x.id_car == id));
        }
    }
}
