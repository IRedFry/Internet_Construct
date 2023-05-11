namespace DAL
{
    public class ServiceRepositorySQL : IRepository<Service>
    {
        private ClinicContext context;

        public ServiceRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Service item)
        {
            context.Service.Add(item);
        }

        public void Delete(int id)
        {
            Service cat = context.Service.Find(id);
            if (cat != null)
                context.Service.Remove(cat);
        }

        public Service GetItem(int id)
        {
            return context.Service.Find(id);
        }

        public List<Service> GetList()
        {
            return context.Service.ToList();
        }

        public void Update(Service item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
