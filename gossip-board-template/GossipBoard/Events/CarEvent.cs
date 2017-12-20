using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GossipBoard.Events
{
    public class CarEvent : HubEvent
    {
        [JsonProperty("id")]
        public int Id { get; }

        public CarEvent(HubEvents eventType, int id) : base(eventType)
        {
            Id = id;
        }
    }
}
