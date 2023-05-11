
namespace DAL
{
    public class AppointmentRepositorySQL : IRepository<Appointment>
    {
        private ClinicContext context;

        public AppointmentRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Appointment item)
        {
            context.Appointment.Add(item);
        }

        public void Delete(int id)
        {
            Appointment cat = context.Appointment.Find(id);
            if (cat != null)
                context.Appointment.Remove(cat);
        }

        public Appointment GetItem(int id)
        {
            return context.Appointment.Find(id);
        }

        public List<Appointment> GetList()
        {
            return context.Appointment.ToList();
        }

        public void Update(Appointment item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
