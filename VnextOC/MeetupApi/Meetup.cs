using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace VnextOC.MeetupApi
{
    public static class Meetup
    {
        public static IEnumerable<Event> ParseEvent(string json)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var events = (IEnumerable<dynamic>) data.results;
            return events.Select(e => new Event()
                                          .ParseDate((long) e.time, (long) e.utc_offset)
                                          .ParseName((string) e.name)
                                           .ParseDescription((string) e.description)
                                           .ParseUrl((string)e.event_url)
                                           .ParseAddress((object) e.venue));

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

        public static Event ParseDescription( this Event e, string description)
        {
            e.Description = description.Trim();
            return e;
        }

        public static Event ParseUrl(this Event e, string url)
        {
            e.EventUrl = url;
            return e;
        }

        public static Event ParseAddress(this Event e, dynamic venue)
        {
            e.Address = new Address {
                Name = venue.name,
                Street = venue.address_1,
                City = venue.city,
                State = venue.state,
                ZipCode = venue.zip,
            };
            return e;
        }

    }

    public class Address
    {
        public override string ToString()
        {
            return this.WritePropertiesToString();
        }

        public string Street { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}