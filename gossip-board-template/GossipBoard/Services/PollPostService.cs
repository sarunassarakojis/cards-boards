using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post.Poll;
using GossipBoard.Repositories;

namespace GossipBoard.Services
{
    public class PollPostService : IPollPostService
    {
        private readonly IPollPostRepository _repository;

        public PollPostService(IPollPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<PollPost> GetPollPostById(int id)
        {
            return await _repository.GetPollPostById(id);
        }

        public async Task<ICollection<PollPost>> GetAllPollPosts(int offset, int limit)
        {
            return await _repository.GetAllPollPosts(offset, limit);
        }

        public async Task<PollPost> Create(PollPost pollPost)
        {
            return await _repository.Create(pollPost);
        }

        public async Task<PollPost> Update(PollPost pollPost)
        {
            return await _repository.Update(pollPost);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}