using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace ISEWA
{
    public partial class EventCoordinatorsLogin : System.Web.UI.Page
    {
        protected void BtnLoginEventCoordinator_Click(object sender, EventArgs e)
        {
            UserClass objUserDA = new EventCoordinatorClass();
            objUserDA.UserEmail = txtEventCoordinatorEmail.Text;
            objUserDA.UserPassword = txtEventCoordinatorPassword.Text;

            int Result = objUserDA.LoginCheck();
            if (Result == 1)
            {
                lblErrorMessage.Visible = false;
                Session["EventCoordinatorEmail"] = txtEventCoordinatorEmail.Text;
                Response.Redirect("EventCoordinatorHomePage.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Login Credentials Invalid. Please try again!";
            }
        }

        protected void LinkbtnChangePasswordEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorChangePasswordPage.aspx");
        }

        protected void LinkbtnForgotPasswordEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorForgotPasswordPage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}