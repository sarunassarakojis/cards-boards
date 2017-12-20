using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post;
using GossipBoard.Models.Post.Media;

namespace GossipBoard.Services
{
    public interface IMediaPostService
    {
        Task<MediaPost> GetMediaPostById(int id);
        Task<ICollection<MediaPost>> GetAllMediaPosts(int offset, int limit);
        Task<MediaPost> Create(MediaPost mediaPost);
        Task<MediaPost> Update(MediaPost mediaPost);
        Task<bool> Delete(int id);
    }
}
