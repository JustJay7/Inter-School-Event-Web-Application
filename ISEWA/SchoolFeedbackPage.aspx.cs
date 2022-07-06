using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration; // For Using Connection From Web.config  
using DataAccess;

namespace ISEWA
{
    public partial class School_Feedback_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
                string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(mycon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT FestName FROM FestNames"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        conn.Open();
                        ddlFestName.DataSource = cmd.ExecuteReader();
                        ddlFestName.DataTextField = "FestName";
                        ddlFestName.DataBind();
                        conn.Close();
                    }
                }
            }
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolHomePage.aspx");
        }

        protected void btnLogoutSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }

        protected void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            SchoolFeedbackClass objFeedback = new SchoolFeedbackClass(ddlFestName.SelectedValue, lblSchoolEmail.Text, int.Parse(rblRateFest.SelectedItem.Text), int.Parse(rblOrganizedFest.SelectedItem.Text), rblFutureFests.SelectedItem.Text, txtSchoolLikes.Text, txtSchoolDislikes.Text, txtSchoolThoughts.Text);
            int Result = objFeedback.SubmitFeedback();
            if (Result > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "You have successfully submitted your feedback!";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Feedback failed to submit. Please try again!";
            }
        }
    }
}