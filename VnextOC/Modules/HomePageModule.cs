using System.Linq;
using VnextOC.MeetupApi;

namespace VnextOC.Modules
{
    public class HomePageModule : Nancy.NancyModule
    {
        public HomePageModule()
        {
            Get["/"] = _ =>
                {
                    var e = Meetup.ParseEvent();
                    return View["HomePage", e.First()];
                };
        }
    }
}
   