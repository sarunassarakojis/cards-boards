using System.Collections.Generic;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Post.Text;

namespace GossipBoard.Services
{
    public interface ITextPostService
    {
        Task<TextPost> GetTextPostById(int id);
        Task<ICollection<TextPost>> GetAllTextPosts(int offset, int limit);
        Task<TextPost> Create(TextPost textPost);
        Task<TextPost> Update(TextPost textPost);
        Task<bool> Delete(int id);
        Task<TextPostLike> Like(TextPostLike textPostLike);
    }
}
