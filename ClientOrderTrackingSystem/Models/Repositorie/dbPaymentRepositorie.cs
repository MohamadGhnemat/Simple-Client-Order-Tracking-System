
namespace ClientOrderTrackingSystem.Models.Repositorie
{
    public class dbPaymentRepositorie : IRepositorie<Payment>
    {
        public AppDBContext db { get; }
        public dbPaymentRepositorie(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Payment entity)
        {
            db.Payments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Payment entity)
        {
            var data = Find(Id);
            db.Payments.Remove(data);
            db.SaveChanges();
        }

        public Payment Find(int Id)
        {
            return db.Payments.SingleOrDefault(x => x.PaymentTypeId == Id);
        }

        public void Update(int Id, Payment entity)
        {
           db.Payments.Update(entity);
            db.SaveChanges();   
        }

        public IList<Payment> View()
        {
            return db.Payments.ToList();
        }
    }
}
