namespace BLL
{
    public interface IScheduleService
    {
        List<ScheduleDayDTO> GetDoctorsScheduleDays(int doctorId);
        ScheduleDayWithSlotsDTO GetScheduleDayWithOpens(int doctorId, int serviceId, DateTime date);
        ScheduleDayDTO GetScheduleDay(int doctorId, int dayOfWeek);
        void EditScheduleDay(ScheduleDayDTO scheduleDay);
    }
}
