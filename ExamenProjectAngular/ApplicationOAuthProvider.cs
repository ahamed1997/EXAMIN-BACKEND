using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ExamenUserLibrary;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenBL;
using System.Web.Http.Cors;
using System.Net.Mail;
using System.Threading;
using System.Security.Principal;

using SecondAPIProject.Models;
using System.Security.Claims;
using ExamenProjectAngular.Models;


namespace SecondAPIProject.Controllers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("Name", user.Name));
                identity.AddClaim(new Claim("Phone", user.Phone));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                context.Validated(identity);
            }
            else
            {
                return;
            }
        }
    }
}