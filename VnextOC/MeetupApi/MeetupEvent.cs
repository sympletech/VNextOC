using System;
using ApprovalUtilities.Utilities;

namespace VnextOC.MeetupApi
{
    public class MeetupEvent
    {
        public string Title { get; set; }
        public override string ToString()
        {
            return this.WritePropertiesToString();
        }

        public string Speaker { get; set; }

        public DateTime Time { get; set; }

        public string Day { get { return Time.Day.ToString(); } }

        public string TimeFormatted { get { return Time.ToString("ddd, MMMM dd, htt");  } }

        public string Description  { get; set; }

        public string EventUrl { get; set; }

        public Address Address { get; set; }
    }
}