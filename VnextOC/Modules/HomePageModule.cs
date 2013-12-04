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
            Get["/calendar"] = _ => View["calendar"];
            Get["/members"] = _  => View["members"];
            Get["/community"] = _ => View["community"];
            Get["/job-buzz"] = _ => View["job-buzz"];
            Get["/sponsors"] = _ => View["sponsors"];
            Get["/library"] = _ => View["library"];

            Get["/Events"] = _ =>
            {
                var e = Meetup.ParseEvent();
                return Response.AsJson(e);
            };
        }
    }
}
   