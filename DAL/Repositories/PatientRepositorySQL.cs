namespace DAL
{
    public class PatientRepositorySQL : IRepository<Patient>
    {
        private ClinicContext context;

        public PatientRepositorySQL(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Patient item)
        {
            context.Patient.Add(item);
        }

        public void Delete(int id)
        {
            Patient cat = context.Patient.Find(id);
            if (cat != null)
                context.Patient.Remove(cat);
        }

        public Patient GetItem(int id)
        {
            return context.Patient.Find(id);
        }

        public List<Patient> GetList()
        {
            return context.Patient.ToList();
        }

        public void Update(Patient item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
