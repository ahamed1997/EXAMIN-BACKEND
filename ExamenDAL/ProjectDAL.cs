using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ExamenUserLibrary;



namespace ExamenDAL
{
    public class ProjectDAL
    {
        SqlConnection conn;
        SqlCommand cmdGetAllUsers, cmdAdminLogInUserValidation, cmdLogInUserValidation, cmdDisplayQuastions, cmdSelectBySno, cmdStoreTempFlag, cmdRetrieveFlag,cmdGetCandidateScore,cmdDelete,cmdGetScoresForChart;
        SqlCommand cmdAddQuestion, cmdUpdateQuestion, cmdGetTestQuestion, cmdGetQuestions, cmdGetAllQuestions, cmdDeleteQuestion, cmdGetRegisterDetails, cmdGetAdminDetails, cmdGetPaidUsers, cmdGetScoreDetails;
        SqlCommand cmdINsertUser, cmdGetUpcomingTestResults,cmdForgorPassword, cmdInsertPayment,cmdgetUserDetails,cmdUpdateTestStatus,cmdExpireUpdate,cmdUpdateFinalStatus,cmdUpdateScoresInMainTable;
        bool result = false;
        UserLibrary user;
        int flag,no = 0;

        public ProjectDAL()
        {

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connExamen"].ConnectionString);
        }
        public List<UserLibrary> GetAllUsers()
        {
            List<UserLibrary> users = new List<UserLibrary>();
            conn.Open();
            cmdGetAllUsers = new SqlCommand("proc_GetAllUsers", conn);
            SqlDataReader drUsers = cmdGetAllUsers.ExecuteReader();
            UserLibrary user = null;
            while (drUsers.Read())
            {
                user = new UserLibrary();
                user.Username = drUsers[1].ToString();
                user.Password = drUsers[0].ToString();
                users.Add(user);
            }
            conn.Close();
            return users;
        }
        public bool LogInValidation(UserLibrary user)
        {
            conn.Open();

            cmdLogInUserValidation = new SqlCommand("proc_UserValidation", conn);
            cmdLogInUserValidation.Parameters.AddWithValue("@p_Username", user.Username);
            cmdLogInUserValidation.Parameters.AddWithValue("@p_password", user.Password);
            cmdLogInUserValidation.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdLogInUserValidation.ExecuteReader();
            if (dataReader.HasRows == true)
            { result = true; }
            conn.Close();
            return result;

        }
        public List<UserLibrary> DisplayQuestionsforTest(string testmodel)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            List<UserLibrary> Options = new List<UserLibrary>();
            cmdDisplayQuastions = new SqlCommand("proc_GetAllQuestions", conn);
            cmdDisplayQuastions.Parameters.Add("@TestModel", SqlDbType.VarChar, 50);
            cmdDisplayQuastions.CommandType = CommandType.StoredProcedure;
            cmdDisplayQuastions.Parameters[0].Value = testmodel;
            SqlDataReader dataReader = cmdDisplayQuastions.ExecuteReader();
            while (dataReader.Read())
            {
                user = new UserLibrary();
                UserLibrary users = new UserLibrary();
                user.Sno = Convert.ToInt32(dataReader[0]);
                user.Testmodel = dataReader[1].ToString();
                user.Question = dataReader[2].ToString();
                user.Answer = dataReader[3].ToString();
                user.Option1 = (dataReader[4].ToString());
                user.Option3 = (dataReader[5].ToString());
                user.Option2 = (dataReader[6].ToString());
                user.Option4 = (dataReader[7].ToString());
                user.Mark = Convert.ToInt32(dataReader[8]);
                no = no + 1;
                user.Qno = no;

                examens.Add(user);
            }
            conn.Close();
            return examens;
        }
        public List<UserLibrary> SelectQuestionsBySno(int Sno, int Qno,int flags)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdSelectBySno = new SqlCommand("proc_SelectQuestionsBySno", conn);
            cmdSelectBySno.Parameters.AddWithValue("@sno", Sno);
            cmdSelectBySno.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdSelectBySno.ExecuteReader();
            while (dataReader.Read())
            {
                user = new UserLibrary();
                UserLibrary users = new UserLibrary();
                user.Sno = Convert.ToInt32(dataReader[0]);
                user.Testmodel = dataReader[1].ToString();
                user.Question = dataReader[2].ToString();
                user.Answer = dataReader[3].ToString();
                user.Option1 = (dataReader[4].ToString());
                user.Option3 = (dataReader[5].ToString());
                user.Option2 = (dataReader[6].ToString());
                user.Option4 = (dataReader[7].ToString());
                user.Mark = Convert.ToInt32(dataReader[8]);
                user.Flag = flags;
                user.Qno = Qno;
                examens.Add(user);
            }
            conn.Close();
            return examens;
        }
        public int StoreTempScore(int Sno, int flag,int score,string testid)
        {
            conn.Open();
            int scores = 0;
            cmdStoreTempFlag = new SqlCommand("proc_InsertScoreandFlag", conn);
            cmdStoreTempFlag.Parameters.AddWithValue("@sno", Sno);
            cmdStoreTempFlag.Parameters.AddWithValue("@userflag", flag);
            cmdStoreTempFlag.Parameters.AddWithValue("@score", score);
            cmdStoreTempFlag.Parameters.AddWithValue("@testid", testid);
            cmdStoreTempFlag.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdStoreTempFlag.ExecuteReader();            
            while(dataReader.Read())
            {
                scores = Convert.ToInt32(dataReader[0]);
            }

            conn.Close();
            return scores;

        }
        public int GetFinalScoreOfCandidate(string Testid)
        {
            int score = 0;
            conn.Open();
            cmdGetCandidateScore = new SqlCommand("proc_GetCandidateScore", conn);
            cmdGetCandidateScore.Parameters.AddWithValue("@testid", Testid);
            cmdGetCandidateScore.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader dataReader = cmdGetCandidateScore.ExecuteReader();
            while (dataReader.Read())
            {
                    score = Convert.ToInt32(dataReader[0]);
            }
           
            conn.Close();
            return score;

               
        }
        public bool Delete(string testid)
        {
            conn.Open();
            cmdDelete = new SqlCommand("proc_Truncate", conn);
            cmdDelete.Parameters.AddWithValue("@testid", testid);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        public int RetrieveFlag(int Sno,string testid)
        {
            conn.Open();
            cmdRetrieveFlag = new SqlCommand("proc_SelectFlag", conn);
            cmdRetrieveFlag.Parameters.AddWithValue("@sno", Sno);
            cmdRetrieveFlag.Parameters.AddWithValue("@testid", testid);
            cmdRetrieveFlag.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmdRetrieveFlag.ExecuteReader();
            while (reader.Read())
            {
                
                flag = Convert.ToInt32(reader[0]);
            }

            conn.Close();
            return flag;
        }
        public List<UserLibrary> ScoresforChart(int Sno)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetScoresForChart = new SqlCommand("proc_dummy", conn);
            cmdGetScoresForChart.Parameters.AddWithValue("@id", Sno);
            cmdGetScoresForChart.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdGetScoresForChart.ExecuteReader();
            while (dataReader.Read())
            {
                user = new UserLibrary();
                UserLibrary users = new UserLibrary();
                user.Sno = Convert.ToInt32(dataReader[0]);
               
                examens.Add(user);
            }
            conn.Close();
            return examens;
        }

        public bool InsertNewUser(string phone, string Email, string name, string username, string password)
        {
            conn.Open();
            cmdINsertUser = new SqlCommand("proc_InsertIntotblCandidates", conn);
            cmdINsertUser.Parameters.AddWithValue("@phone", phone);
            cmdINsertUser.Parameters.AddWithValue("@email", Email);
            cmdINsertUser.Parameters.AddWithValue("@username", username);
            cmdINsertUser.Parameters.AddWithValue("@password", password);
            cmdINsertUser.Parameters.AddWithValue("@name", name);
            cmdINsertUser.CommandType = CommandType.StoredProcedure;
            if (cmdINsertUser.ExecuteNonQuery() > 0)
            {
                result = true;
            }

            conn.Close();
            return result;

        }
        public string ForgotPassword(string email)
        {
            string pass = "";
            conn.Open();
            cmdForgorPassword = new SqlCommand("proc_ForgotPassword", conn);
            cmdForgorPassword.Parameters.AddWithValue("@mail", email);
            cmdForgorPassword.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdForgorPassword.ExecuteReader();
            while (dataReader.Read())
            {
                pass = dataReader[0].ToString();
            }
            conn.Close();
            return pass;
        }
        public bool InsertintoPayment(string paymenttype, string testid, UserLibrary user)
        {
            
            conn.Open();
            string teststatus = "Upcoming";
            int res = 0;
            String payeddate = DateTime.Now.ToString("yyy/MM/dd");
            string cancelledate = "InProgress";
            cmdInsertPayment = new SqlCommand("proc_InsertIntoPaymentTable", conn);
            cmdInsertPayment.Parameters.AddWithValue("@username", user.Username);
            cmdInsertPayment.Parameters.AddWithValue("@testid", testid);
            cmdInsertPayment.Parameters.AddWithValue("@testmodel", user.Testmodel);
            cmdInsertPayment.Parameters.AddWithValue("@testdate", user.Testdate);
            cmdInsertPayment.Parameters.AddWithValue("@paymentmode", paymenttype);
            cmdInsertPayment.Parameters.AddWithValue("@teststatus", teststatus);
            cmdInsertPayment.Parameters.AddWithValue("@result", res);
            cmdInsertPayment.Parameters.AddWithValue("@payeddate", payeddate);
            cmdInsertPayment.Parameters.AddWithValue("@cancelleddate", cancelledate);
            cmdInsertPayment.CommandType = CommandType.StoredProcedure;
            if (cmdInsertPayment.ExecuteNonQuery() > 0)
            {
                result = true;
            }


            conn.Close();
            return result;
        }
        public List<UserLibrary> GetUserDetail(string username)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();

            cmdgetUserDetails = new SqlCommand("proc_GetuserData", conn);
            cmdgetUserDetails.Parameters.AddWithValue("@username", username);
            
            cmdgetUserDetails.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdgetUserDetails.ExecuteReader();
            while (dataReader.Read())
            {
                user = new UserLibrary();
                UserLibrary users = new UserLibrary();
                user.Username = dataReader[0].ToString();
                user.Testid = dataReader[1].ToString();
                user.Testmodel = dataReader[2].ToString();
                //user.Testdate = (Convert.ToDateTime(dataReader[3]));
                user.Testdate = dataReader[3].ToString();
                user.Paymentmode = dataReader[4].ToString();                
                user.Teststatus = dataReader[5].ToString();
                user.Result = Convert.ToInt32(dataReader[6]);
                user.Payeddate = dataReader[7].ToString();
                user.Cancelleddate = dataReader[8].ToString();
                examens.Add(user);
            }
                conn.Close();
            return examens;
        }
        public List<UserLibrary> GetUpcomingTestResults(string Username, string Teststatus)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();

            cmdGetUpcomingTestResults = new SqlCommand("proc_GetUpcomingTestResults", conn);
            cmdGetUpcomingTestResults.Parameters.AddWithValue("@username", Username);
            cmdGetUpcomingTestResults.Parameters.AddWithValue("@teststatus", Teststatus);
            cmdGetUpcomingTestResults.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdGetUpcomingTestResults.ExecuteReader();
            while (dataReader.Read())
            {
                user = new UserLibrary();
                UserLibrary users = new UserLibrary();
                user.Username = dataReader[0].ToString();
                user.Testid = dataReader[1].ToString();
                user.Testmodel = dataReader[2].ToString();
                //user.Testdate = (Convert.ToDateTime(dataReader[3]));
                user.Testdate = dataReader[3].ToString();
                user.Paymentmode = dataReader[4].ToString();
                user.Teststatus = dataReader[5].ToString();
                user.Result = Convert.ToInt32(dataReader[6]);
                user.Payeddate = dataReader[7].ToString();
                user.Cancelleddate = dataReader[8].ToString();
                examens.Add(user);
            }
            conn.Close();
            return examens;
        }
        public bool UpdateTestStatus(string testid)
        {
            conn.Open();
            String cancelleddate = DateTime.Now.ToString("yyy/MM/dd");

            cmdUpdateTestStatus = new SqlCommand("proc_Updatestatus", conn);
            cmdUpdateTestStatus.Parameters.AddWithValue("@testid", testid);
            cmdUpdateTestStatus.Parameters.AddWithValue("@cancelleddate", cancelleddate);

            cmdUpdateTestStatus.CommandType = CommandType.StoredProcedure;
            if (cmdUpdateTestStatus.ExecuteNonQuery() > 0)
            {
                result = true;

            }
            conn.Close();
            return result;
        }
        public bool UpdateExpired(string username,string today)
        {
            conn.Open();
            cmdExpireUpdate = new SqlCommand("proc_UpdateExpire", conn);
            cmdExpireUpdate.Parameters.AddWithValue("@username", username);
            cmdExpireUpdate.Parameters.AddWithValue("@expire", today);
            cmdExpireUpdate.CommandType = CommandType.StoredProcedure;
            if(cmdExpireUpdate.ExecuteNonQuery() > 0){
                result = true;
            }
            
            conn.Close();
            return result;
        }
        public bool UpdateFinalStatus(string username, string Testid, string Testmodel, int Scores)
        {
            
            conn.Open();
            cmdUpdateFinalStatus = new SqlCommand("proc_InsertIntoScoresAfterTest", conn);
            cmdUpdateFinalStatus.Parameters.AddWithValue("@username", username);
            cmdUpdateFinalStatus.Parameters.AddWithValue("@testid", Testid);
            cmdUpdateFinalStatus.Parameters.AddWithValue("@testmodel", Testmodel);
            cmdUpdateFinalStatus.Parameters.AddWithValue("@score", Scores);
            cmdUpdateFinalStatus.CommandType = CommandType.StoredProcedure;
            if (cmdUpdateFinalStatus.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool UpdateMainTableAfterTest(string Testid,int Scores)
        {
            conn.Open();
            cmdUpdateScoresInMainTable = new SqlCommand("proc_UpdateTestStatus", conn);
            cmdUpdateScoresInMainTable.Parameters.AddWithValue("@testid", Testid);
            cmdUpdateScoresInMainTable.Parameters.AddWithValue("@result", Scores);
            cmdUpdateScoresInMainTable.CommandType = CommandType.StoredProcedure;
            if(cmdUpdateScoresInMainTable.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();
            return result;

        }





        /*ADMIN MODULES */
        /*ADMIN MODULES */
        /*ADMIN MODULES */
        /*ADMIN MODULES */


        public bool AdminLogInValidation(UserLibrary user)
        {
            conn.Open();

            cmdAdminLogInUserValidation = new SqlCommand("proc_AdminUserValidation", conn);
            cmdAdminLogInUserValidation.Parameters.AddWithValue("@p_Username", user.Username);
            cmdAdminLogInUserValidation.Parameters.AddWithValue("@p_password", user.Password);
            cmdAdminLogInUserValidation.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = cmdAdminLogInUserValidation.ExecuteReader();
            if (dataReader.HasRows == true)
            { result = true; }
            conn.Close();
            return result;

        }
        public List<UserLibrary> GetAllQuestions(string testmodel)
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetQuestions = new SqlCommand("proc_GetAllQuestionsforAdmin", conn);
            cmdGetQuestions.Parameters.Add("@TestModel", SqlDbType.VarChar, 50);
            cmdGetQuestions.CommandType = CommandType.StoredProcedure;
            cmdGetQuestions.Parameters[0].Value = testmodel;


            UserLibrary examen;
            SqlDataReader dataReader = cmdGetQuestions.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new UserLibrary();
                examen.Sno = Convert.ToInt32(dataReader[0]);
                examen.Testmodel = dataReader[1].ToString();
                examen.Question = dataReader[2].ToString();
                examen.Answer = dataReader[3].ToString();
                examen.Option1 = (dataReader[4].ToString());
                examen.Option3 = (dataReader[5].ToString());
                examen.Option2 = (dataReader[6].ToString());
                examen.Option4 = (dataReader[7].ToString());
                examen.Mark = Convert.ToInt32(dataReader[8]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
        public List<UserLibrary> GetQuestions()
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetAllQuestions = new SqlCommand("proc_GetQuestions", conn);
            cmdGetAllQuestions.CommandType = CommandType.StoredProcedure;
            UserLibrary examen;
            SqlDataReader dataReader = cmdGetAllQuestions.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new UserLibrary();
                examen.Sno = Convert.ToInt32(dataReader[0]);
                examen.Testmodel = dataReader[1].ToString();
                examen.Question = dataReader[2].ToString();
                examen.Answer = dataReader[3].ToString();
                examen.Option1 = (dataReader[4].ToString());
                examen.Option3 = (dataReader[5].ToString());
                examen.Option2 = (dataReader[6].ToString());
                examen.Option4 = (dataReader[7].ToString());
                examen.Mark = Convert.ToInt32(dataReader[8]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }

        public UserLibrary AddQuestions(UserLibrary examen)
        {
            try
            {
                conn.Open();
                cmdAddQuestion = new SqlCommand("proc_AddQuestion", conn);
                cmdAddQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
                cmdAddQuestion.Parameters.AddWithValue("@Questions", examen.Question);
                cmdAddQuestion.Parameters.AddWithValue("@Answers", examen.Answer);
                cmdAddQuestion.Parameters.AddWithValue("@option1", examen.Option1);
                cmdAddQuestion.Parameters.AddWithValue("@option2", examen.Option2);
                cmdAddQuestion.Parameters.AddWithValue("@option3", examen.Option3);
                cmdAddQuestion.Parameters.AddWithValue("@option4", examen.Option4);
                cmdAddQuestion.Parameters.AddWithValue("@Mark", examen.Mark);
                cmdAddQuestion.CommandType = CommandType.StoredProcedure;
                if (cmdAddQuestion.ExecuteNonQuery() > 0)
                {
                    examen = null;
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);

            }
            conn.Close();
            return examen;
        }
        public List<UserLibrary> GetTestType(string testType)
        {
            List<UserLibrary> list = new List<UserLibrary>();
            conn.Open();
            cmdGetTestQuestion = new SqlCommand("proc_GetTestTypeQuestions", conn);
            cmdGetTestQuestion.Parameters.AddWithValue("@TestModel", testType);
            cmdGetTestQuestion.CommandType = CommandType.StoredProcedure;
            cmdGetTestQuestion.Parameters[0].Value = testType;
            SqlDataReader drQuestionType = cmdGetTestQuestion.ExecuteReader();
            UserLibrary examen = null;
            while (drQuestionType.Read())
            {
                examen = new UserLibrary();
                examen.Sno = Convert.ToInt32(drQuestionType[0]);
                examen.Testmodel = drQuestionType[1].ToString();
                examen.Question = drQuestionType[2].ToString();
                examen.Answer = drQuestionType[3].ToString();
                examen.Option1 = drQuestionType[4].ToString();
                examen.Option2 = drQuestionType[5].ToString();
                examen.Option3 = drQuestionType[6].ToString();
                examen.Option4 = drQuestionType[7].ToString();
                examen.Mark = Convert.ToInt32(drQuestionType[8]);

                list.Add(examen);
            }
            conn.Close();
            return list;
        }
        public UserLibrary UpdateQuestion(UserLibrary examen)
        {
            conn.Open();
            cmdUpdateQuestion = new SqlCommand("proc_UpdateQuestion", conn);
            cmdUpdateQuestion.CommandType = CommandType.StoredProcedure;
            cmdUpdateQuestion.Parameters.AddWithValue("@SNo", examen.Sno);
            cmdUpdateQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
            cmdUpdateQuestion.Parameters.AddWithValue("@Question", examen.Question);
            cmdUpdateQuestion.Parameters.AddWithValue("@Answer", examen.Answer);
            cmdUpdateQuestion.Parameters.AddWithValue("@option1", examen.Option1);
            cmdUpdateQuestion.Parameters.AddWithValue("@option2", examen.Option2);
            cmdUpdateQuestion.Parameters.AddWithValue("@option3", examen.Option3);
            cmdUpdateQuestion.Parameters.AddWithValue("@option4", examen.Option4);
            cmdUpdateQuestion.Parameters.AddWithValue("@Mark", examen.Mark);
            if (cmdUpdateQuestion.ExecuteNonQuery() > 0)
            {
                examen = null;
            }
            conn.Close();
            return examen;
        }

        public string DeleteQuestion(int Sno)
        {
            string result;
            conn.Open();
            cmdDeleteQuestion = new SqlCommand("proc_DeleteQuestion", conn);
            cmdDeleteQuestion.CommandType = CommandType.StoredProcedure;
            cmdDeleteQuestion.Parameters.AddWithValue("@SNo", Sno);
            //cmdDeleteQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
            if (cmdDeleteQuestion.ExecuteNonQuery() > 0)
            {

                result = "deleted";
            }
            else
            {
                result = "not deleted";
            }
            conn.Close();
            return result;
        }
        public List<UserLibrary> GetAdminDetails()
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetAdminDetails = new SqlCommand("proc_AdminDetails", conn);
            cmdGetAdminDetails.CommandType = CommandType.StoredProcedure;
            UserLibrary examen;
            SqlDataReader dataReader = cmdGetAdminDetails.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new UserLibrary();
                examen.Admin_name = dataReader[0].ToString();
                examen.Admin_email = dataReader[1].ToString();
                examen.Admin_phone = dataReader[2].ToString();
                examen.Admin_username = dataReader[3].ToString();
                examen.Admin_Image = dataReader[5].ToString();
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
        public List<UserLibrary> GetRegisterDetails()
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetRegisterDetails = new SqlCommand("proc_GetUserDetails", conn);
            cmdGetRegisterDetails.CommandType = CommandType.StoredProcedure;
            UserLibrary examen;
            SqlDataReader dataReader = cmdGetRegisterDetails.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new UserLibrary();
                examen.Phone = dataReader[0].ToString();
                examen.Email = dataReader[1].ToString();
                examen.Username = dataReader[2].ToString();
                examen.Name = dataReader[4].ToString();
                examens.Add(examen);
            }
            conn.Close();
            return examens;

        }
        public List<UserLibrary> GetPaidUsers()
        {
            conn.Open();
            List<UserLibrary> examens = new List<UserLibrary>();
            cmdGetPaidUsers = new SqlCommand("proc_GetPaidUsers", conn);
            cmdGetPaidUsers.CommandType = CommandType.StoredProcedure;
            UserLibrary examen;
            SqlDataReader dataReader = cmdGetPaidUsers.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new UserLibrary();
                examen.Username = dataReader[0].ToString();
                examen.Testid = dataReader[1].ToString();
                examen.Testmodel = dataReader[2].ToString();
                //examen.Testdate = (Convert.ToDateTime(dataReader[3]));
                examen.Testdate = dataReader[3].ToString();
                examen.Paymentmode = dataReader[4].ToString();
                examen.Teststatus = dataReader[5].ToString();
                examen.Result = Convert.ToInt32(dataReader[6]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
    }
}
