using System.Text.Json.Serialization;
using DAL;

namespace BLL
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Duration { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }
        public string Conclusion { get; set; }
        public decimal Price { get; set; }

        [JsonConstructor]
        public AppointmentDTO() { }

        public AppointmentDTO(Appointment appointment)
        {
            Id = appointment.Id;
            Date = (DateTime)appointment.Date;
            StartTime = (TimeSpan)appointment.StartTime;
            PatientId = (int)appointment.PatientId;
            DoctorId = (int)appointment.DoctorId;
            ServiceId = (int)appointment.ServiceId;
            StatusId = (int)appointment.StatusId;
            Conclusion = appointment.Conclusion;
            Price = (decimal)appointment.Price;
            Duration = appointment.Service.Duration;
            EndTime = StartTime.Add(new TimeSpan(Duration, 0, 0));
        }
    }
}
