using System.Numerics;

namespace WebAPI.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public string Conclusion { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Service Service { get; set; }
    }
}
