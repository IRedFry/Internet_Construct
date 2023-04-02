using Microsoft.Identity.Client;
using System.Text.Json.Serialization;
using WebAPI.Models;

namespace WebAPI
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public int SpecializationId { get; set; }
        public int ScheduleId { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public DoctorDTO() { }
        public DoctorDTO(Doctor d)
        {
            Id = d.Id;
            Name = d.Name;
            Sername = d.Sername;
            SpecializationId = (int)d.SpecializationId;
            ScheduleId = (int)d.ScheduleId;
            Salary = (decimal)d.Salary;
            StartDate = (DateTime)d.StartDate;
            Login = d.Login;
            Password = d.Password;
        }

    }
}
