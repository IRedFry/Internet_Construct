using System.Text.Json.Serialization;
using DAL;

namespace BLL
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public int Years { get; set; }

        [JsonConstructor]
        public DoctorDTO() { }
        public DoctorDTO(Doctor d, IDbRepos context)
        {
            Id = d.Id;
            Name = d.Name;
            Sername = d.Sername;
            SpecializationId = d.SpecializationId;
            SpecializationName = context.Specializations.GetItem(SpecializationId).Name;
            StartDate = d.StartDate;
            Years = (int)((DateTime.Now - StartDate).TotalDays / 365);
        }

    }
}
