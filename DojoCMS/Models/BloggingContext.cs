using System.Collections.Generic;
using System.Linq;
using DojoCMS.Blog.Models;
using Microsoft.EntityFrameworkCore;



namespace DojoCMS
{

    public class BloggingContext : DbContext
    {

        // base() calls the parent class' constructor passing the "options" parameter along
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }


        public List<Post> GetAll()
        {
            return this.Posts
                .Include(post => post.user)
                .Include(post => post.Comments)                  
                .ToList();
        }


        public void AddPost(Post info, int UserId)
        {
            info.userId = UserId;
            this.Posts.Add(info);
            this.SaveChanges();
        }

        public void AddComment(int PostId, int UserId, Comment info)
        {
            info.postId = PostId;
            info.userId = UserId;
            this.Comments.Add(info);
            this.SaveChanges();
        }


        public void RemovePost(int PostId)
        {
            this.Posts.RemoveRange(this.Posts.Where(p => p.id == PostId));
            this.SaveChanges();
        }

        public void RemoveComment(int CommentId)
        {

            this.Comments.RemoveRange(this.Comments.Where(c => c.id == CommentId));
            this.SaveChanges();
        }
    }

}