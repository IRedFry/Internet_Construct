using DAL;

namespace BLL
{
    public class PatientService : IPatientService
    {
        private IDbRepos context;

        public PatientService(IDbRepos repos)
        {
            context = repos;
        }

        public int CreatePatient(PatientDTO patient)
        {
            Patient p = new Patient
            {
                DayOfBirth = patient.DateOfBirth,
                Name = patient.Name,
                Passport = patient.Passport,
                Phone = patient.Phone,
                Sername = patient.SerName,
            };

            context.Patients.Create(p);
            context.Save();
            p = context.Patients.GetList().OrderByDescending(i => i.Id).FirstOrDefault();
            return p.Id;
        }

        public PatientDTO GetPatient(int id)
        {
            return new PatientDTO(context.Patients.GetItem(id));
        }
    }
}
