using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly CarRentalDBContext _context;

        public PaymentsController (CarRentalDBContext context)
        {
            _context = context;
        }

        // GET: PaymentsControler
        public ActionResult Index()
        {
            return View(_context.payments.ToList());
        }


        // GET: PaymentsControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentsControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payments payment)
        {
            try
            {
                _context.payments.Add(payment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentsControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.payments.ToList().FirstOrDefault(x => x.id_payment == id));
        }

        // POST: PaymentsControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Payments payment)
        {
            try
            {
                _context.Update(payment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentsControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.payments.ToList().FirstOrDefault(x => x.id_payment == id));
        }

        // POST: PaymentsControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Payments payment)
        {
            try
            {
                _context.Remove(payment);
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
