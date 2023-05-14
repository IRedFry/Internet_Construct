using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    public class ScheduleService : IScheduleService
    {
        private IDbRepos context;

        public ScheduleService(IDbRepos repos)
        {
            context = repos;
        }

        public bool EditScheduleDay(ScheduleDayDTO scheduleDay)
        {
            List<AppointmentDTO> appointmentsOnDate = context.Appointments.GetList().Where(i => i.DoctorId == scheduleDay.DoctorId && (int)(((DateTime)i.Date).DayOfWeek) == scheduleDay.DayOfWeek && i.StatusId == 1).Select(i => new AppointmentDTO(i, context)).ToList();

            bool canEdit = true;
            foreach(var app in appointmentsOnDate)
            {
                if (app.StartTime.TotalHours < (int)scheduleDay.StartTime.TotalHours || app.StartTime.Add(new TimeSpan(app.Duration,0,0)).TotalHours > (int)scheduleDay.EndTime.TotalHours)
                {
                    canEdit = false;
                    break;
                }
            }

            if (canEdit)
            {
                var scDay = context.ScheduleDays.GetItem(scheduleDay.Id);
                scDay.StartTime = scheduleDay.StartTime;
                scDay.EndTime = scheduleDay.EndTime;
                context.ScheduleDays.Update(scDay);
                return true;
            }

            return false;
        }

        public Task<List<ScheduleDayDTO>> GetDoctorsScheduleDays(int doctorId)
        {
            return Task.Run(() => context.ScheduleDays.GetList().Where(i => i.DoctorId == doctorId).Select(i => new ScheduleDayDTO(i, context)).ToList());
        }

        public Task<ScheduleDayDTO> GetScheduleDay(int doctorId, int dayOfWeek)
        {
            List<ScheduleDayDTO> days = context.ScheduleDays.GetList().Where(i => i.DoctorId == doctorId).Select(i => new ScheduleDayDTO(i, context)).ToList();
            return Task.Run(() => days.Where(i => i.DayOfWeek == dayOfWeek).FirstOrDefault());
        }
        private bool CompareDates(DateTime left, DateTime right)
        {
            if (left.Year == right.Year && left.Month == right.Month && left.Day == right.Day)
                return true;
            return false;
        }
        public async Task<ScheduleDayWithSlotsDTO> GetScheduleDayWithOpens(int doctorId, int serviceId, DateTime date)
        {
            List<AppointmentDTO> appointmentsOnDate = context.Appointments.GetList().Where(i => i.DoctorId == doctorId && CompareDates(((DateTime)i.Date) ,date) && i.StatusId == 1).Select(i => new AppointmentDTO(i, context)).ToList();
            int duration = context.Services.GetItem(serviceId).Duration;
            // Соответствие русской и амереканской недель!
            ScheduleDayDTO scheduleDay = await GetScheduleDay(doctorId, (int)date.DayOfWeek);
            ScheduleDayWithSlotsDTO scheduleDayWithSlots = new ScheduleDayWithSlotsDTO();
            scheduleDayWithSlots.ScheduleDay = scheduleDay;

            for (int i = scheduleDay.StartTime.Hours; i + duration <= scheduleDay.EndTime.Hours; i++)
            {
                bool isOpen = true;
                foreach(var app in appointmentsOnDate)
                {
                    if (((i < app.EndTime.Hours) && (i + duration > app.EndTime.Hours))     ||
                        ((i < app.StartTime.Hours) && (i + duration > app.StartTime.Hours)) ||
                        ((i >= app.StartTime.Hours) && (i + duration <= app.EndTime.Hours)))
                    {
                        isOpen = false;
                        break;
                    }
                }

                if (isOpen)
                {
                    Slot slot = new Slot
                    {
                        StartTime = new TimeSpan(i, 0, 0),
                        EndTime = new TimeSpan(i + duration, 0, 0),
                    };
                    scheduleDayWithSlots.Slots.Add(slot);
                }
            }

            return scheduleDayWithSlots;
        }

        public bool EditDoctorsScheduleDays(List<ScheduleDayDTO> scheduleDays)
        {
            bool canEdit = true;
            foreach (var sd in scheduleDays)
            {
                canEdit = EditScheduleDay(sd);
                if (!canEdit)
                    break;
            }
            if (canEdit)
            {
                context.Save();
                return true;
            }

            return false;
        }
    }
}
