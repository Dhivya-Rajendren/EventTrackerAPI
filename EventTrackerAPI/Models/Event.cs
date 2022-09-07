using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTrackerAPI.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public String EventDate { get; set; }
        public string EventImg { get; set; }
    }
}
