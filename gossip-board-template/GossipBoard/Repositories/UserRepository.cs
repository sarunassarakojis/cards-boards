using System.Linq;
using GossipBoard.Database;
using GossipBoard.Models.Client;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ApplicationUser> _applicationUsers;

        public UserRepository(DemoDbContext context)
        {
            _context = context;
            _applicationUsers = context.Users;
        }

        public User GetById(string id)
        {
            var user = _applicationUsers
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id)
                .User;
            return user;
        }
    }
}
