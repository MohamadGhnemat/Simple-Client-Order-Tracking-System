using ClientOrderTrackingSystem.Models;
using ClientOrderTrackingSystem.Models.Repositorie;
using ClientOrderTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderTrackingSystem.Controllers
{
    public class OrderController : Controller
    {
        IRepositorie<Order> OrderRepo;

        IRepositorie<Client> ClientRepo;
        IRepositorie<Product> ProductRepo;
        IRepositorie<Payment> PaymentRepo;
        public OrderController(IRepositorie<Order> repositorie, IRepositorie<Client> repositorie1, IRepositorie<Product> repositorie2, IRepositorie<Payment> repositorie3)
        {
            OrderRepo = repositorie;
            ClientRepo = repositorie1;
            ProductRepo = repositorie2;
            PaymentRepo = repositorie3;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            var data = OrderRepo.View().ToList();
            return View(data);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var data = OrderRepo.Find(id);
            return View(data);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var obj = new VwOrderClientProductPayment
            {
                lstClients = ClientRepo.View().ToList(),
                lstProducts = ProductRepo.View().ToList(),
                lstPayments = PaymentRepo.View().ToList(),
            
            };
            return View(obj);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order collection)
        {
            try
            {
                OrderRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = OrderRepo.Find(id);
            var obj = new VwOrderClientProductPayment
            {
                OrderId=data.OrderId,
                OrderDate=data.OrderDate,
                ClientId=data.ClientId,
                ProductId=data.ProductId,
                PaymentTypeId=data.PaymentTypeId,
                lstClients = ClientRepo.View().ToList(),
                lstProducts = ProductRepo.View().ToList(),
                lstPayments = PaymentRepo.View().ToList(),
            };
            return View(obj);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order collection)
        {
            try
            {
                OrderRepo.Update(id , collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = OrderRepo.Find(id);
            return View(data);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order collection)
        {
            try
            {
                OrderRepo.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
