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

    public class CompareController : ApiController
    {
        ProjectBL bl = new ProjectBL();

        static List<UserLibrary> examen = new List<UserLibrary>();
        // GET: api/Compare
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Compare/5
        public bool Get(string Compa)
        {
            String test = DateTime.Now.ToString("yyy/MM/dd");
            //DateTime emer = DateTime.Now.ToShortDateString();
            if(Compa==test)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<UserLibrary> Get(string Username, string Teststatus)
        {
            return bl.GetUpcomingTestResults(Username, Teststatus);
        }
        // POST: api/Compare
        public void Post([FromBody]string value)
        {
        }
        


        // PUT: api/Compare/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Compare/5
        public void Delete(int id)
        {
        }
    }
}
