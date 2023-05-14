using System.Text.Json.Serialization;
using DAL;

namespace BLL
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }

        [JsonConstructor]
        public PatientDTO() { }
        public PatientDTO(Patient d)
        {
            Id = d.Id;
            Name = d.Name;
            SerName = d.Sername;
            DateOfBirth = (DateTime)d.DayOfBirth;
            Passport = d.Passport;
            Phone = d.Phone;
        }
    }
}
