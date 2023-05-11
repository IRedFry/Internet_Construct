using DAL;

namespace BLL
{
    public class SpecializationService : ISpecializationService
    {
        private IDbRepos context;

        public SpecializationService(IDbRepos repos)
        {
            context = repos;
        }

        public Task<List<SpecializationDTO>> GetAllSpecialization()
        {
            return Task.Run(() => context.Specializations.GetList().Select(i => new SpecializationDTO(i)).ToList());
        }
    }
}
