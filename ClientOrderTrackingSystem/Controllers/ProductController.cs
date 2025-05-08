using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
    public class ProductController : Controller
    {
        IRepositorie<Product> ProductRepo;
        public ProductController(IRepositorie<Product>  repositorie)
        {
            ProductRepo = repositorie;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var data = ProductRepo.View().ToList();
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var data = ProductRepo.Find(id);
            return View(data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                ProductRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = ProductRepo.Find(id);
            return View(data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product collection)
        {
            try
            {
                ProductRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = ProductRepo.Find(id);
            return View(data);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                ProductRepo.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
