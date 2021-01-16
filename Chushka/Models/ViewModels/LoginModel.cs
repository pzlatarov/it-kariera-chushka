using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Models.ViewModels
{
    public class LoginModel
    {
        [DisplayName("User name")]
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public User AuthenticateUser()
        {
            using(var context = new ChushkaContext())
            {
                var userResult = from u in context.Users where u.Username == this.Username && u.Password == this.Password select u;
                return userResult.FirstOrDefault();
            }
        }
    }
}
