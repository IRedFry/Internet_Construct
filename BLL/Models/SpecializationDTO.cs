using System.Text.Json.Serialization;
using DAL;

namespace BLL
{
    public class SpecializationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [JsonConstructor]
        public SpecializationDTO() { }
        public SpecializationDTO(Specialization d)
        {
            Id = d.Id;
            Name = d.Name;
        }
    }
}
