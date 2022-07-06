using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace ISEWA
{
    public partial class SchoolLogin : System.Web.UI.Page
    {
        protected void BtnLoginSchool_Click(object sender, EventArgs e)
        {
            UserClass objSchoolLogin = new SchoolClass();
            objSchoolLogin.UserEmail = txtSchoolEmail.Text;
            objSchoolLogin.UserPassword = txtSchoolPassword.Text;
            int Result = objSchoolLogin.LoginCheck();
            if (Result == 1)
            {
                lblErrorMessage.Visible = false;
                Session["SchoolEmail"] = txtSchoolEmail.Text;
                Response.Redirect("SchoolHomePage.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Login Credentials Invalid. Please try again!";
            }
        }
        protected void LinkbtnChangePasswordSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolChangePasswordPage.aspx");
        }

        protected void LinkbtnForgotPasswordSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolForgotPasswordPage.aspx");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}