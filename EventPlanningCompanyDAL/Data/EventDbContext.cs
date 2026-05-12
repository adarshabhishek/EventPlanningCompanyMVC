using EventPlanningCompanyDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanningCompanyDAL.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
    }
}