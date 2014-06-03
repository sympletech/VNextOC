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


namespace VnextOC.Tests
{
    /// <summary>
    /// Summary description for MeetupTest
    /// </summary>
    [TestFixture] [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class MeetupTest
    {
        [Test] [TestMethod]
        public void TestGetRandomAPIKeyString()
        {
            String MeetupAPIKey = Meetup.GetRandomAPIKeyString();
            //Approvals.Equals(MeetupAPIKey,"" | "");
            Trace.Assert(MeetupAPIKey == "0393c247c5f1443107c312142206710" | 
                         MeetupAPIKey == "177249507444921606913487d434875");
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

    }
}
