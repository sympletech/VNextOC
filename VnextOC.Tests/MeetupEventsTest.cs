using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using System.IO;
using NUnit.Framework;
using VnextOC.MeetupApi;
using Approvals = ApprovalTests.Approvals;

// http://api.meetup.com/2/events?group_id=2983232&key=0393c247c5f1443107c312142206710

namespace VnextOC.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class MeetupEventsTest
    {
        [Test]
        public void TestJsonEventTransformation()
        {
            var json = File.ReadAllText(PathUtilities.GetAdjacentFile("SampleEventData.json"));
               

            var events = Meetup.ParseEvent(json);
            
            Approvals.VerifyAll(events, "event");
        }

        [Test]
        public void TestParseNamePerson()
        {
            var name = "Paul D. Sheriff - Architecting Applications for Multiple-User-Interfaces";

            var e = new Event().ParseName(name);

            Approvals.Verify(e);
        }


    }
}
