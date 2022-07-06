using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISEWA
{
    public partial class EventCoordinatorHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEventCoordinatorEmail.Text = Session["EventCoordinatorEmail"].ToString();
        }
        protected void btnInputScores_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorChooseAnEventPage.aspx");
        }

        protected void btnUpdateScores_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorChooseEventToUpdatePage.aspx");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnLogoutEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorLoginPage.aspx");
        }
    }
}