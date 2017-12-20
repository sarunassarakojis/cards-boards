using GossipBoard.Models;
using GossipBoard.Models.Client;
using GossipBoard.Models.Post;
using GossipBoard.Models.Post.Media;
using GossipBoard.Models.Post.Poll;
using GossipBoard.Models.Post.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GossipBoard.Database
{
    public class DemoDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Clients { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<MediaPost> MediaPosts { get; set; }
        public DbSet<PollPost> PollPosts { get; set; }
        public DbSet<TextPostLike> TextPostLikes { get; set; }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        //to configure db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
