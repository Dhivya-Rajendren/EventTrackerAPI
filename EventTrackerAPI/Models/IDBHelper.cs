using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTrackerAPI.Models
{
   public interface IDBHelper
    {
        List<Event> GetAllEvents();
        Event GetEvent(int eventId);

        int AddEvent(Event _event);
    }
}
