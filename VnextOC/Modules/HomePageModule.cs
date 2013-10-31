using System.Linq;
using Nancy;
using VnextOC.MeetupApi;

namespace VnextOC.Modules
{
    public class HomePageModule : Nancy.NancyModule
    {
        public HomePageModule()
        {
            Get["/"] = _ => View["HomePage"];

            Get["/Events"] = _ =>
            {
                var e = Meetup.ParseEvent();
                return Response.AsJson(e);
            };
        }
    }
}
   