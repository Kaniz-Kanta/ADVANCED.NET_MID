using Lecture3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture3.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess:AuthorizeAttribute
    {
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag=  base.AuthorizeCore(httpContext);
            if (flag)
            {
                var Username = httpContext.User.Identity.Name;
                var db = new Database();
                //string Username = null;
                var type = db.Users.GetUserType(Username);
                if (type == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}