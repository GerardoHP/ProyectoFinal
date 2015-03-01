namespace Common.DataModels
{
    public class RelationDTO
    {
        public int RelationId { get; set; }
        public int FirstUserId { get; set; }
        public string FirstUserName { get; set; }
        public int SecondUserId { get; set; }
        public string SecondUserName { get; set; }
    }
}
