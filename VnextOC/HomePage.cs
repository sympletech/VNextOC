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
            Get["/"] = (dynamic _) => { return "Hello World!"; };
            
            string s1 = "Sam";
            var name = "Sam";
            name.EndsWith("Hello");
            var x  = new Dictionary<List<String>, Tuple<int, List<double>>>();
            Dictionary<List<string>, Tuple<int, List<double>>> x2 = new Dictionary<List<String>, Tuple<int, List<double>>>();
            dynamic s3 = "Sam";
            s3.EndsWith("Hello");
            s3.MaybeItShouldEndWith("uhoh");
            int s4 = s3;

        }
    }
}
   