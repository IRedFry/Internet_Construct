namespace DAL
{
    public class DayOfWeekRepositorySQL : IRepository<DayOfWeek>
    {
        private ClinicContext context;

        public DayOfWeekRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(DayOfWeek item)
        {
            context.DayOfWeek.Add(item);
        }

        public void Delete(int id)
        {
            DayOfWeek cat = context.DayOfWeek.Find(id);
            if (cat != null)
                context.DayOfWeek.Remove(cat);
        }

        public DayOfWeek GetItem(int id)
        {
            return context.DayOfWeek.Find(id);
        }

        public List<DayOfWeek> GetList()
        {
            return context.DayOfWeek.ToList();
        }

        public void Update(DayOfWeek item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
