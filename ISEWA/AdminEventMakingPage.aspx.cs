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
    public partial class AdminEventMakingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAdminEmail.Text = Session["AdminEmail"].ToString();
                string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("SELECT EventCoordinatorEmail FROM EventCoordinatorCredentials", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                ddlEventCoordinatorEmail.DataTextField = ds.Tables[0].Columns["EventCoordinatorEmail"].ToString(); // text field name of table dispalyed in dropdown       
                                                                                                                   // to retrive specific  textfield name   
                ddlEventCoordinatorEmail.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                ddlEventCoordinatorEmail.DataBind();  //binding dropdownlist

                com = new SqlCommand("SELECT FestName FROM FestNames", con);
                // table name   
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                ddlFestName.DataTextField = ds.Tables[0].Columns["FestName"].ToString(); // text field name of table dispalyed in dropdown       
                                                                                         // to retrive specific  textfield name   
                ddlFestName.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                ddlFestName.DataBind();  //binding dropdownlist
            }
        }
    


        protected void BtnAddEvent_Click(object sender, EventArgs e)
        {
            EventClass objAddEvent = new EventClass(ddlFestName.SelectedValue, txtEventName.Text, txtEventDescription.Text, 
            ddlEventCoordinatorEmail.SelectedValue, ddlNumberOfParticipants.SelectedValue, txtDateOfTheEvent.Text, ddlTimeOfTheEvent.SelectedValue);
            bool Result = objAddEvent.CheckEventExists();
            if (Result == false)
            {
                int Result2 = objAddEvent.AddEventDetails();
                if (Result2 > 0)
                {
                    string[] chkboxgrade = selectedIndexesOfCheckBoxList(cblEligibleGrades);
                    int Result3 = objAddEvent.AddEligibleGrades(txtEventName.Text, chkboxgrade);

                    if (Result3 > 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Gold;
                        lblMessage.Text = "You have successfully added an event!";
                    }

                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "The event was not added successfully. Please try again!";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "The event was not added successfully. Please try again!";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "The Event Name already exists!";
            }
        }
        public string[] selectedIndexesOfCheckBoxList(CheckBoxList cblEligibleGrades)
        {
            List<string> selectedIndexes = new List<string>();

            foreach (ListItem item in cblEligibleGrades.Items)
            {
                if (item.Selected)
                {
                    selectedIndexes.Add(item.Value);
                }
            }

            return selectedIndexes.ToArray();
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            RangeValidator.ControlToValidate = "txtDateOfTheEvent";
            RangeValidator.Type = ValidationDataType.Date;
            RangeValidator.MinimumValue = DateTime.Now.AddMonths(1).ToShortDateString();
            RangeValidator.MaximumValue = DateTime.Now.AddMonths(4).ToShortDateString();
            RangeValidator.Visible = false;
            lblErrorMessage.Visible = false;

            if (DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()) > DateTime.Parse(RangeValidator.MinimumValue))
            {
                if (DateTime.Parse(Calendar1.SelectedDate.ToShortDateString()) < DateTime.Parse(RangeValidator.MaximumValue))
                {
                    RangeValidator.Visible = false;
                    lblErrorMessage.Visible = false;
                    txtDateOfTheEvent.Text = Calendar1.SelectedDate.ToShortDateString();
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "The Event has to be registered 1 to 3 months in advance.";
                }
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "The Event has to be registered 1 to 3 months in advance.";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
    }
}