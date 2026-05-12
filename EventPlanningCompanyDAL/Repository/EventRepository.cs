using EventPlanningCompanyDAL.Data;
using EventPlanningCompanyDAL.Models;

namespace EventPlanningCompanyDAL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext db;

        public EventRepository(EventDbContext db)
        {
            this.db = db;
        }

        public bool AddEvent(Event events)
        {
            try
            {
                db.Events.Add(events);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteEvent(int id)
        {
            try
            {
                var events = db.Events.Find(id);

                if (events != null)
                {
                    db.Events.Remove(events);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public List<Event> GetAllEvents()
        {
            try
            {
                return db.Events.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Event GetEventById(int id)
        {
            try
            {
                return db.Events.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public List<Event> SearchEvent(string keyword)
        {
            try
            {
                return db.Events
                    .Where(x => x.Name.Contains(keyword))
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateEvent(Event events)
        {
            try
            {
                db.Events.Update(events);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}