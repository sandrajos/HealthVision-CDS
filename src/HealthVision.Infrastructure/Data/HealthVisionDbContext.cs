namespace HealthVision.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using HealthVision.Domain.Entities;

    public class HealthVisionDbContext : DbContext
    {
        public HealthVisionDbContext(DbContextOptions<HealthVisionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Study> Studies { get; set; }
    }
}
