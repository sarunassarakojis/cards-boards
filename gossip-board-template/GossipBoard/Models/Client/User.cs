using System.ComponentModel.DataAnnotations;

namespace GossipBoard.Models.Client
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
