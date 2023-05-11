using DAL;

namespace BLL
{
    public class AppointmentService : IAppointmentService
    {
        private IDbRepos context;

        public AppointmentService(IDbRepos repos)
        {
            context = repos;
        }
        public void ChangeAppointmentStatus(int appoitmentId, int statusId)
        {
            Appointment app = context.Appointments.GetItem(appoitmentId);
            app.StatusId = statusId;
            app.Status = context.Statuses.GetItem(statusId);
            context.Appointments.Update(app);
        }

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
        }

        public List<AppointmentDTO> GetAllAppointmentsByDoctor(int doctorId)
        {
            return context.Appointments.GetList().Where(i => i.DoctorId == doctorId).Select(i => new AppointmentDTO(i)).ToList();
        }

        public List<AppointmentDTO> GetAllAppointmentsByPatient(int patientId)
        {
            return context.Appointments.GetList().Where(i => i.PatientId == patientId).Select(i => new AppointmentDTO(i)).ToList();
        }

        public List<AppointmentDTO> GetCompletedAppointmentsByDoctor(int doctorId)
        {
            return context.Appointments.GetList().Where(i => i.DoctorId == doctorId && i.StatusId == 1).Select(i => new AppointmentDTO(i)).ToList();
        }

        public List<AppointmentDTO> GetCompletedAppointmentsByPatient(int patientId)
        {
            return context.Appointments.GetList().Where(i => i.PatientId == patientId && i.StatusId == 1).Select(i => new AppointmentDTO(i)).ToList();
        }

        public List<AppointmentDTO> GetCurrentAppointmentsByDoctor(int doctorId)
        {
            return context.Appointments.GetList().Where(i => i.DoctorId == doctorId && i.StatusId == 0).Select(i => new AppointmentDTO(i)).ToList();
        }

        public List<AppointmentDTO> GetCurrentAppointmentsByPatient(int patientId)
        {
            return context.Appointments.GetList().Where(i => i.PatientId == patientId && i.StatusId == 0).Select(i => new AppointmentDTO(i)).ToList();
        }
    }
}
