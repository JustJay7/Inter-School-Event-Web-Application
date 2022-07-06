using System;
using System.Data; //Required for using Dataset, Datatable and Sql  
using System.Data.SqlClient; //Required for Using Sql   
using System.Configuration; //For Using Connection From web.config  

namespace DataAccess
{
    public class SchoolFeedbackClass
    {
        //Declaring Feedback Variables  
        private string _SchoolEmail;
        private string _FestName;
        private int _RateFest;
        private int _RateOrganizedFest;
        private string _RateFutureFest;
        private string _SchoolLikes;
        private string _SchoolDislikes;
        private string _GeneralFeedback;

        // Get and set values  
        public string SchoolEmail
        {
            get
            {
                return _SchoolEmail;
            }
            set
            {
                _SchoolEmail = value;
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
        public int RateFest
        {
            get
            {
                return _RateFest;
            }
            set
            {
                _RateFest = value;
            }
        }
        public int RateOrganizedFest
        {
            get
            {
                return _RateOrganizedFest;
            }
            set
            {
                _RateOrganizedFest = value;
            }
        }
        public string RateFutureFest
        {
            get
            {
                return _RateFutureFest;
            }
            set
            {
                _RateFutureFest = value;
            }
        }
        public string SchoolLikes
        {
            get
            {
                return _SchoolLikes;
            }
            set
            {
                _SchoolLikes = value;
            }
        }
        public string SchoolDislikes
        {
            get
            {
                return _SchoolDislikes;
            }
            set
            {
                _SchoolDislikes = value;
            }
        }
        public string GeneralFeedback
        {
            get
            {
                return _GeneralFeedback;
            }
            set
            {
                _GeneralFeedback = value;
            }
        }
        public SchoolFeedbackClass()
        {

        }
        public SchoolFeedbackClass(string _FestName, string _SchoolEmail)
        {
            this.FestName = _FestName;
            this.SchoolEmail = _SchoolEmail;
        }
        public SchoolFeedbackClass(string FestName, string SchoolEmail, int RateFest, int RateOrganizedFest, 
            string RateFutureFest, string SchoolLikes, string SchoolDislikes, string GeneralFeedback)
        {
            this.FestName = FestName;
            this.SchoolEmail = SchoolEmail;
            this.RateFest = RateFest;
            this.RateOrganizedFest = RateOrganizedFest;
            this.RateFutureFest = RateFutureFest;
            this.SchoolLikes = SchoolLikes;
            this.SchoolDislikes = SchoolDislikes;
            this.GeneralFeedback = GeneralFeedback;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        public int SubmitFeedback()  
        {
            try
            {
                string qry = "insert into SchoolFeedback values(@FestName, @SchoolEmail, @FestRate, @OrganizationOfFestRate, @ReturnRate, @LikesAboutFestOrEvent, @DislikesAboutFestOrEvent, @GeneralThoughts)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@FestName", this.FestName);
                cmd.Parameters.AddWithValue("@SchoolEmail", this.SchoolEmail);
                cmd.Parameters.AddWithValue("@FestRate", this.RateFest);
                cmd.Parameters.AddWithValue("@OrganizationOfFestRate", this.RateOrganizedFest);
                cmd.Parameters.AddWithValue("@ReturnRate", this.RateFutureFest);
                cmd.Parameters.AddWithValue("@LikesAboutFestOrEvent", this.SchoolLikes);
                cmd.Parameters.AddWithValue("@DislikesAboutFestOrEvent", this.SchoolDislikes);
                cmd.Parameters.AddWithValue("@GeneralThoughts", this.GeneralFeedback);

                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return Result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public DataSet FetchFeedbackDetails()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;

            if (this.FestName != "All Fests" && this.SchoolEmail != "All Schools")
            {
                sql = "SELECT * FROM [dbo].[SchoolFeedback] WHERE (([FestName] = '" + this.FestName + "') AND ([SchoolEmail] = '" + this.SchoolEmail + "'))";
            }
            else if (this.FestName != "All Fests" && this.SchoolEmail == "All Schools")
            {
                sql = "SELECT * FROM [dbo].[SchoolFeedback] WHERE ([FestName] = '" + this.FestName + "')";
            }
            else if (this.FestName == "All Fests" && this.SchoolEmail != "All Schools")
            {
                sql = "SELECT * FROM [dbo].[SchoolFeedback] WHERE ([SchoolEmail] = '" + this.SchoolEmail + "')";
            }
            else
            {
                sql = "SELECT * FROM [dbo].[SchoolFeedback]";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "FeedbackDetails");
            con.Close();
            return ds;
        }
    }
}
