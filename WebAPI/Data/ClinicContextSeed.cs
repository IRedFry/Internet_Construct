using DAL;

namespace WebAPI.Data
{
    public static class ClinicContextSeed
    {
        public static async Task SeedAsync(ClinicContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Doctor.Any())
                    return;

                var specializations = new Specialization[]
                {
                    new Specialization
                    {
                        //Id = 1,
                        Name = "Окулист"
                    },
                    new Specialization
                    {
                        //Id = 2,
                        Name = "Педиатр"
                    },
                    new Specialization
                    {
                        //Id = 3,
                        Name = "Хирург"
                    }
                };

                foreach (var s in specializations)
                    context.Specialization.Add(s);
                await context.SaveChangesAsync();

                var doctors = new Doctor[]
                {
                    new Doctor
                    {
                        //Id = 1,
                        Name = "Андрей",
                        Sername = "Баженов",
                        StartDate = new DateTime(2000, 10, 5),
                        Salary = 10000,
                        SpecializationId = 1,
                        Specialization = context.Specialization.Where(i => i.Id == 1).FirstOrDefault()
                        
                    },
                    new Doctor
                    {
                        //Id = 2,
                        Name = "Алина",
                        Sername = "Морозова",
                        StartDate = new DateTime(2003, 12, 6),
                        Salary = 50000,
                        SpecializationId = 2,
                        Specialization = context.Specialization.Where(i => i.Id == 2).FirstOrDefault()
                    }
                };

                foreach (var d in doctors)
                    context.Doctor.Add(d);
                await context.SaveChangesAsync();

                if (context.Patient.Any())
                    return;

                var patients = new Patient[]
                {
                    new Patient
                    {
                        Name = "Тимофей",
                        Sername = "Горохов",
                        DayOfBirth = new DateTime(2003, 02, 03),
                        Passport = "214223",
                        Phone = "89206553256",
                    },
                    new Patient
                    {
                        Name = "Анастасия",
                        Sername = "Васильева",
                        DayOfBirth = new DateTime(2003, 06, 26),
                        Passport = "794613",
                        Phone = "89153210569",
                    }
                };

                foreach (var p in patients)
                    context.Patient.Add(p);
                await context.SaveChangesAsync();

                if (context.Service.Any())
                    return;

                var services = new Service[]
                {
                    new Service
                    {
                        Name = "Свиная вырезка",
                        Duration = 2,
                        Price = 1500,
                        SpecializationId = 1
                    },
                    new Service
                    {
                        Name = "Проверка работоспособности ребенка",
                        Duration = 1,
                        Price = 20000,
                        SpecializationId = 2
                    },
                    new Service
                    {
                        Name = "Установка антивируса для иммунитета",
                        Duration = 3,
                        Price = 10,
                        SpecializationId = 1
                    },

                };

                foreach (var s in services)
                    context.Service.Add(s);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
