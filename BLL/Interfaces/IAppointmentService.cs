using BLL.Models;

namespace BLL
{
    /// <summary>
    /// Интерфейс сервиса записей
    /// </summary>
    public interface IAppointmentService
    {
        List<AppointmentDTO> GetCurrentAppointmentsByPatient(int patientId);
        List<AppointmentDTO> GetCurrentAppointmentsByDoctor(int doctorId);
        Task<List<DoctorServiceDTO>> GetPresentDoctorService(int doctorId);
        Task<List<DoctorServiceDTO>> GetAlreadyDoctorService(int doctorId);
        Task<List<PatientServiceDTO>> GetPresentPatientService(int patientId);
        Task<List<PatientServiceDTO>> GetAlreadyPatientService(int patientId);
        List<AppointmentDTO> GetCompletedAppointmentsByPatient(int patientId);
        List<AppointmentDTO> GetCompletedAppointmentsByDoctor(int doctorId);
        void ChangeAppointmentStatus(int appoitmentId, int statusId);
        bool SetAppointmentConclusion(int appoitmentId, string conclusion);
        void CreateAppoitment(AppointmentDTO appointment);

    }
}
