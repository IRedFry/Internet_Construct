using BLL.Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// Сервис записей
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private IDbRepos context;

        public AppointmentService(IDbRepos repos)
        {
            context = repos;
        }
        /// <summary>
        /// Изменить статус записи
        /// </summary>
        /// <param name="appoitmentId">Id записи</param>
        /// <param name="statusId">Id статуса</param>
        public void ChangeAppointmentStatus(int appoitmentId, int statusId)
        {
            Appointment app = context.Appointments.GetItem(appoitmentId);
            app.StatusId = statusId;
            app.Status = context.Statuses.GetItem(statusId);
            context.Appointments.Update(app);
            context.Save();
        }
        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="appointment">DTO записи</param>
        public void CreateAppoitment(AppointmentDTO appointment)
        {
            Appointment app = new Appointment
            {
                Id = appointment.Id,
                Conclusion = appointment.Conclusion,
                Date = appointment.Date,
                DoctorId = appointment.DoctorId,
                Doctor = context.Doctors.GetItem(appointment.DoctorId),
                ServiceId = appointment.ServiceId,
                Service = context.Services.GetItem(appointment.ServiceId),
                StatusId = appointment.StatusId,
                Status = context.Statuses.GetItem(appointment.StatusId),
                PatientId = appointment.PatientId,
                Patient = context.Patients.GetItem(appointment.PatientId),
                Price = appointment.Price,
                StartTime = appointment.StartTime
            };

            context.Appointments.Create(app);
            context.Save();
        }
        /// <summary>
        /// Получить завершенные приемы врача
        /// </summary>
        /// <param name="doctorId">Id врача</param>
        /// <returns>Список записей</returns>
        /// 
        public List<AppointmentDTO> GetCompletedAppointmentsByDoctor(int doctorId)
        {
            return context.Appointments.GetList().Where(i => i.DoctorId == doctorId && i.StatusId == 2).Select(i => new AppointmentDTO(i, context)).ToList();
        }
        /// <summary>
        /// Получить завершенные приемы пациента
        /// </summary>
        /// <param name="patientId">Id пациента</param>
        /// <returns>Список записей</returns>
        public List<AppointmentDTO> GetCompletedAppointmentsByPatient(int patientId)
        {
            return context.Appointments.GetList().Where(i => i.PatientId == patientId && i.StatusId == 2).Select(i => new AppointmentDTO(i, context)).ToList();
        }
        /// <summary>
        /// Получить текущие приемы врача
        /// </summary>
        /// <param name="doctorId">Id врача</param>
        /// <returns>Список записей</returns>
        public List<AppointmentDTO> GetCurrentAppointmentsByDoctor(int doctorId)
        {
            return context.Appointments.GetList().Where(i => i.DoctorId == doctorId && i.StatusId == 1).Select(i => new AppointmentDTO(i, context)).ToList();
        }
        /// <summary>
        /// Получить модель отображения для завершенных приемов врача 
        /// </summary>
        /// <param name="patientId">Id пациента</param>
        /// <returns></returns>
        public List<AppointmentDTO> GetCurrentAppointmentsByPatient(int patientId)
        {
            return context.Appointments.GetList().Where(i => i.PatientId == patientId && i.StatusId == 1).Select(i => new AppointmentDTO(i, context)).ToList();
        }
        /// <summary>
        /// Получить модель отображения для текущих приемов врача 
        /// </summary>
        /// <param name="doctorId">Id врача</param>
        /// <returns>Модель отображение записей для врача</returns>
        public Task<List<DoctorServiceDTO>> GetPresentDoctorService(int doctorId)
        {
            var presentAppoitments = GetCurrentAppointmentsByDoctor(doctorId);
            List<DoctorServiceDTO> doctorServices = new List<DoctorServiceDTO>();
            int idSer = 1;
            foreach (var app in presentAppoitments)
            {
                doctorServices.Add(new DoctorServiceDTO(app, context));
            }

            return Task.Run(() => doctorServices);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctorId">Id врача</param>
        /// <returns>Модель отображение записей для врача</returns>
        public Task<List<DoctorServiceDTO>> GetAlreadyDoctorService(int doctorId)
        {
            var presentAppoitments = GetCompletedAppointmentsByDoctor(doctorId);
            List<DoctorServiceDTO> doctorServices = new List<DoctorServiceDTO>();
            int idSer = 1;
            foreach (var app in presentAppoitments)
            {
                doctorServices.Add(new DoctorServiceDTO(app, context));
            }

            return Task.Run(() => doctorServices);
        }
        /// <summary>
        /// Получить модель отображения для текущих приемов пациента 
        /// </summary>
        /// <param name="patientId">Id пациента</param>
        /// <returns>Модель отображение записей для пациента</returns>
        public Task<List<PatientServiceDTO>> GetPresentPatientService(int patientId)
        {
            var presentAppoitments = GetCurrentAppointmentsByPatient(patientId);
            List<PatientServiceDTO> patientServices = new List<PatientServiceDTO>();
            int idSer = 1;
            foreach (var app in presentAppoitments)
            {
                patientServices.Add(new PatientServiceDTO(app, context));
            }

            return Task.Run(() => patientServices);
        }
        /// <summary>
        /// Получить модель отображения для завершенных приемов пациента 
        /// </summary>
        /// <param name="patientId">Id пациента</param>
        /// <returns>Модель отображение записей для пациента</returns>
        public Task<List<PatientServiceDTO>> GetAlreadyPatientService(int patientId)
        {
            var presentAppoitments = GetCompletedAppointmentsByPatient(patientId);
            List<PatientServiceDTO> patientServices = new List<PatientServiceDTO>();
            foreach (var app in presentAppoitments)
            {
                patientServices.Add(new PatientServiceDTO(app, context));
            }

            return Task.Run(() => patientServices);
        }
        /// <summary>
        /// Выставить заключение приему
        /// </summary>
        /// <param name="appoitmentId">Id приема</param>
        /// <param name="conclusion">Заключение</param>
        /// <returns>Успех выполнения операции</returns>
        public bool SetAppointmentConclusion(int appoitmentId, string conclusion)
        {
            Appointment app = context.Appointments.GetItem(appoitmentId);
            int dur = context.Services.GetItem((int)app.ServiceId).Duration;
            if (DateTime.Now.Date <= app.Date || DateTime.Now.Date == app.Date && DateTime.Now.TimeOfDay <= ((TimeSpan)app.StartTime).Add(new TimeSpan(dur, 0, 0)))
                return false;

            app.Conclusion = conclusion;
            app.StatusId = 2;
            app.Status = context.Statuses.GetItem(2);
            context.Appointments.Update(app);
            context.Save();
            return true;
        }
    }
}

