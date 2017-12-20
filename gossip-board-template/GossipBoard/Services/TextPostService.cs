using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post.Text;
using GossipBoard.Repositories;

namespace GossipBoard.Services
{
    public class TextPostService : ITextPostService
    {
        private readonly ITextPostRepository _repository;

        public TextPostService(ITextPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<TextPost> GetTextPostById(int id)
        {
            var textPost = await _repository.GetTextPostById(id);
            return textPost;
        }

        public async Task<ICollection<TextPost>> GetAllTextPosts(int offset, int limit)
        {
            var textPosts = await _repository.GetAllTextPosts(offset, limit);
            return textPosts;
        }

        public async Task<TextPost> Create(TextPost textPost)
        {
            var newTextPost = await _repository.Create(textPost);
            return newTextPost;
        }

        public async Task<TextPost> Update(TextPost textPost)
        {
            var updatedTextPost = await _repository.Update(textPost);
            return updatedTextPost;
        }

        public async Task<bool> Delete(int id)
        {
            var operationMessage = await _repository.Delete(id);
            return operationMessage;
        }

        public async Task<TextPostLike> Like(TextPostLike textPostLike)
        {
            var result = await _repository.Like(textPostLike);
            return result;
        }
    }
}
