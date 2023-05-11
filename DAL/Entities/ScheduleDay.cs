namespace DAL
{
    public partial class ScheduleDay
    {
        public int Id { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> DayOfWeekId { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<bool> IsHoliday { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
