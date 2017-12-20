using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GossipBoard.Services
{
    public class DummyMailService : IMailService
    {
        public async Task Send(string message)
        {
            //send message
        }
    }
}
