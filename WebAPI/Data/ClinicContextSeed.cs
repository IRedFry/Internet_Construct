using DAL;

namespace WebAPI.Data
{
    /// <summary>
    /// Класс создания предопределенных данных в БД
    /// </summary>
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
                        Name = "Окулист"
                    },
                    new Specialization
                    {
                        Name = "Педиатр"
                    },
                    new Specialization
                    {
                        Name = "Хирург"
                    },
                };

                foreach (var s in specializations)
                    context.Specialization.Add(s);
                await context.SaveChangesAsync();

                var doctors = new Doctor[]
                {
                    new Doctor
                    {
                        Name = "Андрей Алексеевич",
                        Sername = "Баженов",
                        StartDate = new DateTime(2001, 10, 12),
                        SpecializationId = 1,                        
                    },
                    new Doctor
                    {
                        Name = "Алина Романовна",
                        Sername = "Морозова",
                        StartDate = new DateTime(2005, 05, 09),
                        SpecializationId = 1,
                    },
                    new Doctor
                    {
                        Name = "Константин Романович",
                        Sername = "Браило",
                        StartDate = new DateTime(2001, 02, 15),
                        SpecializationId = 1,
                    },
                    
                    new Doctor
                    {
                        Name = "Марфа Иннокентьевна",
                        Sername = "Тимашева",
                        StartDate = new DateTime(2011, 04, 20),
                        SpecializationId = 2,
                    },
                    new Doctor
                    {
                        Name = "Трофим Елизарович",
                        Sername = "Федченков",
                        StartDate = new DateTime(2014, 05, 15),
                        SpecializationId = 2,
                    },
                    new Doctor
                    {
                        Name = "Аполлинария Прокловна",
                        Sername = "Радченко",
                        StartDate = new DateTime(2001, 04, 27),
                        SpecializationId = 2,
                    },

                    new Doctor
                    {
                        Name = "Алексей Юлианович",
                        Sername = "Собчак",
                        StartDate = new DateTime(2019, 02, 18),
                        SpecializationId = 3,
                    },
                    new Doctor
                    {
                        Name = "Анастасия Леонидовна",
                        Sername = "Федченков",
                        StartDate = new DateTime(2007, 12, 12),
                        SpecializationId = 3,
                    },
                    new Doctor
                    {
                        Name = "Савва Трофимович",
                        Sername = "Шевцов",
                        StartDate = new DateTime(2004, 12, 12),
                        SpecializationId = 3,
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
                        Name = "Тимофей Вадимович",
                        Sername = "Горохов",
                        DayOfBirth = new DateTime(2003, 02, 03),
                        Passport = "214223",
                        Phone = "89206553256",
                    },
                    new Patient
                    {
                        Name = "Анастасия Евгеньевна",
                        Sername = "Васильева",
                        DayOfBirth = new DateTime(2003, 06, 26),
                        Passport = "794613",
                        Phone = "89153210569",
                    },
                    new Patient
                    { 
                        Name = "Серафим Савванович",
                        Sername = "Голубов",
                        DayOfBirth = new DateTime(1995, 03, 05),
                        Passport = "2142555",
                        Phone = "89206553290",
                    },
                    new Patient
                    {
                        Name = "Полина Григориевна",
                        Sername = "Канаша",
                        DayOfBirth = new DateTime(1977, 12, 12),
                        Passport = "666666",
                        Phone = "89153480569",
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
                        Name = "Протезирование сустава",
                        Duration = 4,
                        Price = 60000,
                        SpecializationId = 3
                    },
                    new Service
                    {
                        Name = "Мини-инвазивная хирургия",
                        Duration = 2,
                        Price = 20000,
                        SpecializationId = 3
                    },
                    new Service
                    {
                        Name = "Трансплантация",
                        Duration = 6,
                        Price = 150000,
                        SpecializationId = 3
                    },

                    new Service
                    {
                        Name = "Общее обследование глаз",
                        Duration = 2,
                        Price = 3000,
                        SpecializationId = 1
                    },
                    new Service
                    {
                        Name = "Лазерная коррекция зрения",
                        Duration = 1,
                        Price = 25000,
                        SpecializationId = 1
                    },
                    new Service
                    {
                        Name = "Удаление катаракты",
                        Duration = 2,
                        Price = 10000,
                        SpecializationId = 1
                    },

                    new Service
                    {
                        Name = "Диагностика аллергии",
                        Duration = 1,
                        Price = 2000,
                        SpecializationId = 2
                    },
                    new Service
                    {
                        Name = "Лечение бронхиальной астмы",
                        Duration = 2,
                        Price = 4000,
                        SpecializationId = 2
                    },
                    new Service
                    {
                        Name = "Диагностика и лечение гастроэзофагеального рефлюкса",
                        Duration = 1,
                        Price = 1500,
                        SpecializationId = 2
                    },

                };

                foreach (var s in services)
                    context.Service.Add(s);
                await context.SaveChangesAsync();


                if (context.Status.Any())
                    return;

                var statuses = new Status[]
                {
                    new Status
                    {
                        Name = "Ожидает"
                    },
                    new Status
                    {
                        Name = "Завершен"
                    },
                    new Status
                    {
                        Name = "Отменен"
                    },

                };

                foreach (var s in statuses)
                    context.Status.Add(s);
                await context.SaveChangesAsync();

                if (context.Appointment.Any())
                    return;

                var appoitments = new Appointment[]
                {
                    new Appointment
                    {
                        PatientId = 1,
                        Date = new DateTime(2020, 12, 12),
                        DoctorId = 9,
                        StatusId = 2,
                        Conclusion = "Заключение процедуры успешное. Рекомендуется следовать указаниям врача по реабилитации и раннему возвращению к обычной жизни",
                        ServiceId = 2,
                        StartTime = new TimeSpan(9, 0, 0)
                    },
                    new Appointment
                    {
                        PatientId = 2,
                        Date = new DateTime(2019, 12, 12),
                        DoctorId = 1,
                        StatusId = 1,
                        Conclusion = "",
                        ServiceId = 4,
                        StartTime = new TimeSpan(12, 0, 0)
                    },
                    new Appointment
                    {
                        PatientId = 1,
                        Date = new DateTime(2022, 10, 10),
                        DoctorId = 2,
                        StatusId = 1,
                        Conclusion = "",
                        ServiceId = 2,
                        StartTime = new TimeSpan(14, 0, 0)
                    },


                };

                foreach (var a in appoitments)
                    context.Appointment.Add(a);
                await context.SaveChangesAsync();

                if (context.DayOfWeek.Any())
                    return;

                var daysOfWeek = new DAL.DayOfWeek[]
                {
                    new DAL.DayOfWeek
                    {
                        Name = "Понедельник"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Вторник"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Среда"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Четверг"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Пятница"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Суббота"
                    },
                    new DAL.DayOfWeek
                    {
                        Name = "Воскресение"
                    },
                };

                foreach (var s in daysOfWeek)
                    context.DayOfWeek.Add(s);
                await context.SaveChangesAsync();


                if (context.ScheduleDay.Any())
                    return;

                var scheduleDays = new ScheduleDay[]
                {
                    new ScheduleDay
                    {
                        DayOfWeekId = 1,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 2,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 3,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 4,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 5,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 6,
                        DoctorId = 1,
                        IsHoliday = false,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },
                    new ScheduleDay
                    {
                        DayOfWeekId = 7,
                        DoctorId = 1,
                        IsHoliday = true,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0),
                    },

                };
                foreach (var d in doctors)
                {
                    foreach (var s in scheduleDays)
                    {
                        ScheduleDay newS = new ScheduleDay
                        {
                            DayOfWeek = s.DayOfWeek,
                            DayOfWeekId = s.DayOfWeekId,
                            DoctorId = d.Id,
                            EndTime = s.EndTime,
                            IsHoliday = s.IsHoliday,
                            StartTime = s.StartTime
                        };
                        context.ScheduleDay.Add(newS);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
