using GossipBoard.Models.Client;

namespace GossipBoard.Services
{
    public interface IUserService
    {
        User GetUserById(string id);
    }
}