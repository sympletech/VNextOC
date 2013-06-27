using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VnextOC
{
    public class HomePageModule : Nancy.NancyModule
    {
        public HomePageModule()
        {
            Get["/"] =  _ =>  View["HomePage"];
            
           

        }
    }
}
   