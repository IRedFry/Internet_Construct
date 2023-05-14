using DAL;

namespace BLL
{
    public class ServiceService : IServiceService
    {
        private IDbRepos context;

        public ServiceService(IDbRepos repos)
        {
            context = repos;
        }

        public Task<List<ServiceDTO>> GetAllServices()
        {
            return Task.Run(() => context.Services.GetList().Select(i => new ServiceDTO(i, context)).ToList());
        }

        public Task<List<ServiceDTO>> GetServicesByDoctor(int doctorId)
        {
            int specializationId = (int)context.Doctors.GetItem(doctorId).SpecializationId;
            return Task.Run(() => GetServicesBySpecialization(specializationId));
        }

        public Task<ServiceDTO> GetServicesById(int id)
        {
            return Task.Run(() => new ServiceDTO(context.Services.GetItem(id),context));
        }

        public Task<List<ServiceDTO>> GetServicesBySpecialization(int specializationId)
        {
            return Task.Run(() => context.Services.GetList().Where(i => i.SpecializationId == specializationId).Select(i => new ServiceDTO(i, context)).ToList());
        }
    }
}
