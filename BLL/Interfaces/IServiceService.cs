namespace BLL
{
    public interface IServiceService
    {
        Task<List<ServiceDTO>> GetAllServices();
        Task<ServiceDTO> GetServicesById(int id);
        Task<List<ServiceDTO>> GetServicesByDoctor(int doctorId);
        Task<List<ServiceDTO>> GetServicesBySpecialization(int specializationId);
    }
}
