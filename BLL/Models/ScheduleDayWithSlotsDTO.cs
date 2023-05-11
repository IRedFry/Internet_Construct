using System.Text.Json.Serialization;

namespace BLL
{
    public struct Slot
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
    public class ScheduleDayWithSlotsDTO
    {
        public ScheduleDayDTO ScheduleDay { get; set; }
        public List<Slot> Slots { get; set; }


        [JsonConstructor]
        public ScheduleDayWithSlotsDTO() 
        {
            Slots = new List<Slot>();
        }
    }
}
