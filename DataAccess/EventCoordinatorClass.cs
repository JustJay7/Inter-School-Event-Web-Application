using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration; // for Using Connection From Web.config  

namespace DataAccess
{
    public class EventCoordinatorClass : UserClass
    {
        //Declaring Event Coordinators Registration Variables  
        private string _EventCoordinatorName;
        private string _FestName;
        private string _EventName;
        private string _EventCoordinatorPhoneNumber;

        // Get and set values  
        public string EventCoordinatorName
        {
            get
            {
                return _EventCoordinatorName;
            }
            set
            {
                _EventCoordinatorName = value;
            }
        }
        public string FestName
        {
            get
            {
                return _FestName;
            }
            set
            {
                _FestName = value;
            }
        }
        public string EventName
        {
            get
            {
                return _EventName;
            }
            set
            {
                _EventName = value;
            }
        }
        public string EventCoordinatorPhoneNumber
        {
            get
            {
                return _EventCoordinatorPhoneNumber;
            }
            set
            {
                _EventCoordinatorPhoneNumber = value;
            }
        }
        public EventCoordinatorClass()
        {

        }
        public EventCoordinatorClass(string festname, string eventname)
        {
            this.FestName = festname;
            this.EventName = eventname;
        }
        public EventCoordinatorClass(string RegisteredEmailID, string CurrentPassword, string NewPassword)
        {
            this.UserEmail = RegisteredEmailID;
            this.CurrentPassword = CurrentPassword;
            this.NewPassword = NewPassword;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public int AddEventCoordinatorDetails()  
        {
            try
            {
                string qry = "insert into EventCoordinatorCredentials values(@EventCoordinatorName, @EventCoordinatorEmail, @EventCoordinatorPhoneNumber, @EventCoordinatorPassword)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@EventCoordinatorName", this.EventCoordinatorName);
                cmd.Parameters.AddWithValue("@EventCoordinatorEmail", this.UserEmail);
                cmd.Parameters.AddWithValue("@EventCoordinatorPhoneNumber", this.EventCoordinatorPhoneNumber);
                cmd.Parameters.AddWithValue("@EventCoordinatorPassword", this.UserPassword);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return Result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public override int LoginCheck()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM EventCoordinatorCredentials WHERE EventCoordinatorEmail='" + this.UserEmail + "' and EventCoordinatorPassword='" + this.UserPassword + "'", con);
            cmd.Parameters.AddWithValue("@EventCoordinatorEmail", this.UserEmail);
            cmd.Parameters.AddWithValue("@EventCoordinatorPassword", this.UserPassword);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public override bool CheckEmail()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT EventCoordinatorEmail FROM EventCoordinatorCredentials WHERE EventCoordinatorEmail='" + this.UserEmail + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ScoresGiven()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT FestName, EventName FROM SchoolEventScores WHERE FestName = '" + this.FestName +"' AND EventName = '" + this.EventName + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int ChangePassword()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EventCoordinatorChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegisteredEmailID", this.UserEmail);
            cmd.Parameters.AddWithValue("@CurrentPassword", this.CurrentPassword);
            cmd.Parameters.AddWithValue("@NewPassword", this.NewPassword);

            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            //read the return value (i.e status) from the stored procedure
            int retVal = Convert.ToInt32(cmd.Parameters["@Status"].Value);
            if (retVal == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}