using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using VnextOC.MeetupApi;
using Approvals = ApprovalTests.Approvals;

// http://api.meetup.com/2/events?group_id=2983232&key=0393c247c5f1443107c312142206710

namespace VnextOC.Tests
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class MeetupEventsTest
    {
        [TestMethod]
        public void TestJsonEventTransformation()
        {
            var json = File.ReadAllText(PathUtilities.GetAdjacentFile("SampleEventData.json"));

            var events = Meetup.ParseEvent(json);
            
            Approvals.VerifyAll(events, "event");
        }

        [TestMethod]
        public void TestParseNamePerson()
        {
            var name = "Paul D. Sheriff - Architecting Applications for Multiple-User-Interfaces";

            var e = new Event().ParseName(name);

            Approvals.Verify(e);
        }
    }
}
