using System;
using System.Linq;

namespace HealthVision.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(HealthVisionDbContext context)
        {
            if (context.Patients.Any()) return; // Already seeded

            var patients = new[]
            {
                new Patient { FirstName = "John", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 12), Gender = "Male" },
                new Patient { FirstName = "Anna", LastName = "Miller", DateOfBirth = new DateTime(1990, 7, 24), Gender = "Female" },
                new Patient { FirstName = "David", LastName = "Brown", DateOfBirth = new DateTime(1978, 11, 5), Gender = "Male" }
            };

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
    }
}
