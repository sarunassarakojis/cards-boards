using System.Collections.Generic;

namespace GossipBoard.Models.Post.Poll
{
    public class PollPost : Post
    {
        public List<PollItem> PollItems { get; set; }
        public List<PollPostLike> Likes { get; set; }

        public PollPost()
        {
            PollItems = new List<PollItem>();
            Likes = new List<PollPostLike>();
        }
    }
}