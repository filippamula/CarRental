using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Data;
using CarRental.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypesController
        public ActionResult Index()
        {
            return View(_context.types.ToList());
        }


        // GET: TypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Types typee)
        {
            try
            {
                _context.types.Add(typee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.types.ToList().FirstOrDefault(x => x.id_type == id));
        }

        // POST: TypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Types typee)
        {
            try
            {
                _context.types.Update(typee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.types.ToList().FirstOrDefault(x => x.id_type == id));
        }

        // POST: TypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Types type)
        {
            try
            {
                _context.types.Remove(type);
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
