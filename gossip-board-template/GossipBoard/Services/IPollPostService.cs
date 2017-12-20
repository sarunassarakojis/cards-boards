using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post.Poll;

namespace GossipBoard.Services
{
    public interface IPollPostService
    {
        Task<PollPost> GetPollPostById(int id);
        Task<ICollection<PollPost>> GetAllPollPosts(int offset, int limit);
        Task<PollPost> Create(PollPost pollPost);
        Task<PollPost> Update(PollPost pollPost);
        Task<bool> Delete(int id);
    }
}