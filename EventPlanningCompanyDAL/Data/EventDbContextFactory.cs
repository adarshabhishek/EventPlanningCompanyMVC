using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventPlanningCompanyDAL.Data
{
    public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
    {
        public EventDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=ADARSH\\SQLEXPRESS;Database=EventPlanningDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new EventDbContext(optionsBuilder.Options);
        }
    }
}