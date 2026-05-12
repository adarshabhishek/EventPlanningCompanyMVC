using EventPlanningCompanyDAL.Models;
using EventPlanningCompanyDAL.Repository;
using EventPlanningCompanyServices.Interfaces;

namespace EventPlanningCompanyServices.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository repo;

        public EventService(IEventRepository repo)
        {
            this.repo = repo;
        }

        public bool AddEvent(Event events)
        {
            return repo.AddEvent(events);
        }

        public bool DeleteEvent(int id)
        {
            return repo.DeleteEvent(id);
        }

        public List<Event> GetAllEvents()
        {
            return repo.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return repo.GetEventById(id);
        }

        public List<Event> SearchEvent(string keyword)
        {
            return repo.SearchEvent(keyword);
        }

        public bool UpdateEvent(Event events)
        {
            return repo.UpdateEvent(events);
        }
    }
}