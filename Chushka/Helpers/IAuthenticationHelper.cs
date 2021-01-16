using Chushka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Helpers
{
    public interface IAuthenticationHelper
    {
        public void SaveState(User user);
        public User RetrieveFromSession();
        public bool IsUserAuthenticated();
        public bool IsUserInRole(Role role);


    }
}
