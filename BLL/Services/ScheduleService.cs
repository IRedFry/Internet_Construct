using DAL;

namespace BLL
{
    public class ScheduleService : IScheduleService
    {
        private IDbRepos context;

        public ScheduleService(IDbRepos repos)
        {
            context = repos;
        }

        public void EditScheduleDay(ScheduleDayDTO scheduleDay)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleDayDTO> GetDoctorsScheduleDays(int doctorId)
        {
            return context.ScheduleDays.GetList().Where(i => i.DoctorId == doctorId).Select(i => new ScheduleDayDTO(i)).ToList();
        }

        public ScheduleDayDTO GetScheduleDay(int doctorId, int dayOfWeek)
        {
            List<ScheduleDayDTO> days = context.ScheduleDays.GetList().Where(i => i.DoctorId == doctorId).Select(i => new ScheduleDayDTO(i)).ToList();
            return days.Where(i => i.DayOfWeek == dayOfWeek).FirstOrDefault();
        }

        public ScheduleDayWithSlotsDTO GetScheduleDayWithOpens(int doctorId, int serviceId, DateTime date)
        {
            List<AppointmentDTO> appointmentsOnDate = context.Appointments.GetList().Where(i => i.DoctorId == doctorId && i.Date == date).Select(i => new AppointmentDTO(i)).ToList();
            int duration = context.Services.GetItem(serviceId).Duration;
            // Соответствие русской и амереканской недель!
            ScheduleDayDTO scheduleDay = GetScheduleDay(doctorId, (int)date.DayOfWeek);
            ScheduleDayWithSlotsDTO scheduleDayWithSlots = new ScheduleDayWithSlotsDTO();
            scheduleDayWithSlots.ScheduleDay = scheduleDay;

            for (int i = scheduleDay.StartTime.Hours; i < duration + scheduleDay.EndTime.Hours; i++)
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
    }
}
