
namespace ClientOrderTrackingSystem.Models.Repositorie
{
    public class dbClientRepositorie : IRepositorie<Client>
    {
        public AppDBContext db {  get; }
        public dbClientRepositorie(AppDBContext _db)
        {
          db = _db;  
        }
        public void Add(Client entity)
        {
           db.Clients.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Client entity)
        {
            var data = Find(Id);
            db.Clients.Remove(data);
            db.SaveChanges();
        }

        public Client Find(int Id)
        {
            return db.Clients.SingleOrDefault(x => x.ClientId == Id);
        }

        public void Update(int Id, Client entity)
        {
            db.Clients.Update(entity);
            db.SaveChanges();
        }

        public IList<Client> View()
        {
           return db.Clients.ToList();
        }
    }
}
