using System.Collections.Generic;

namespace GossipBoard.Models.Post.Media
{
    public class MediaPost : Post
    {
        public List<ImagePath> ImageUrls { get; set; }
        public string VideoUrl { get; set; }
        public List<MediaPostLike> Likes { get; set; }

        public MediaPost()
        {
            ImageUrls = new List<ImagePath>();
            Likes = new List<MediaPostLike>();
        }
    }
}