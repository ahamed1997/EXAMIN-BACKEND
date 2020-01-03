using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenDAL;
using ExamenUserLibrary;


namespace ExamenBL
{
    public class ProjectBL
    {
        ProjectDAL dal;
        int result=0;
        
        public ProjectBL()
        {
           dal = new ProjectDAL();
        }
        public bool LogInUserValidation(UserLibrary user)
        {
            return dal.LogInValidation(user);
        }
        public bool AdminLogInUserValidation(UserLibrary user)
        {
            return dal.AdminLogInValidation(user);
        }
        
        public List<UserLibrary> GetAllUsers()
        {
            return dal.GetAllUsers();
        }
        public List<UserLibrary> DisplayQuestionsforTest(string testmodel)
        {
            return dal.DisplayQuestionsforTest(testmodel);
        }
        public List<UserLibrary> ReturnQuestionsByQno (int Sno,int Qno,string Testid)
        {
            
            int flag = dal.RetrieveFlag(Sno,Testid);         

            return dal.SelectQuestionsBySno(Sno,Qno,flag);
        }
        public int StoreTempScore(int Currentsno, string Useranswer, int Userflag,string Answer,string testid)
        {
            
            
            if (Useranswer != "")
            {
                if (Useranswer == Answer)
                {
                    int score = 1;
                    return dal.StoreTempScore(Currentsno, Userflag,score,testid);
                }
                else 
                {
                    int score = 0;
                    return dal.StoreTempScore(Currentsno,  Userflag,score,testid);
                }
                

            }
            else
            {
                return 0;
            }
        }
       
        public List<UserLibrary> ScoresforChart(int Sno)
        {
            return dal.ScoresforChart(Sno);
        }
        public bool InsertNewUser(string phone,string Email,string name, string username,string password)
        {
            return dal.InsertNewUser(phone,Email,name,username,password);
        }

        public bool InsertintoPayment(string paymentmode, UserLibrary user)
        {
            string num = "123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdigit = 5;
            string finaldigit;
            int getindex;
            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                } while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }
            string testid = otp;

            return dal.InsertintoPayment(paymentmode, testid, user);         
        }
        public List<UserLibrary> BlGetuserData(string username)
        {
            String test = DateTime.Now.ToString("yyy/MM/dd");
            dal.UpdateExpired(username,test);
            return dal.GetUserDetail(username);
        }
        public bool UpdateTestStatus(string testid)
        {
            return dal.UpdateTestStatus(testid);
        }


        public string ForgotPassword(string email)
        {
            return dal.ForgotPassword(email);
        }
        public int UpdateFinalStatus(string username, string Testid, string Testmodel)
        {
            result = dal.GetFinalScoreOfCandidate(Testid);
           
            dal.UpdateFinalStatus(username, Testid, Testmodel, result);
            dal.UpdateMainTableAfterTest(Testid, result);
           dal.Delete(Testid);
            return result;
        }
        public List<UserLibrary> GetUpcomingTestResults(string Username, string teststatus)
        {
            return dal.GetUpcomingTestResults(Username, teststatus);
        }


        /*ADMIN MODULES*/
        public List<UserLibrary> GetAllQuestionsandAnswers(string testmodel)
        {
            return dal.GetAllQuestions(testmodel);
        }
        public List<UserLibrary> GetQuestionsAndAnswers()
        {
            return dal.GetQuestions();
        }
        public UserLibrary AddQuestions(UserLibrary examen)
        {
            return dal.AddQuestions(examen);
        }
        public List<UserLibrary> GetTestTypeQuestions(string testType)
        {
            return dal.GetTestType(testType);
        }
        public UserLibrary UpdateQuestion(UserLibrary examen)
        {
            return dal.UpdateQuestion(examen);
        }
        public string DeleteQuestionAndAnswer(int Sno)
        {
            return dal.DeleteQuestion(Sno);
        }
        public List<UserLibrary> GetAdminDetails()
        {
            return dal.GetAdminDetails();
        }
        public List<UserLibrary> GetRegisterDetails()
        {
            return dal.GetRegisterDetails();
        }
        public List<UserLibrary> GetPaidUserDetails()
        {
            return dal.GetPaidUsers();
        }
        
    }
}
