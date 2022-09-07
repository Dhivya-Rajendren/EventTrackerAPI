using EventTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDBHelper dBHelper;

        public EventsController(IDBHelper dBHelper)
        {
            this.dBHelper = dBHelper;
        }


        public IActionResult Get()
        {
            return Ok(this.dBHelper.GetAllEvents());
        }

        [HttpGet("{eventId}")]
        public IActionResult Get(int eventId)
        {
            return Ok(this.dBHelper.GetEvent(eventId));
        }

    }
}
