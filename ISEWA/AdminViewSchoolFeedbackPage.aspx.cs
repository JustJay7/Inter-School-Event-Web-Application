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
    public partial class AdminViewSchoolFeedbackPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            // connection string  
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string qry = "SELECT * FROM SchoolFeedback";
            SqlCommand com = new SqlCommand(qry, con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);  // fill dataset  
            gvViewFeedback.DataSource = ds;      //assigning datasource to the dropdownlist  
            gvViewFeedback.DataBind();  //binding dropdownlist
            if (!this.IsPostBack)
            {
                string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(mycon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT SchoolEmail FROM SchoolFeedback"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        conn.Open();
                        ddlSchoolEmail.DataSource = cmd.ExecuteReader();
                        ddlSchoolEmail.DataTextField = "SchoolEmail";
                        ddlSchoolEmail.DataBind();
                        conn.Close();
                    }
                }
                ddlSchoolEmail.Items.Insert(0, new ListItem("All Schools", "All Schools"));

                using(SqlConnection conn = new SqlConnection(mycon))
                {
                    using (SqlCommand cmmd = new SqlCommand("SELECT FestName FROM FestNames"))
                    {
                        cmmd.CommandType = CommandType.Text;
                        cmmd.Connection = conn;
                        conn.Open();
                        ddlFestName.DataSource = cmmd.ExecuteReader();
                        ddlFestName.DataTextField = "FestName";
                        ddlFestName.DataBind();
                        conn.Close();
                    }
                }
                ddlFestName.Items.Insert(0, new ListItem("All Fests", "All Fests"));
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
        private void Search()
        {
            SchoolFeedbackClass objSchoolSearch = new SchoolFeedbackClass(ddlFestName.SelectedValue, ddlSchoolEmail.SelectedValue);
            DataSet ds = objSchoolSearch.FetchFeedbackDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMessage.Visible = false;
                gvViewFeedback.Visible = true;
                gvViewFeedback.DataSource = ds;
                gvViewFeedback.DataBind();
            }
            else
            {
                gvViewFeedback.Visible = false;
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No Data was available for the selected search criteria.";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }
    }
}