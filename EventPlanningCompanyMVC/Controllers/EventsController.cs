using EventPlanningCompanyDAL.Models;
using EventPlanningCompanyServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanningCompanyMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService service;

        public EventsController(IEventService service)
        {
            this.service = service;
        }

        // EVENT LIST
        public IActionResult Index()
        {
            try
            {
                var events = service.GetAllEvents();

                return View(events);
            }
            catch
            {
                ViewBag.Error = "Unable to load events.";

                return View();
            }
        }

        // DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var events = service.GetEventById(id);

                if (events == null)
                {
                    return NotFound();
                }

                return View(events);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event events)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AddEvent(events);

                    TempData["Success"] = "Event Added Successfully";

                    return RedirectToAction(nameof(Index));
                }

                return View(events);
            }
            catch
            {
                ViewBag.Error = "Unable to create event.";

                return View(events);
            }
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var events = service.GetEventById(id);

                if (events == null)
                {
                    return NotFound();
                }

                return View(events);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event events)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.UpdateEvent(events);

                    TempData["Success"] = "Event Updated Successfully";

                    return RedirectToAction(nameof(Index));
                }

                return View(events);
            }
            catch
            {
                ViewBag.Error = "Unable to update event.";

                return View(events);
            }
        }

        // DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var events = service.GetEventById(id);

                if (events == null)
                {
                    return NotFound();
                }

                return View(events);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                service.DeleteEvent(id);

                TempData["Success"] = "Event Deleted Successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // SEARCH EVENT
        [HttpGet]
        public IActionResult Search(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return RedirectToAction(nameof(Index));
                }

                var events = service.SearchEvent(keyword);

                ViewBag.Search = keyword;

                return View("Index", events);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}