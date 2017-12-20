using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GossipBoard.Services
{
    public interface IMailService
    {
        Task Send(string message);
    }
}
