using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class UserRepositorySQL : IRepository<User>
    {
        private ClinicContext context;
        private UserManager<User> userManager;

        public UserRepositorySQL(ClinicContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public void Create(User item)
        {
            context.User.Add(item);
        }

        public void Delete(int id)
        {
            User cat = context.User.Find(id);
            if (cat != null)
                context.User.Remove(cat);
        }

        public User GetItem(int id)
        {
            return context.User.Find(id);
        }

        public List<User> GetList()
        {
            return context.User.ToList();
        }

        public void Update(User item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
