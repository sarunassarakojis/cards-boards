using System.ComponentModel.DataAnnotations;
using GossipBoard.Models.Client;

namespace GossipBoard.Models.Post.Poll
{
    public class PollParticipant
    {
        [Key]
        public int Id { get; set; }

        public User PollUser { get; set; }
    }
}