namespace WebAPI.Models
{
    public partial class ScheduleDay
    {
        public int Id { get; set; }
        public Nullable<int> ScheduleWeekId { get; set; }
        public Nullable<int> DayOfWeekId { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<bool> IsHoliday { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual ScheduleWeek ScheduleWeek { get; set; }
    }
}
