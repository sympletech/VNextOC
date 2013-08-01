namespace VnextOC.Modules
{
    public class HomePageModule : Nancy.NancyModule
    {
        public HomePageModule()
        {
            Get["/"] =  _ =>  View["HomePage"];
            
           

        }
    }
}
   