namespace DAL
{
    public class SpecializationRepositorySQL : IRepository<Specialization>
    {
        private ClinicContext context;

        public SpecializationRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Specialization item)
        {
            context.Specialization.Add(item);
        }

        public void Delete(int id)
        {
            Specialization cat = context.Specialization.Find(id);
            if (cat != null)
                context.Specialization.Remove(cat);
        }

        public Specialization GetItem(int id)
        {
            return context.Specialization.Find(id);
        }

        public List<Specialization> GetList()
        {
            return context.Specialization.ToList();
        }

        public void Update(Specialization item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
