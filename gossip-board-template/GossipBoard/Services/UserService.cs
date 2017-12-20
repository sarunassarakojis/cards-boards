using GossipBoard.Models.Client;
using GossipBoard.Repositories;

namespace GossipBoard.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User GetUserById(string id)
        {
            var user = _repository.GetById(id);
            return user;
        }
    }
}