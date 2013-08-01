using System;
using System.Collections.Generic;
using System.Linq;

namespace VnextOC.MeetupApi
{
    public static class Meetup
    {
        public static IEnumerable<Event> ParseEvent(string json)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var events = (IEnumerable<dynamic>) data.results;
            return events.Select(e => new Event().ParseDate((long)e.time, (long)e.utc_offset).ParseName((string)e.name));
            

        }

 
        public static Event ParseName(this Event e, string name)
        {
            string[] parts = name.Split('-');
            e.Speaker = parts.First();
            e.Title = string.Join("-", parts.Skip(1));
            return e;
        }
        public static Event ParseDate(this Event e, long time, long utc_offset)
        {
            e.Time = new DateTime(1970,1,1,0,0,0).AddMilliseconds(time + utc_offset);

            return e;
        }
    }
}