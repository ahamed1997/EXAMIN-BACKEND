using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamenUserLibrary;
using ExamenBL;
using System.Web.Http.Cors;

namespace ExamenProjectAngular.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]

    public class AdminValuesController : ApiController
    {
        static List<UserLibrary> examen = new List<UserLibrary>();
        ProjectBL bl = new ProjectBL();

        // GET api/values
        public IEnumerable<UserLibrary> Get()
        {
           examen = bl.GetQuestionsAndAnswers();
            return examen;
        }

        // GET api/values/5

        public bool Get(DateTime today)
        {
            return false;
        }
        public List<UserLibrary> Get(string testtype)
        {
            List<UserLibrary> examen = new List<UserLibrary>();
           examen = bl.GetTestTypeQuestions(testtype);
            return examen;
        }
        // POST api/values
        public UserLibrary Post([FromBody]UserLibrary examen)
        {
            if (User != null)
                return bl.AddQuestions(examen);
            else
                return new UserLibrary();
        }

        // PUT api/values/5
        public UserLibrary Put([FromBody]UserLibrary examen)
        {
            //var user = (from u in examen
            //            where u.SNo == id
            //            select u).First();

            if (User != null)
                return bl.UpdateQuestion(examen);
            else
                return examen;
        }

        // DELETE api/values/5
        public string Delete(int Sno)
        {
             return bl.DeleteQuestionAndAnswer(Sno);
           


        }
    }
}
