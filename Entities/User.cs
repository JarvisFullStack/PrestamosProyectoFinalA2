using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {

        }

        public User(int id_User, string name, string lastName, string userName, string password, DateTime createdAt)
        {
            Id_User = id_User;
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            CreatedAt = createdAt;
        }
    }
}
