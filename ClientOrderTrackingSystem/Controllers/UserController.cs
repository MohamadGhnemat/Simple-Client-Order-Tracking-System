using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using ClientOrderTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
   
    public class UserController : Controller
    {
        IRepositorie<User> UserRepo;
        IRepositorie<UserType> UserTypeRepo;
        public UserController(IRepositorie<User>  repositorie , IRepositorie<UserType> repositorie1)
        {
            UserRepo = repositorie;
            UserTypeRepo = repositorie1;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var data = UserRepo.View().ToList();
            return View(data);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var data = UserRepo.Find(id);
            return View(data);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var obj = new VwUserUserType
            {
                lstUserTypes= UserTypeRepo.View().ToList(),
            };
            return View(obj);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            try
            {
                UserRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = UserRepo.Find(id);
            var obj = new VwUserUserType
            {
                UserId=data.UserId,
                UserName =data.UserName ,
                UserPassword=data.UserPassword,
                Email=data.Email,
                UserTypeId = data.UserTypeId ,
                lstUserTypes= UserTypeRepo.View().ToList(),
            };
            return View(obj);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                UserRepo.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var data =UserRepo.Find(id);
            return View(data);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                UserRepo.Delete(id,collection); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
