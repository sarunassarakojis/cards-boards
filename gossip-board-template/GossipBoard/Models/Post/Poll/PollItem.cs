using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GossipBoard.Models.Post.Poll
{
    public class PollItem
    {
        [Key]
        public int Id { get; set; }

        public string PollItemText { get; set; }
        public List<PollParticipant> PollItemParticipants { get; set; }

        public PollItem()
        {
            PollItemParticipants = new List<PollParticipant>(); 
        }
    }
}