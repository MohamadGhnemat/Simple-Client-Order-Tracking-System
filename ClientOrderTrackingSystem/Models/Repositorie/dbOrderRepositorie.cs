
using Microsoft.EntityFrameworkCore;

namespace ClientOrderTrackingSystem.Models.Repositorie
{
    public class dbOrderRepositorie : IRepositorie<Order>
    {
        public AppDBContext db { get; }
        public dbOrderRepositorie(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Order entity)
        {
            db.Orders.Add(entity);  
            db.SaveChanges();
        }

        public void Delete(int Id, Order entity)
        {
            var data =Find(Id);
            db.Orders.Remove(entity);
            db.SaveChanges();
        }

        public Order Find(int Id)
        {
            return db.Orders.SingleOrDefault(x => x.OrderId == Id);
        }

        public void Update(int Id, Order entity)
        {
            db.Orders.Update(entity);
            db.SaveChanges();
        }

        public IList<Order> View()
        {
           return db.Orders.Include(x=>x.Client).Include(x=>x.Product).Include(x=>x.Payment).ToList();
        }
    }
}
