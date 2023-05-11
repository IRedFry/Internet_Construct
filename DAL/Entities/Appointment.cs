namespace DAL
{
    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
        }

        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<TimeSpan> StartTime { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Conclusion { get; set; }
        public Nullable<decimal> Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Service Service { get; set; }
        public virtual Status Status{ get; set; }
    }
}
