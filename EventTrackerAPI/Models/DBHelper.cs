using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EventTrackerAPI.Models
{
    public class DBHelper : IDBHelper
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        private readonly IConfiguration configuration;
        private static List<Event> events = null;

        public DBHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("EventsDB"));
            con.Open();
        }
        


        public int AddEvent(Event _event)
        {
            com = new SqlCommand("INSERT INTO [dbo].[Events] ([EventId] ,[EventName]    ,[EventType] ,[EventDate]       ,[EventImg]) VALUES (" 
                + _event.EventId + ",'" + _event.EventName + "','" + _event.EventType + "','" + _event.EventDate + "','" + _event.EventImg + ",)", con);
            return com.ExecuteNonQuery();
        }

        public List<Event> GetAllEvents()
        {
            events = new List<Event>();
            com = new SqlCommand("Select * from Events", con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                Event _event = new Event();
                _event.EventId = reader.GetInt32(0);
                _event.EventName = reader.GetString(1).Trim();
                _event.EventType = reader.GetString(2).Trim();
                _event.EventDate = reader.GetString(3).Trim();
                _event.EventImg = reader.GetString(4).Trim();
                events.Add(_event);

            }
            reader.Close();
            return events;
        }

        public Event GetEvent(int eventId)
        {
            events.Clear();
            GetAllEvents();
            Event _event = events.FirstOrDefault(e => e.EventId == eventId);
            return _event;
        }
    }
}
