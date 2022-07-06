using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace ISEWA
{
    public partial class EventCoordinatorsRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegisterEventCoordinator_Click(object sender, EventArgs e)
        {
            EventCoordinatorClass objRegister = new EventCoordinatorClass();
            objRegister.EventCoordinatorName = txtEventCoordinatorName.Text;
            objRegister.EventCoordinatorPhoneNumber = txtEventCoordinatorPhoneNumber.Text;
            objRegister.UserEmail = txtEventCoordinatorEmail.Text;
            objRegister.UserPassword = txtEventCoordinatorCreatePassword.Text;

            bool Result = objRegister.CheckEmail();
            int Result2 = objRegister.AddEventCoordinatorDetails();
            if (Result == false)
            {
                if (Result2 > 0)
                {
                    lblErrorMessage.Visible = false;
                    Response.Redirect("EventCoordinatorLoginPage.aspx");
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

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}