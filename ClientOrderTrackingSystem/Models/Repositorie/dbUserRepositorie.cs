
using Microsoft.EntityFrameworkCore;

namespace ClientOrderTrackingSystem.Models.Repositorie
{
    public class dbUserRepositorie : IRepositorie<User>
    {
        public AppDBContext db { get; }
        public dbUserRepositorie(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, User entity)
        {
            var data = Find(Id);
            db.Users.Remove(data);
            db.SaveChanges();
        }

        public User Find(int Id)
        {
            return db.Users.SingleOrDefault(x => x.UserId == Id);
        }

        public void Update(int Id, User entity)
        {
            db.Users.Update(entity);
            db.SaveChanges();
        }

        public IList<User> View()
        {
            return db.Users.Include(x=>x.UserType).ToList();
        }
    }
}
