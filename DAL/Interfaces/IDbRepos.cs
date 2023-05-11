namespace DAL
{
    public interface IDbRepos
    {
        IRepository<Appointment> Appointments { get; }
        IRepository<DayOfWeek> DaysOfWeek { get; }
        IRepository<Doctor> Doctors{ get; }
        IRepository<Patient> Patients{ get; }
        IRepository<ScheduleDay> ScheduleDays { get; }
        IRepository<Service> Services { get; }
        IRepository<Specialization> Specializations { get; }
        IRepository<User> Users{ get; }
        IRepository<Status> Statuses { get; }
        int Save();

    }
}
