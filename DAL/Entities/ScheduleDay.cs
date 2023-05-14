namespace DAL
{
    /// <summary>
    /// День в расписании врача
    /// </summary>
    public partial class ScheduleDay
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DayOfWeekId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsHoliday { get; set; }
        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
