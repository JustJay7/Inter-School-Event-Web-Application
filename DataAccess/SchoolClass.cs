using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Required for using Dataset, Datatable and SQL  
using System.Data.SqlClient; //Required for Using SQL   
using System.Configuration; //For Using Connection String From web.config  

namespace DataAccess
{
    public class SchoolClass : UserClass
    {
        //Declaring School Registration Variables
        private string _SchoolName;
        private string _SchoolAddress;
        private string _SchoolContactPerson;
        private string _SchoolPhoneNumber;
        private string _EventName;

        // Get and set values
        public string SchoolName
        {
            get
            {
                return _SchoolName;
            }
            set
            {
                _SchoolName = value;
            }
        }
        public string SchoolAddress
        {
            get
            {
                return _SchoolAddress;
            }
            set
            {
                _SchoolAddress = value;
            }
        }
        public string SchoolContactPerson
        {
            get
            {
                return _SchoolContactPerson;
            }
            set
            {
                _SchoolContactPerson = value;
            }
        }
        public string SchoolPhoneNumber
        {
            get
            {
                return _SchoolPhoneNumber;
            }
            set
            {
                _SchoolPhoneNumber = value;
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
        public SchoolClass()
        {

        }
        public SchoolClass(string eventname, string schoolemail)
        {
            this.EventName = eventname;
            this.UserEmail = schoolemail;
        }
        public SchoolClass(string RegisteredEmailID, string CurrentPassword, string NewPassword)
        {
            this.UserEmail = RegisteredEmailID;
            this.CurrentPassword = CurrentPassword;
            this.NewPassword = NewPassword;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public int AddSchoolDetails()  
        {
            try
            {
                string qry = "insert into SchoolCredentials values(@SchoolName, @SchoolEmail, @SchoolPassword, @SchoolAddress, @SchoolContactPerson, @SchoolPhoneNumber)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@SchoolName", this.SchoolName);
                cmd.Parameters.AddWithValue("@SchoolEmail", this.UserEmail);
                cmd.Parameters.AddWithValue("@SchoolPassword", this.UserPassword);
                cmd.Parameters.AddWithValue("@SchoolAddress", this.SchoolAddress);
                cmd.Parameters.AddWithValue("@SchoolContactPerson", this.SchoolContactPerson);
                cmd.Parameters.AddWithValue("@SchoolPhoneNumber", this.SchoolPhoneNumber);

                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return Result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public override bool CheckEmail()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SchoolEmail FROM SchoolCredentials WHERE SchoolEmail='" + this.UserEmail + "'", con);
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
        public bool RegisteredEvent()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT EventName, SchoolEmail FROM ParticipantDetails WHERE SchoolEmail = '" + this.UserEmail + "' AND EventName = '" + this.EventName + "'", con);
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
        //Use AdminClass UserEmail and UserPassword and make chanegs in the aspx.cs file accordingly
        public override int LoginCheck()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SchoolCredentials WHERE SchoolEmail='" + this.UserEmail + "' and SchoolPassword='" + this.UserPassword + "'", con);
            cmd.Parameters.AddWithValue("@SchoolEmail", this.UserEmail);
            cmd.Parameters.AddWithValue("@SchoolPassword", this.UserPassword);
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
        public override int ChangePassword()
        {
            SqlCommand cmd = new SqlCommand("SchoolChangePassword", con);
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
        public DataSet ViewScores(string SelectedFestName, string SelectedSchoolEmail)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;

            if (SelectedFestName != "All Fests")
            {
                sql = "SELECT FestName, EventName, Score FROM [dbo].[SchoolEventScores] WHERE (([FestName] = '" + SelectedFestName + "') AND ([SchoolEmail] = '" + SelectedSchoolEmail + "'))";
            }
            else
            {
                sql = "SELECT FestName, EventName, Score FROM SchoolEventScores WHERE ([SchoolEmail] = '" + SelectedSchoolEmail + "')";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "SchoolEventScores");
            con.Close();
            return ds;
        }
        public DataSet FetchEventDetails(string SelectedFestName)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;

            if (SelectedFestName != "All Fests")
            {
                sql = "SELECT * FROM [dbo].[EventDetails] WHERE ([FestName] = '" + SelectedFestName + "')";
            }
            else
            {
                sql = "SELECT * FROM EventDetails";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "FetchEventDetails");
            con.Close();
            return ds;
        }
    }
}
