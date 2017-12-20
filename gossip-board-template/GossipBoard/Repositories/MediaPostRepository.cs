using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Database;
using GossipBoard.Models.Post.Media;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Repositories
{
    public class MediaPostRepository : IMediaPostRepository
    {
        private readonly DbSet<MediaPost> _mediaPosts;
        private readonly DbContext _context;

        public MediaPostRepository(DemoDbContext context)
        {
            _mediaPosts = context.MediaPosts;
            _context = context;
        }

        public async Task<MediaPost> GetMediaPostById(int id)
        {
            return await _mediaPosts.Include(media => media.ImageUrls)
                .Include(media => media.PostAuthor)
                .Include(media => media.Likes)
                .ThenInclude(like => like.LikeOwner)
                .SingleAsync(media => media.Id == id);
        }

        public async Task<ICollection<MediaPost>> GetAllMediaPosts(int offset, int limit)
        {
            return await _mediaPosts.Include(media => media.ImageUrls)
                .Include(media => media.PostAuthor)
                .Include(media => media.Likes)
                .ThenInclude(like => like.LikeOwner)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
        }

        public async Task<MediaPost> Create(MediaPost newMediaPost)
        {
            await _mediaPosts.AddAsync(newMediaPost);
            await _context.SaveChangesAsync();
            return newMediaPost;
        }

        public async Task<MediaPost> Update(MediaPost updatedMediaPost)
        {
            var existingMediaPost = _mediaPosts.FirstOrDefault(c => c.Id == updatedMediaPost.Id);
            _mediaPosts.Update(existingMediaPost);
            MapUpdatedValues(existingMediaPost, updatedMediaPost);

            await _context.SaveChangesAsync();
            return existingMediaPost;
        }

        public async Task<bool> Delete(int id)
        {
            var existingMediaPost = GetMediaPostById(id).Result;
            if (_mediaPosts.Remove(existingMediaPost) == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        private static void MapUpdatedValues(MediaPost existingMediaPost, MediaPost updatedMediaPost)
        {
            existingMediaPost.Subject = updatedMediaPost.Subject;
            existingMediaPost.Description = updatedMediaPost.Description;
            existingMediaPost.ImageUrls = updatedMediaPost.ImageUrls;
            existingMediaPost.VideoUrl = updatedMediaPost.VideoUrl;
        }
    }
}