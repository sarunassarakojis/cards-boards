using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post;
using GossipBoard.Models.Post.Media;
using GossipBoard.Repositories;

namespace GossipBoard.Services
{
    public class MediaPostService : IMediaPostService
    {
        private readonly IMediaPostRepository _repository;

        public MediaPostService(IMediaPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<MediaPost> GetMediaPostById(int id)
        {
            var mediaPost = await _repository.GetMediaPostById(id);
            return mediaPost;
        }

        public async Task<ICollection<MediaPost>> GetAllMediaPosts(int offset, int limit)
        {
            var mediaPosts = await _repository.GetAllMediaPosts(offset, limit);
            return mediaPosts;
        }

        public async Task<MediaPost> Create(MediaPost mediaPost)
        {
            var newMediaPost = await _repository.Create(mediaPost);
            return newMediaPost;
        }

        public async Task<MediaPost> Update(MediaPost mediaPost)
        {
            var updatedMediaPost = await _repository.Update(mediaPost);
            return updatedMediaPost;
        }

        public async Task<bool> Delete(int id)
        {
            var operationMessage = await _repository.Delete(id);
            return operationMessage;
        }
    }
}
