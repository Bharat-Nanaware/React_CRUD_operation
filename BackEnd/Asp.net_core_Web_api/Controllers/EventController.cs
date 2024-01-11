using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using React_assignment_1_web_api.Model;
namespace React_assignment_1_web_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {

        private EventDBContext _eventDBContext;
        public EventController(EventDBContext _eventDBContext)
        {
            this._eventDBContext = _eventDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result =(from Event in _eventDBContext.Events
                 select new
                 {
                     Date = Event.Date.ToString("yyyy-MM-dd"),
                     eventId = Event.EventId,
                     title = Event.Title,
                     imageUrl = Event.ImageUrl,
                     description = Event.Description,
                 }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Events = _eventDBContext.Events.ToList().Find(a => a.EventId == id);
                var result = new
                {
                    Date = Events.Date.ToString("yyyy-MM-dd"),
                    eventId =Events.EventId,
                    title = Events.Title,
                    imageUrl = Events.ImageUrl,
                    description = Events.Description,
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // POST api/<EventController>
        [HttpPost]
        public IActionResult Post(Event Event)
        {
            try
            {
                _eventDBContext.Add(Event);
                var result = _eventDBContext.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Event Event)
        {
            try
            {
                var Update = _eventDBContext.Events.Find(id);
                if (Update == null)
                {
                    return null;
                }
                _eventDBContext.Entry(Update).CurrentValues.SetValues(Event);
                var result = _eventDBContext.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var update = _eventDBContext.Events.Find(id);
                _eventDBContext.Events.Remove(update);
                var result = _eventDBContext.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
    }
}
