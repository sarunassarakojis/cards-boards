using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GossipBoard.Models.Client;

namespace GossipBoard.Models.Post
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public User PostAuthor { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
    }
}