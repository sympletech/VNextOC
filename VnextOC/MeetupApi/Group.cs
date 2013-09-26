namespace VnextOC.MeetupApi
{
    public class Group
    {
        public int id { get; set; }
        public float group_lat { get; set; }
        public string name { get; set; }
        public float group_lon { get; set; }
        public string join_mode { get; set; }
        public string urlname { get; set; }
        public string who { get; set; }
    }
}