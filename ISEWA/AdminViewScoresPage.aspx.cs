using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration; // for Using Connection From Web.config  
using DataAccess;

namespace ISEWA
{
    public partial class AdminViewScoresPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constrr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            // connection string  
            SqlConnection conn = new SqlConnection(constrr);
            conn.Open();

            if (!this.IsPostBack)
            {
                string mycoon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection coonn = new SqlConnection(mycoon))
                {
                    using (SqlCommand cmmd = new SqlCommand("SELECT FestName FROM FestNames"))
                    {
                        cmmd.CommandType = CommandType.Text;
                        cmmd.Connection = coonn;
                        coonn.Open();
                        ddlFestName.DataSource = cmmd.ExecuteReader();
                        ddlFestName.DataTextField = "FestName";
                        ddlFestName.DataBind();
                        coonn.Close();
                    }
                }
                //ddlFestName.Items.Insert(0, new ListItem("All Fests", "All Fests"));
            }
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
        }

        private void RankSchools(DataTable dt)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string qry = "SELECT COUNT (EventName) FROM EventDetails WHERE FestName = '" + ddlFestName.SelectedValue + "'";
            SqlCommand com = new SqlCommand(qry, con);
            Int32 TotalEvents = Convert.ToInt32(com.ExecuteScalar());

            int var = dt.Rows.Count;
            int MaximumScore = 10 * TotalEvents;
            double AddTotal;
            double SchoolScore;
            double SchoolEvent;
            List<string> TopSchools = new List<string>();
            List<double> TopWinners = new List<double>();
            double[] ARRTopWinners = new double[var];
            string[] ARRTopSchools = new string[var];
            double temp = 0;
            string temp2 = "";

            foreach (DataRow row in dt.Rows)
            {
                SchoolScore = (double.Parse(row["OverallScore"].ToString())) / MaximumScore * 0.6;
                SchoolEvent = (double.Parse(row["NumberOfEvents"].ToString())) / TotalEvents * 0.4;
                AddTotal = SchoolScore + SchoolEvent;
                TopWinners.Add(AddTotal);
                TopSchools.Add(row["SchoolEmail"].ToString());
                ARRTopWinners = TopWinners.ToArray();
                ARRTopSchools = TopSchools.ToArray();
            }
            for (int i = 0; i <= ARRTopWinners.Length - 1; i++)
            {
                for (int j = i + 1; j < ARRTopWinners.Length; j++)
                {
                    if (ARRTopWinners[i] < ARRTopWinners[j])
                    {
                        temp = ARRTopWinners[i];
                        ARRTopWinners[i] = ARRTopWinners[j];
                        ARRTopWinners[j] = temp;

                        temp2 = ARRTopSchools[i];
                        ARRTopSchools[i] = ARRTopSchools[j];
                        ARRTopSchools[j] = temp2;
                    }
                }
            }
            LblSchoolName1.Visible = true;
            LblSchoolName2.Visible = true;
            LblSchoolName3.Visible = true;
            btnCalculateWinners.Visible = false;

            LblSchoolName1.Text = ARRTopSchools[0].ToString();
            LblSchoolName2.Text = ARRTopSchools[1].ToString();
            LblSchoolName3.Text = ARRTopSchools[2].ToString();
        }

        private void Search()
        {
            AdminClass objFetchFest = new AdminClass();
            DataSet ds = objFetchFest.FetchOverallScores(ddlFestName.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvOverallScore.DataSource = ds;
                gvOverallScore.DataBind();
                gvOverallScore.Visible = true;
                
                btnEventScores.Visible = true;
                lblTop3Winners.Visible = true;
                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                LblSchoolName1.Visible = false;
                LblSchoolName2.Visible = false;
                LblSchoolName3.Visible = false;
                btnCalculateWinners.Visible = true;

                lblErrorMessage.Visible = false;
            }
            else
            {
                gvOverallScore.Visible = false;
                lblTop3Winners.Visible = false;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                LblSchoolName1.Visible = false;
                LblSchoolName2.Visible = false;
                LblSchoolName3.Visible = false;
                btnCalculateWinners.Visible = false;

                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No Data was available for the selected Fest.";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        protected void btnEventScores_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewEventScoresPage.aspx");
        }

        protected void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnCalculateWinners_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            // connection string  
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string qry = "SELECT SchoolEmail, SUM(Score) As OverallScore, COUNT (DISTINCT SchoolEventScores.EventName) As NumberOfEvents FROM SchoolEventScores " +
                "WHERE FestName = '" + ddlFestName.SelectedValue + "' GROUP BY SchoolEmail ORDER BY OverallScore DESC";
            SqlCommand com = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);  //fill dataset  
            gvOverallScore.DataSource = ds;   //assigning datasource to the gridview  
            gvOverallScore.DataBind();

            RankSchools(ds);
        }
    }
}