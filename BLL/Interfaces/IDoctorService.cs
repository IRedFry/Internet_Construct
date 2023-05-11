namespace BLL
{
    public interface IDoctorService
    {
        Task<List<DoctorDTO>> GetAllDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task<List<DoctorDTO>> GetDoctorsBySpecialization(int specializationId);
    }
}
