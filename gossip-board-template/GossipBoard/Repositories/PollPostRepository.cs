using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Database;
using GossipBoard.Models.Post.Poll;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Repositories
{
    public class PollPostRepository : IPollPostRepository
    {
        private readonly DbSet<PollPost> _pollPosts;
        private readonly DbContext _context;

        public PollPostRepository(DemoDbContext context)
        {
            _pollPosts = context.PollPosts;
            _context = context;
        }

        public async Task<PollPost> GetPollPostById(int id)
        {
            var pollPostById = await _pollPosts.Include(poll => poll.PostAuthor)
                .Include(poll => poll.PollItems)
                .ThenInclude(item => item.PollItemParticipants)
                .ThenInclude(participant => participant.PollUser)
                .Include(poll => poll.Likes)
                .ThenInclude(like => like.LikeOwner)
                .SingleAsync(poll => poll.Id == id);
            return pollPostById;
        }

        public async Task<ICollection<PollPost>> GetAllPollPosts(int offset, int limit)
        {
            var posts = await _pollPosts.Include(poll => poll.PostAuthor)
                .Include(poll => poll.PollItems)
                .ThenInclude(item => item.PollItemParticipants)
                .ThenInclude(participant => participant.PollUser)
                .Include(poll => poll.Likes)
                .ThenInclude(like => like.LikeOwner)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();

            return posts;
        }

        public async Task<PollPost> Create(PollPost pollPost)
        {
            await _pollPosts.AddAsync(pollPost);
            await _context.SaveChangesAsync();
            return pollPost;
        }

        public async Task<PollPost> Update(PollPost updatedPollPost)
        {
            var existingPollPost = GetPollPostById(updatedPollPost.Id).Result;
            _pollPosts.Update(existingPollPost);
            MapUpdatedValues(existingPollPost, updatedPollPost);

            await _context.SaveChangesAsync();
            return existingPollPost;
        }

        public async Task<bool> Delete(int id)
        {
            var existingPollPost = GetPollPostById(id).Result;
            if (_pollPosts.Remove(existingPollPost) == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        private static void MapUpdatedValues(PollPost existingPollPost, PollPost updatedPollPost)
        {
            existingPollPost.Subject = updatedPollPost.Subject;
            existingPollPost.Description = updatedPollPost.Description;
            existingPollPost.PollItems = updatedPollPost.PollItems;
        }
    }
}