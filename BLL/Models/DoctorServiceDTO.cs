using DAL;
using System.Text.Json.Serialization;


namespace BLL
{
    public class DoctorServiceDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string SpecializationName { get; set; }
        public decimal Price { get; set; }
        public string PatientFIO { get; set; }
        public int StatusId {get; set; }
        public string Conclusion { get; set; }
        public DateTime Date { get; set; }
        public string StartTimeString { get; set; }

        [JsonConstructor]
        public DoctorServiceDTO() { }

        public DoctorServiceDTO(AppointmentDTO appointment, IDbRepos context)
        {
            Id = appointment.Id;
            var service = context.Services.GetItem(appointment.ServiceId);
            ServiceName = service.Name;
            SpecializationName = context.Specializations.GetItem(service.SpecializationId).Name;
            Price = (decimal)service.Price;
            PatientFIO = context.Patients.GetItem(appointment.PatientId).Sername + " " + context.Patients.GetItem(appointment.PatientId).Name;
            Date = appointment.Date;
            StatusId = appointment.StatusId;
            Conclusion = appointment.Conclusion;
            StartTimeString = ((int)appointment.StartTime.TotalHours).ToString() + ":00:00";
        }
    }
}
