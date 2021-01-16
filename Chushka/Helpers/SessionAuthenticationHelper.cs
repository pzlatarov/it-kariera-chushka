using Chushka.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Helpers
{
    public class SessionAuthenticationHelper : IAuthenticationHelper
    {
        private ISession _session;

        public SessionAuthenticationHelper(ISession session)
        {
            this._session = session;
        }

        public void SaveState( User user)
        {
            _session.SetInt32("userId", user.Id);
        }

        public User RetrieveFromSession()
        {
            var userId = _session.GetInt32("userId");
            if(userId != 0)
            {
                using(var context = new ChushkaContext())
                {
                    var userResult = from u in context.Users where u.Id == userId select u;
                    return userResult.FirstOrDefault();
                }
            }
            return null;
        }

        public bool IsUserAuthenticated()
        {
            return this.RetrieveFromSession() != null;
        }

        public bool IsUserInRole(Role role)
        {
            var user = this.RetrieveFromSession();
            return user != null && user.Role == role;
        }
    }
}
