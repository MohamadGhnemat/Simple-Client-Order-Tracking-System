using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
    public class UserTypeController : Controller
    {
        IRepositorie<UserType> UserTypeRepo;
        public UserTypeController(IRepositorie<UserType> repositorie)
        {
            UserTypeRepo = repositorie;
        }
        // GET: UserTypeController
        public ActionResult Index()
        {
            var data =UserTypeRepo.View().ToList();
            return View(data);
        }

        // GET: UserTypeController/Details/5
        public ActionResult Details(int id)
        {
            var data = UserTypeRepo.Find(id);
            return View(data);
        }

        // GET: UserTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserType collection)
        {
            try
            {
                UserTypeRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = UserTypeRepo.Find(id);
            return View(data);
        }

        // POST: UserTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserType collection)
        {
            try
            {
                UserTypeRepo.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = UserTypeRepo.Find(id);
            return View(data);
        }

        // POST: UserTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserType collection)
        {
            try
            {
                UserTypeRepo.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
