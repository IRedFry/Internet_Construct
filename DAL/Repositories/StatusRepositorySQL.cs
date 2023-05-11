using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class StatusRepositorySQL : IRepository<Status>
    {
        private ClinicContext context;

        public StatusRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Status item)
        {
            context.Status.Add(item);
        }

        public void Delete(int id)
        {
            Status cat = context.Status.Find(id);
            if (cat != null)
                context.Status.Remove(cat);
        }

        public Status GetItem(int id)
        {
            return context.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return context.Status.ToList();
        }

        public void Update(Status item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
