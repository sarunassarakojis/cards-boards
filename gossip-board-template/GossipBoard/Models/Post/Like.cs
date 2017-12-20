using System.ComponentModel.DataAnnotations;
using GossipBoard.Models.Client;

namespace GossipBoard.Models.Post
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public User LikeOwner { get; set; }
    }
}