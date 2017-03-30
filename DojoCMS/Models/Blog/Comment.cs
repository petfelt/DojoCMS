using System;
using System.ComponentModel.DataAnnotations;
using DojoCMS.Models;

namespace DojoCMS.Blog.Models
{

    public class Comment : BaseEntity
    {

        [Key]
        public int id { get; set;}

        public int userId {get; set;}

        public User user {get; set;}

        public int postId {get; set;}
        
        public Post post {get; set;}
        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        
        public Comment(){
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}