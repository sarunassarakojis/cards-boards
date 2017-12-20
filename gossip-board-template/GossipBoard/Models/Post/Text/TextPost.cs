using System.Collections.Generic;

namespace GossipBoard.Models.Post.Text
{
    public class TextPost : Post
    {
        public List<TextPostLike> Likes { get; set; }

        public TextPost()
        {
            Likes = new List<TextPostLike>();
        }
    }
}