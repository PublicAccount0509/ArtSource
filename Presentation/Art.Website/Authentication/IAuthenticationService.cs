using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(string userId, bool createPersistentCookie);
        void SignOut();
        //Customer GetAuthenticatedCustomer();
    }
}