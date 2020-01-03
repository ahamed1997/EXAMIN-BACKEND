using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenBL;
using System.Web.Http.Cors;
using System.Net.Mail;
using System.Threading;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecondAPIProject.Models;
using System.Security.Claims;
using ExamenProjectAngular.Models;

namespace SecondAPIProject.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class AccountController : ApiController
    {
        static List<AccountModel> users = new List<AccountModel>();
        ProjectBL bl = new ProjectBL();
        // GET: Auth
        [Route("api/check/Registration")]
        [HttpPost]
        [AllowAnonymous]
        //public IdentityResult Register(AccountModel model)
        public bool Register(AccountModel model)
        {
            try
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser() { UserName = model.Username, Email = model.Email };
                user.Name = model.Name;
                user.Phone = model.Phone;
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1
                };
                IdentityResult result = manager.Create(user, model.Password);
                bl.InsertNewUser(model.Phone, model.Email,model.Name, model.Username,model.Password);
                return true;
            }
            catch (Exception)
            {
                //IdentityResult result = null;
                return false;
            }
            
        }
        [Route("api/getuserdetails")]
        [HttpGet]
     
        public AccountModel Getuserdetails()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel ()
            {
                Username = identityClaims.FindFirst("Username").Value,
                Phone = identityClaims.FindFirst("Phone").Value,
                Email = identityClaims.FindFirst("Email").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value

            };
            return model;
        }
        [Route("api/Authentication/Check")]
         [HttpGet]
        [AllowAnonymous]
        public Boolean Check(string Email)
        {
            string pass = bl.ForgotPassword(Email);
            if (pass != null && pass != "")
            {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("priyasundar298@gmail.com");
                mm.To.Add(Email);
                mm.Subject = "forgot password";
                mm.Body = pass.ToUpper();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
               // smtp.UseDefaultCredentials = true;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("priyasundar298@gmail.com", "Priyasundar2908@");
               // smtp.UseDefaultCredentials = true;
                smtp.Send(mm);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}