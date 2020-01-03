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
    public class RegisterController : ApiController
    {
        // GET: api/Register
            ProjectBL bl = new ProjectBL();

            static List<UserLibrary> examen = new List<UserLibrary>();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Register/5
        public IEnumerable<UserLibrary> Get()
        {
            examen = bl.GetRegisterDetails();
            return examen;
        }
       

        // POST: api/Register
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}
