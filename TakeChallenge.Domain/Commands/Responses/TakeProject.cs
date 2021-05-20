namespace TakeChallenge.Domain.Commands.Responses
{
    public class TakeProject
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string OwnerAvatar { get; set; }
    }
}