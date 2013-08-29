using System;
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
            string json = File.ReadAllText(PathUtilities.GetAdjacentFile("data.txt"));

            Get["/"] = _ =>
                {
                    var e = Meetup.ParseEvent(json);
                    return View["HomePage", e.First()];
                };
           
           

        }
    }
}
   