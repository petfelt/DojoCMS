using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DojoCMS.Models;

namespace DojoCMS.Blog.Models
{

    public class Post : BaseEntity
    {

        [Key]
        public int id { get; set; }

        public int userId {get; set;}

        public User user {get; set;}
        
        public string post {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public List<Comment> Comments {get; set;}

        
        public Post(){
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            Comments =  new List<Comment>();
        }
    }
}