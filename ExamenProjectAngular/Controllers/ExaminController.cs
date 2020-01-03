using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenBL;
using ExamenUserLibrary;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace ExamenProjectAngular.Controllers
{
    public class ExaminController : ApiController
    {
        // GET: api/Examin
        ProjectBL bl = new ProjectBL();
        UserLibrary user = new UserLibrary();
        static List<UserLibrary> users = new List<UserLibrary>();
      

        // GET: api/Examin/5
        public IEnumerable<UserLibrary> Get()
        {
            users = bl.GetAdminDetails();
            return users;
        }
        public IEnumerable<UserLibrary> Get(string username)
        {
            users = bl.BlGetuserData(username);
            return users;
        }
        public bool Put(string testid)
        {
            return bl.UpdateTestStatus(testid);
        }
        public int Get(string username ,string Testid,string Testmodel)
        {
            return bl.UpdateFinalStatus(username, Testid, Testmodel);
        }
        // POST: api/Examin

        //public bool Post([FromBody]UserLibrary value)
        //{
        //    if (User != null)
        //    {
        //        return bl.AdminLogInUserValidation(value);

        //    }
        //    else
        //        return false;
        //}
        public bool put(string paymenttype, [FromBody]UserLibrary value)
        {
            return bl.InsertintoPayment(paymenttype,value);

        }
        // PUT: api/Examin/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Examin/5
        public void Delete(int id)
        {
        }
    }
}
