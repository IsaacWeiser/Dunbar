namespace Dunbar.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public int RelativityId { get; set; }
    }
}
