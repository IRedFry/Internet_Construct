namespace DAL
{
    public class DoctorRepositorySQL : IRepository<Doctor>
    {
        private ClinicContext context;

        public DoctorRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Doctor item)
        {
            context.Doctor.Add(item);
        }

        public void Delete(int id)
        {
            Doctor cat = context.Doctor.Find(id);
            if (cat != null)
                context.Doctor.Remove(cat);
        }

        public Doctor GetItem(int id)
        {
            return context.Doctor.Find(id);
        }

        public List<Doctor> GetList()
        {
            return context.Doctor.ToList();
        }

        public void Update(Doctor item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
