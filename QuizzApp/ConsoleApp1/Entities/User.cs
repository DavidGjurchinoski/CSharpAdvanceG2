using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User(string userName, string password, Role role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }
    }
}
