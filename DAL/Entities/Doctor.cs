namespace DAL
{
    /// <summary>
    /// Врач
    /// </summary>
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            this.Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }      
        public int SpecializationId { get; set; }
        public DateTime StartDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<ScheduleDay> ScheduleDay { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
