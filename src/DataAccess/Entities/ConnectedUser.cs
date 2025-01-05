namespace DataAccess.Entities
{
    public class ConnectedUser
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public User? User { get; set; }
        public required string ConnectedToUserId { get; set; }
        public User? ConnectedToUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
