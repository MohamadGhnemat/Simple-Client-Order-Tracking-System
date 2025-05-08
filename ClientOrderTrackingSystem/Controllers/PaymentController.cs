using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
    public class PaymentController : Controller
    {
        IRepositorie<Payment> PaymentRepo;
        public PaymentController(IRepositorie<Payment>  repositorie)
        {
            PaymentRepo = repositorie;
        }
        // GET: PaymentController
        public ActionResult Index()
        {
            var data = PaymentRepo.View().ToList();
            return View(data);
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            var data = PaymentRepo.Find(id);
            return View(data);
        }

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment collection)
        {
            try
            {
                PaymentRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = PaymentRepo.Find(id);
            return View(data);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Payment collection)
        {
            try
            {
                PaymentRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = PaymentRepo.Find(id);
            return View(data);
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Payment collection)
        {
            try
            {
                PaymentRepo.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
