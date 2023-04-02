using WebAPI.Models;

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
                        Id = 1,
                        Name = "Окулист"
                    },
                    new Specialization
                    {
                        Id = 2,
                        Name = "Педиатр"
                    },
                    new Specialization
                    {
                        Id = 3,
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
                        Id = 1,
                        Name = "Андрей",
                        Sername = "Баженов",
                        StartDate = new DateTime(2000, 10, 5),
                        Salary = 10000,
                        Login = "A",
                        Password = "B",
                        SpecializationId = 1
                    },
                    new Doctor
                    {
                        Id = 2,
                        Name = "Алина",
                        Sername = "Морозова",
                        StartDate = new DateTime(2003, 12, 6),
                        Salary = 50000,
                        Login = "A",
                        Password = "M",
                        SpecializationId = 2
                    }
                };

                foreach (var d in doctors)
                    context.Doctor.Add(d);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
