using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Database;
using GossipBoard.Models.Post.Text;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Repositories
{
    public class TextPostRepository : ITextPostRepository
    {
        private readonly DbSet<TextPost> _textPosts;
        private readonly DbSet<TextPostLike> _textPostLikes;
        private readonly DbContext _context;

        public TextPostRepository(DemoDbContext context)
        {
            _textPosts = context.TextPosts;
            _textPostLikes = context.TextPostLikes;
            _context = context;
        }

        public async Task<TextPost> GetTextPostById(int id)
        {
            return await _textPosts.Include(text => text.PostAuthor)
                .Include(text => text.Likes)
                .ThenInclude(like => like.LikeOwner)
                .SingleAsync(text => text.Id == id);
        }

        public async Task<ICollection<TextPost>> GetAllTextPosts(int offset, int limit)
        {
            return await _textPosts.Include(text => text.PostAuthor)
                .Include(text => text.Likes)
                .ThenInclude(like => like.LikeOwner)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
        }

        public async Task<TextPost> Create(TextPost textPost)
        {
            await _textPosts.AddAsync(textPost);
            await _context.SaveChangesAsync();
            return textPost;
        }

        public async Task<TextPost> Update(TextPost updatedTextPost)
        {
            var existingTextPost = _textPosts.FirstOrDefault(c => c.Id == updatedTextPost.Id);
            _textPosts.Update(existingTextPost);
            MapUpdatedValues(existingTextPost, updatedTextPost);

            await _context.SaveChangesAsync();
            return existingTextPost;
        }

        public async Task<bool> Delete(int id)
        {
            var existingTextPost = GetTextPostById(id).Result;
            if (_textPosts.Remove(existingTextPost) == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TextPostLike> Like(TextPostLike textPostLike)
        {
            await _textPostLikes.AddAsync(textPostLike);
            await _context.SaveChangesAsync();

            return textPostLike;
        }

        private static void MapUpdatedValues(TextPost existingTextPost, TextPost updatedTextPost)
        {
            existingTextPost.Subject = updatedTextPost.Subject;
            existingTextPost.Description = updatedTextPost.Description;
        }
    }
}