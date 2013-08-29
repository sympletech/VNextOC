using System;
using ApprovalUtilities.Utilities;

namespace VnextOC.MeetupApi
{
    public class Event
    {
        public string Title { get; set; }
        public override string ToString()
        {
            return this.WritePropertiesToString();
        }
        


        public string Speaker { get; set; }

        public DateTime Time { get; set; }

        public string Description  { get; set; }
    }
}