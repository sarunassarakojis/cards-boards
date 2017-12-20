using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post.Poll;

namespace GossipBoard.Repositories
{
    public interface IPollPostRepository
    {
        Task<PollPost> GetPollPostById(int id);

        Task<ICollection<PollPost>> GetAllPollPosts(int offset, int limit);

        Task<PollPost> Create(PollPost pollPost);

        Task<PollPost> Update(PollPost updatedPollPost);

        Task<bool> Delete(int id);
    }
}