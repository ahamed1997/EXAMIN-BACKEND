using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace ExamenUserLibrary
{
    public class UserLibrary
    {
        string name, email, phone, username, password, confirmpassword;
        string question,option1,option2,option3,option4,answer,testmodel,useranswer;
        int sno, mark,qno,flag,result;
        string admin_name, admin_email, admin_phone, admin_username,admin_Image,testid,paymentmode,teststatus;
        //DateTime testdate;
        string testdate,payeddate,cancelleddate;


        
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Confirmpassword { get => confirmpassword; set => confirmpassword = value; }
        public string Question { get => question; set => question = value; }
        public string Option1 { get => option1; set => option1 = value; }
        public string Option2 { get => option2; set => option2 = value; }
        public string Option3 { get => option3; set => option3 = value; }
        public string Option4 { get => option4; set => option4 = value; }
        public string Answer { get => answer; set => answer = value; }
        public string Testmodel { get => testmodel; set => testmodel = value; }
        public int Sno { get => sno; set => sno = value; }
        public int Mark { get => mark; set => mark = value; }
        public int Qno { get => qno; set => qno = value; }
        public string Useranswer { get => useranswer; set => useranswer = value; }
        public int Flag { get => flag; set => flag = value; }
        public string Admin_name { get => admin_name; set => admin_name = value; }
        public string Admin_email { get => admin_email; set => admin_email = value; }
        public string Admin_phone { get => admin_phone; set => admin_phone = value; }
        public string Admin_username { get => admin_username; set => admin_username = value; }
        public string Admin_Image { get => admin_Image; set => admin_Image = value; }
        public string Testid { get => testid; set => testid = value; }
        public string Paymentmode { get => paymentmode; set => paymentmode = value; }
        public string Teststatus { get => teststatus; set => teststatus = value; }
        public int Result { get => result; set => result = value; }
        public string Testdate { get => testdate; set => testdate = value; }
        public string Payeddate { get => payeddate; set => payeddate = value; }
        public string Cancelleddate { get => cancelleddate; set => cancelleddate = value; }
        //public DateTime Testdate { get => testdate; set => testdate = value; }
    }
}
