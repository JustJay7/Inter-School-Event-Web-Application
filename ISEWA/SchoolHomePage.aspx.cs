using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISEWA
{
    public partial class SchoolHomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void btnLogoutSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }

        protected void btnRegisterEvent_Click(object sender, EventArgs e)
        {
            lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            Response.Redirect("SchoolEventDetailsPage.aspx");
        }

        protected void btnViewScore_Click(object sender, EventArgs e)
        {
            lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            Response.Redirect("SchoolViewScoresPage.aspx");
        }

        protected void btnGiveFeedback_Click(object sender, EventArgs e)
        {
            lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            Response.Redirect("SchoolFeedbackPage.aspx");
        }
    }
}