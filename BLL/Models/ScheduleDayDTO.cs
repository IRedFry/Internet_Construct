using System.Text.Json.Serialization;
using DAL;

namespace BLL
{
    public class ScheduleDayDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public string DayOfWeekString { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsHoliday { get; set; }
        
        [JsonConstructor]
        public ScheduleDayDTO() { }

        public ScheduleDayDTO(ScheduleDay day, IDbRepos context)
        {
            Id = day.Id;
            DoctorId = (int)day.DoctorId;
            DayOfWeek = (int)day.DayOfWeekId;
            StartTime = (TimeSpan)day.StartTime;
            EndTime = (TimeSpan)day.EndTime;
            IsHoliday = (bool)day.IsHoliday;
            DayOfWeekString = context.DaysOfWeek.GetItem(DayOfWeek).Name;
        }
    }
}
