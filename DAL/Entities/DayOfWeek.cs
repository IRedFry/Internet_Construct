namespace DAL
{
    /// <summary>
    /// День недели
    /// </summary>
    public partial class DayOfWeek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DayOfWeek()
        {
            this.ScheduleDay = new HashSet<ScheduleDay>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleDay> ScheduleDay { get; set; }
    }
}
