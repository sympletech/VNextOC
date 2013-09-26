using System.Collections.Generic;
using ApprovalTests.Asp;
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

            IEnumerable<MeetupEvent> meetupEvents = Meetup.ParseEvent(json);

            Approvals.VerifyAll(meetupEvents, "event");
        }

        [Test]
        public void TestParseNamePerson()
        {
            var name = "Paul D. Sheriff - Architecting Applications for Multiple-User-Interfaces";

            var e = new MeetupEvent().ParseName(name);

            Approvals.Verify(e);
        }

        //[Test]
        public void LockWeb()
        {
            AspApprovals.VerifyUrl("http://localhost:51795//");
        }

    }
}
