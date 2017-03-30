using System.ComponentModel.DataAnnotations;

namespace DojoCMS.Models
{

    public class User : BaseEntity
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$", ErrorMessage = "#s or special  Characters are not allowed.")]
        [RequiredAttribute(ErrorMessage = "First Name is required")]
        [MinLengthAttribute(2)]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$", ErrorMessage = "#s or special Characters are not allowed.")]
        [RequiredAttribute(ErrorMessage = "Last Name is required")]
        [MinLengthAttribute(2)]
        public string lastName { get; set; }

        [RequiredAttribute]
        [EmailAddressAttribute]
        public string email { get; set; }

        [RequiredAttribute]
        [MinLengthAttribute(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
    }
}