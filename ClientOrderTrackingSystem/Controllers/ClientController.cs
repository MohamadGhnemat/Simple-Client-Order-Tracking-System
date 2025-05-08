using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
    public class ClientController : Controller
    {
        IRepositorie<Client> ClientRepo;
        public ClientController(IRepositorie<Client> repositorie)
        {
            ClientRepo = repositorie;
        }
        // GET: ClientController
        public ActionResult Index()
        {
            var data = ClientRepo.View().ToList();
            return View(data);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
           var data = ClientRepo.Find(id);
            return View(data);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client collection)
        {
            try
            {
                ClientRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = ClientRepo.Find(id);
            return View(data);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client collection)
        {
            try
            {
                ClientRepo.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = ClientRepo.Find(id);
            return View(data);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client collection)
        {
            try
            {
                ClientRepo.Delete(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
