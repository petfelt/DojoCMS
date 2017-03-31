using System;

namespace DojoCMS.Models
{

    public class User : BaseEntity
    {
        public int ID {get;set;}
        public string name {get;set;}

        public string email {get;set;}

        public string password {get;set;}
        public DateTime created_at {get;set;}

        public User(){
            created_at = DateTime.Now;
            
        }
    }
}