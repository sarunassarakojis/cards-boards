using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GossipBoard.Events
{
    public class HubEvent
    {
        protected HubEvent(HubEvents eventType)
        {
            EventType = eventType;
        }

        [JsonProperty("eventType")]
        public HubEvents EventType { get; }
    }
}
