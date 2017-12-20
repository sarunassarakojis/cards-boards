using System.ComponentModel.DataAnnotations;

namespace GossipBoard.Models.Post.Media
{
    public class ImagePath
    {
        [Key]
        public int ImagePathId { get; set; }

        public string Path { get; set; }
    }
}