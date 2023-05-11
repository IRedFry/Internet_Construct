namespace DAL
{
    public class DbReposSQL : IDbRepos
    {
        private ClinicContext context;
        private AppointmentRepositorySQL appointmentRepository;
        private DayOfWeekRepositorySQL dayOfWeekRepository;
        private DoctorRepositorySQL doctorRepository;
        private PatientRepositorySQL patientRepository;
        private ScheduleDayRepositorySQL scheduleDayRepository;
        private ServiceRepositorySQL serviceRepository;
        private SpecializationRepositorySQL specializationRepository;
        private UserRepositorySQL userRepository;
        private StatusRepositorySQL statusRepository;

        public DbReposSQL(ClinicContext context)
        {
            this.context = context;
        }

        public IRepository<Appointment> Appointments
        {
            get
            {
                if (appointmentRepository == null)
                    appointmentRepository = new AppointmentRepositorySQL(context);
                return appointmentRepository;
            }
        }

        public IRepository<DayOfWeek> DaysOfWeek
        {
            get
            {
                if (dayOfWeekRepository == null)
                    dayOfWeekRepository = new DayOfWeekRepositorySQL(context);
                return dayOfWeekRepository;
            }
        }

        public IRepository<Doctor> Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepositorySQL(context);
                return doctorRepository;
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepositorySQL(context);
                return patientRepository;
            }
        }

        public IRepository<ScheduleDay> ScheduleDays
        {
            get
            {
                if (scheduleDayRepository == null)
                    scheduleDayRepository = new ScheduleDayRepositorySQL(context);
                return scheduleDayRepository;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepositorySQL(context);
                return serviceRepository;
            }
        }

        public IRepository<Specialization> Specializations
        {
            get
            {
                if (specializationRepository == null)
                    specializationRepository = new SpecializationRepositorySQL(context);
                return specializationRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(context, null);
                return userRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepositorySQL(context);
                return statusRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
