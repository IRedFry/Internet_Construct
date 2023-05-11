using System.Text.Json.Serialization;
using DAL;


namespace BLL
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        [JsonConstructor]
        public ServiceDTO() { }

        public ServiceDTO(Service service, IDbRepos context)
        {
            Id = service.Id;
            Name = service.Name;
            Price = (decimal)service.Price;
            Duration = service.Duration;
            SpecializationId = service.SpecializationId;
            SpecializationName = context.Specializations.GetItem(service.SpecializationId).Name;
        }

    }
}
