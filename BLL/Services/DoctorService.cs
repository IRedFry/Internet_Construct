using DAL;

namespace BLL
{
    public class DoctorService : IDoctorService
    {
        private IDbRepos context;

        public DoctorService(IDbRepos repos)
        {
            context = repos;
        }

        public Task<List<DoctorDTO>> GetAllDoctors()
        {
            return Task.Run(() => context.Doctors.GetList().Select(i => new DoctorDTO(i, context)).ToList());
        }

        public Task<DoctorDTO> GetDoctorById(int id)
        {
            return Task.Run(() => new DoctorDTO(context.Doctors.GetItem(id), context));
        }

        public Task<List<DoctorDTO>> GetDoctorsBySpecialization(int specializationId)
        {
            return Task.Run(() => context.Doctors.GetList().Where(i => i.SpecializationId == specializationId).Select(i => new DoctorDTO(i, context)).ToList());
        }
    }
}
