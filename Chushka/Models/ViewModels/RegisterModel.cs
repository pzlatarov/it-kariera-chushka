using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Models.ViewModels
{
    public class RegisterModel
    {
        [DisplayName("User name")]
        [Required]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DisplayName("Full Name")]
        [Required]
        public string FullName { get; set; }

        public bool RegisterUser()
        {
            var userRole = Role.User;
            using (var context = new ChushkaContext())
            {
                if (!context.Users.Any())
                {
                    userRole = Role.Admin;
                }

                var result = context.Users.Add(new User() { 
                    Username = this.Username,
                    Password = this.Password,
                    Email = this.Email,
                    FullName = this.FullName,
                    Role = userRole
                });

                context.SaveChanges();

                return true;
            }
        }
    }
}
