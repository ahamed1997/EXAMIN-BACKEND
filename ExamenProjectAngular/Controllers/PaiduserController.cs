using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenBL;
using System.Web.Http.Cors;
using ExamenUserLibrary;

namespace ExamenProjectAngular.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class PaiduserController : ApiController
    {
        // GET: api/Paiduser
        ProjectBL bl = new ProjectBL();

        static List<UserLibrary> examen = new List<UserLibrary>();
        public IEnumerable<UserLibrary> Get()
        {
            examen = bl.GetPaidUserDetails();
            return examen;
        }
        public int Get(int Currentsno, string Useranswer, int Userflag, string Answer, string testid)
        {
            return bl.StoreTempScore(Currentsno, Useranswer, Userflag, Answer, testid);
        }

        // GET: api/Paiduser/5


        // POST: api/Paiduser
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Paiduser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Paiduser/5
        public void Delete(int id)
        {
        }
    }
}
