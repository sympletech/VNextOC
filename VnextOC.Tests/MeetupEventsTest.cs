using Approvals = ApprovalTests.Approvals;
using ApprovalTests.Asp;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.IO;
using VnextOC.MeetupApi;

// http://api.meetup.com/2/events?group_id=2983232&key=0393c247c5f1443107c312142206710

namespace VnextOC.Tests
{
    [TestFixture] [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class MeetupEventsTest
    {
        [Test] [TestMethod]
        public void TestJsonEventTransformation()
        {
            var json = File.ReadAllText(PathUtilities.GetAdjacentFile("SampleEventData.json"));

            IEnumerable<MeetupEvent> meetupEvents = Meetup.ParseEvent(json);

            Approvals.VerifyAll(meetupEvents, "event");
        }

        [Test] [TestMethod]
        public void TestParseNamePerson()
        {
            var name = "Paul D. Sheriff - Architecting Applications for Multiple-User-Interfaces";

            var e = new MeetupEvent().ParseName(name);

            Approvals.Verify(e);
        }

        //[Test] [TestMethod]
        public void LockWeb()
        {
            AspApprovals.VerifyUrl("http://localhost:51795//");
        }

    }
}
