using DAL;

namespace BLL
{
    public interface IPatientService
    {
        PatientDTO GetPatient(int id);
        int CreatePatient(PatientDTO patient);
    }
}
