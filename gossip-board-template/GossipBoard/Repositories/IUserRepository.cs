using GossipBoard.Models.Client;

namespace GossipBoard.Repositories
{
    public interface IUserRepository
    {
        User GetById(string id);
    }
}