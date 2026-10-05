using Microsoft.AspNetCore.Mvc;
using CST8359_Assignment1.Models;

namespace CST8359_Assignment1.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "Career Fair",
                Date = new DateTime(2026, 2, 1),
                Location = "Gym"
            },

            new Event
            {
                Id = 2,
                Title = "Tech Talk",
                Date = new DateTime(2026, 2, 8),
                Location = "Auditorium"
            },

            new Event
            {
                Id = 3,
                Title = "Hack Night",
                Date = new DateTime(2026, 2, 15),
                Location = "Library"
            }
        };

        public IActionResult Index()
        {
            ViewData["Message"] = "Select an event to manage attendees.";

            return View(events);
        }

        public IActionResult ManageAttendees(int id)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }

            return View(selectedEvent);
        }

        [HttpPost]
        public IActionResult Signup(int id, Attendee attendee)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }

            selectedEvent.Attendees.Add(attendee);

            TempData["Message"] = "Attendee registered!";

            return RedirectToAction("ManageAttendees", new { id = id });
        }
    }
}