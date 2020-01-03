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
    [EnableCors("http://localhost:4200", "*", "GET,PUT,POST")]
    public class ValuesController : ApiController
    {
        ProjectBL bl = new ProjectBL();
        UserLibrary user = new UserLibrary();
        static List<UserLibrary> users = new List<UserLibrary>();
        // GET api/values
        //public IEnumerable<UserLibrary> Get()
        //{
        //    users = bl.GetAllUsers();
        //    return users;
        //}
        
        public IEnumerable<UserLibrary> Get(int id)
        {
            return bl.ScoresforChart(id);
        }
        public IEnumerable<UserLibrary> Get(string testmodel)
        {
            users = bl.DisplayQuestionsforTest(testmodel);
            return users;
        }
        //public IEnumerable<UserLibrary> Get(string[] Sno,int Qno)
        //{

        //    string[] no = Sno;



        //    //var Questions = bl.ReturnQuestionsByQno(Sno, Qno).Select(x =>
        //    //new
        //    //{
        //    //    Qno = x.Qno,
        //    //    Question = x.Question,
        //    //    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
        //    //    Answer = x.Answer,
        //    //    Sno = x.Sno,
        //    //    Testmodel = x.Testmodel

        //    //}).ToList();

        //    return users;
        //}
        
        public IEnumerable<UserLibrary> Get(int Sno, int Qno,string Testid)
        {
            
            users = bl.ReturnQuestionsByQno(Sno, Qno,Testid);

            //var Questions = bl.ReturnQuestionsByQno(Sno, Qno).Select(x =>
            //new
            //{
            //    Qno = x.Qno,
            //    Question = x.Question,
            //    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
            //    Answer = x.Answer,
            //    Sno = x.Sno,
            //    Testmodel = x.Testmodel

            //}).ToList();

            return users;
        }
       
        //public bool Get()
        //{
        //    bool result = bl.LogInUserValidation(user);
        //    if (result)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;


        //}
        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST api/values
        public bool Post([FromBody]UserLibrary value)
        {
            if (User != null)
            {
                return bl.LogInUserValidation(value);

            }
            else
                return false;
        }
        

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
