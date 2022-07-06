using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace ISEWA
{
    public partial class RegisterYourSchool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {                   
            SchoolClass objSchoolRegister = new SchoolClass();
            objSchoolRegister.SchoolName = txtSchoolName.Text;
            objSchoolRegister.SchoolAddress = txtSchoolAddress.Text;
            objSchoolRegister.SchoolPhoneNumber = txtSchoolPhoneNumber.Text;
            objSchoolRegister.SchoolContactPerson = txtSchoolContactPersonName.Text;
            objSchoolRegister.UserEmail = txtSchoolContactEmail.Text;
            objSchoolRegister.UserPassword = txtCreatePassword.Text;

            bool Result = objSchoolRegister.CheckEmail();
            if (Result == false)
            {
                int Result2 = objSchoolRegister.AddSchoolDetails();
                if (Result2 > 0)
                {
                    lblErrorMessage.Visible = false;
                    Response.Redirect("SchoolLoginPage.aspx");
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Registration Unsuccessful. Please try again!";
                }
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Email ID already exists.";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}