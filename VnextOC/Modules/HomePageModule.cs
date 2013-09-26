﻿using System;
using System.IO;
using System.Linq;
using ApprovalUtilities.Utilities;
using VnextOC.MeetupApi;

namespace VnextOC.Modules
{
    public class HomePageModule : Nancy.NancyModule
    {
        public HomePageModule()
        {
            string json = Data.R.fakeData;

            Get["/"] = _ =>
                {
                    var e = Meetup.ParseEvent();
                    return View["HomePage", e.First()];
                };

        }
    }
}
   