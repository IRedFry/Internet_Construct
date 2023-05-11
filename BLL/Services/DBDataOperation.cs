using DAL;

namespace BLL
{
    public class DBDataOperation : IDbCrud
    {
        private IDbRepos context;
        public DBDataOperation(IDbRepos repos)
        {
            context = repos;
        }
        public List<ServiceDTO> GetAllServices()
        {
            return context.Services.GetList().Select(i => new ServiceDTO(i, context)).ToList();
        }
    }

}
