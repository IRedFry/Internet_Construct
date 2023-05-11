namespace DAL
{
    public class ScheduleDayRepositorySQL : IRepository<ScheduleDay>
    {
        private ClinicContext context;

        public ScheduleDayRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(ScheduleDay item)
        {
            context.ScheduleDay.Add(item);
        }

        public void Delete(int id)
        {
            ScheduleDay cat = context.ScheduleDay.Find(id);
            if (cat != null)
                context.ScheduleDay.Remove(cat);
        }

        public ScheduleDay GetItem(int id)
        {
            return context.ScheduleDay.Find(id);
        }

        public List<ScheduleDay> GetList()
        {
            return context.ScheduleDay.ToList();
        }

        public void Update(ScheduleDay item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
