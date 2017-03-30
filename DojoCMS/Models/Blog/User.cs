using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DojoCMS.Models;

namespace DojoCMS.Blog.Models
{

    public class User : BaseEntity
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "First Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$", ErrorMessage = "#s or special  Characters are not allowed.")]
        [RequiredAttribute(ErrorMessage = "First and Last Name is required")]
        [MinLengthAttribute(4)]
        public string name { get; set; }
       

        [RequiredAttribute]
        [EmailAddressAttribute]
        public string email { get; set; }

        [RequiredAttribute]
        [MinLengthAttribute(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public List<Comment> Comments {get; set;}
        public List<Post> Posts {get;  set;}


        public User(){

            Comments =  new List<Comment>();
            Posts = new List<Post>();
        }
    }
}