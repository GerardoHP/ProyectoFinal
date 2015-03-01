using System;

namespace Common.DataModels
{
    public class RequestDTO
    {
        public string RequestId { get; set; }
        public int RelationId { get; set; }
        public Nullable<bool> Accepted { get; set; }
        public Nullable<bool> Finished { get; set; }
        public Nullable<double> LatFirstUser { get; set; }
        public Nullable<double> LngFirstUser { get; set; }
        public string FirstUserName { get; set; }
        public Nullable<double> LatSecondUser { get; set; }
        public Nullable<double> LngSecondUser { get; set; }
        public string SecondUserName { get; set; }
    }
}
