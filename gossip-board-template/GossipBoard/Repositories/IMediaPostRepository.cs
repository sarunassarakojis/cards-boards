using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post;
using GossipBoard.Models.Post.Media;

namespace GossipBoard.Repositories
{
    public interface IMediaPostRepository
    {
        Task<MediaPost> GetMediaPostById(int id);

        Task<ICollection<MediaPost>> GetAllMediaPosts(int offset, int limit);

        Task<MediaPost> Create(MediaPost mediaPost);

        Task<MediaPost> Update(MediaPost mediaPost);

        Task<bool> Delete(int id);
    }
}
