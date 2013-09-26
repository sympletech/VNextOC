using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VnextOC.MeetupApi
{
    public class MeetupEventParser
    {
        public MeetupEventParser()
        {
        }

        public List<MeetupEvent> ParseMeetupEvents(string json)
        {
            var jData = JObject.Parse(json);
            var jResults = (IEnumerable<JToken>) jData["results"];

            var results = jResults.Select(jResult =>
                {
                    //var parseName = ParseName(jResult);

                    return new MeetupEvent
                        {

                        };
                });




            //dynamic deserializedEventCollection = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            
            //var dynamicEventCollection = (IEnumerable<dynamic>)deserializedEventCollection.results;

            //var meetupEvents = new List<MeetupEvent>();

            //foreach (var dynamicEvent in dynamicEventCollection)
            //{
            //    var meetupEvent = Slapper.AutoMapper.MapDynamic<MeetupEvent>(dynamicEvent) as MeetupEvent;

            //    meetupEvents.Add(meetupEvent);

            //}

            //return meetupEvents;

            return new List<MeetupEvent>();
        }

        private class MeetupEventsCollectionMapping
        {
            public MeetupEventsEntryMapping results { get; set; }
        }

        private class MeetupEventsEntryMapping
        {
            public string status { get; set; }
        }
    }


}