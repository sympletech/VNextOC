using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VnextOC
{
    public class HomePage : Nancy.NancyModule
    {
        public HomePage()
        {
            Get["/"] =  _ =>  View["HomePage"];
            
           

        }
    }
}
   