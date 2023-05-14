using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    public interface IScheduleService
    {
        Task<List<ScheduleDayDTO>> GetDoctorsScheduleDays(int doctorId);
        Task<ScheduleDayWithSlotsDTO> GetScheduleDayWithOpens(int doctorId, int serviceId, DateTime date);
        Task<ScheduleDayDTO> GetScheduleDay(int doctorId, int dayOfWeek);
        bool EditScheduleDay(ScheduleDayDTO scheduleDay);
        bool EditDoctorsScheduleDays(List<ScheduleDayDTO> scheduleDays);
    }
}
