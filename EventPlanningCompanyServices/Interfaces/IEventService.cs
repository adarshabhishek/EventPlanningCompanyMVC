using EventPlanningCompanyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanningCompanyServices.Interfaces
{
    public interface IEventService
    {
        List<Event> GetAllEvents();

        Event GetEventById(int id);

        bool AddEvent(Event events);

        bool UpdateEvent(Event events);

        bool DeleteEvent(int id);

        List<Event> SearchEvent(string keyword);
    }
}
