namespace BLL
{
    public interface ISpecializationService
    {
        Task<List<SpecializationDTO>> GetAllSpecialization();
    }
}
