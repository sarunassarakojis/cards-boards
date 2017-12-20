using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GossipBoard.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string OtherInformation { get; set; }
        public string ImageUrl { get; set; }
    }
}
