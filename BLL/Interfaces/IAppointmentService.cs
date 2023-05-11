namespace BLL
{
    public interface IAppointmentService
    {
        List<AppointmentDTO> GetAllAppointmentsByPatient(int patientId);
        List<AppointmentDTO> GetAllAppointmentsByDoctor(int doctorId);
        List<AppointmentDTO> GetCurrentAppointmentsByPatient(int patientId);
        List<AppointmentDTO> GetCurrentAppointmentsByDoctor(int doctorId);
        List<AppointmentDTO> GetCompletedAppointmentsByPatient(int patientId);
        List<AppointmentDTO> GetCompletedAppointmentsByDoctor(int doctorId);
        void ChangeAppointmentStatus(int appoitmentId, int statusId);
        void CreateAppoitment(AppointmentDTO appointment);

    }
}
