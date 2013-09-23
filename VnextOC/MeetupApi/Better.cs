using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace VnextOC.MeetupApi
{
    public class Better
    {
        public IEnumerable<Event> Batter()
        {
            //http://api.meetup.com/2/events?group_id=2983232&key=0393c247c5f1443107c312142206710
            var client = new RestClient("http://api.meetup.com/2/");

            var request = new RestRequest("events", Method.GET);
            request.AddParameter("group_id", "2983232");
            request.AddParameter("key", "0393c247c5f1443107c312142206710");

            var response = client.Execute(request);

            var apiResponse = JsonConvert.DeserializeObject<Rootobject>(response.Content);

            var events = apiResponse.results
                .Select(e => new Event()
                    .ParseDate(e.time, e.utc_offset)
                    .ParseName(e.name)
                    .ParseDescription(e.description)
                    .ParseUrl(e.event_url)
                    .ParseAddress(e.venue));

            return events;
        }
    }


    public class Rootobject
    {
        public Result[] results { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public string lon { get; set; }
        public int count { get; set; }
        public string link { get; set; }
        public string next { get; set; }
        public int total_count { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public long updated { get; set; }
        public string description { get; set; }
        public string method { get; set; }
        public string lat { get; set; }
    }

    public class Result
    {
        public string status { get; set; }
        public string visibility { get; set; }
        public int maybe_rsvp_count { get; set; }
        public Venue venue { get; set; }
        public string id { get; set; }
        public int utc_offset { get; set; }
        public int duration { get; set; }
        public long time { get; set; }
        public int waitlist_count { get; set; }
        public long updated { get; set; }
        public int yes_rsvp_count { get; set; }
        public long created { get; set; }
        public string event_url { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int headcount { get; set; }
        public Group group { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string zip { get; set; }
        public float lon { get; set; }
        public bool repinned { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string address_1 { get; set; }
        public float lat { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public float group_lat { get; set; }
        public string name { get; set; }
        public float group_lon { get; set; }
        public string join_mode { get; set; }
        public string urlname { get; set; }
        public string who { get; set; }
    }

}