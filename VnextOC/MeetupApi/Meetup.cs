using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace VnextOC.MeetupApi
{
    public static class Meetup
    {
        public static IEnumerable<MeetupEvent> ParseEvent()
        {
            //http://api.meetup.com/2/events?group_id=2983232&key=0393c247c5f1443107c312142206710
            var client = new RestClient("http://api.meetup.com/2/");

            var request = new RestRequest("events", Method.GET);
            request.AddParameter("group_id", "2983232");
            request.AddParameter("key", "0393c247c5f1443107c312142206710");

            var response = client.Execute(request);
            return ParseEvent(response.Content);
        }

        public static IEnumerable<MeetupEvent> ParseEvent(string json)
        {
            var apiResponse = JsonConvert.DeserializeObject<MeetupApiResult>(json);

            var events = apiResponse.results
                .Select(e => new MeetupEvent()
                    .ParseDate(e.time, e.utc_offset)
                    .ParseName(e.name)
                    .ParseDescription(e.description)
                    .ParseUrl(e.event_url)
                    .ParseAddress(e.venue));

            return events;

        }




        public static MeetupEvent ParseName(this MeetupEvent e, string name)
        {
            string[] parts = name.Split('-');
            e.Speaker = parts.First();
            e.Title = string.Join("-", parts.Skip(1));
            return e;
        }
        public static MeetupEvent ParseDate(this MeetupEvent e, long time, long utc_offset)
        {
            e.Time = new DateTime(1970,1,1,0,0,0).AddMilliseconds(time + utc_offset);

            return e;
        }

        public static MeetupEvent ParseDescription( this MeetupEvent e, string description)
        {
            e.Description = description.Trim();
            return e;
        }

        public static MeetupEvent ParseUrl(this MeetupEvent e, string url)
        {
            e.EventUrl = url;
            return e;
        }

        public static MeetupEvent ParseAddress(this MeetupEvent e, dynamic venue)
        {
            if (venue == null)
            {
                return e;
            }
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