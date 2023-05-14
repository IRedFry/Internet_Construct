using DAL;
using System.Text.Json.Serialization;

namespace BLL.Models
{
    public class PatientServiceDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string SpecializationName { get; set; }
        public decimal Price { get; set; }
        public int StatusId { get; set; }
        public string DoctorFIO { get; set; }
        public string Conclusion { get; set; }
        public DateTime Date { get; set; }
        public string StartTimeString { get; set; }

        [JsonConstructor]
        public PatientServiceDTO() { }

        public PatientServiceDTO(AppointmentDTO appointment, IDbRepos context)
        {
            Id = appointment.Id;
            var service = context.Services.GetItem(appointment.ServiceId);
            ServiceName = service.Name;
            SpecializationName = context.Specializations.GetItem(service.SpecializationId).Name;
            Price = (decimal)service.Price;
            DoctorFIO = context.Doctors.GetItem(appointment.DoctorId).Sername + " " + context.Doctors.GetItem(appointment.DoctorId).Name;
            Date = appointment.Date;
            StatusId = appointment.StatusId;
            Conclusion = appointment.Conclusion;
            StartTimeString = ((int)appointment.StartTime.TotalHours).ToString() + ":00:00";
        }
    }
}
