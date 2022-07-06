using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccess;

namespace ISEWA
{
    public partial class AdminUpdateDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
            if (!IsPostBack)
            {
                this.BindGrid();
                tblUpdate.Visible = false;
                string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("SELECT DISTINCT FestName FROM FestNames", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                ddlFestName.DataTextField = ds.Tables[0].Columns["FestName"].ToString(); // text field name of table dispalyed in dropdown       
                                                                                         // to retrive specific  textfield name   
                ddlFestName.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                ddlFestName.DataBind();  //binding dropdownlist 

                com = new SqlCommand("SELECT EventCoordinatorEmail FROM EventCoordinatorCredentials", con);
                // table name   
                da = new SqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                ddlEventCoordinatorEmail.DataTextField = ds.Tables[0].Columns["EventCoordinatorEmail"].ToString(); // text field name of table dispalyed in dropdown       
                                                                                                              // to retrive specific  textfield name   
                ddlEventCoordinatorEmail.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                ddlEventCoordinatorEmail.DataBind();  //binding dropdownlist
            }

        }
        private void BindGrid()
        {
            string sql = "SELECT * FROM EventDetails";
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvEventDetailsUpdate.DataSource = dt;
                        gvEventDetailsUpdate.DataBind();
                    }
                }
            }
        }
        protected void gvEventDetailsUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblUpdate.Visible = true;
            GridViewRow row = gvEventDetailsUpdate.SelectedRow;
            lblId.Text = row.Cells[1].Text;
            ddlFestName.SelectedValue = row.Cells[2].Text;
            txtEventName.Text = row.Cells[3].Text;
            txtEventDescription.Text = row.Cells[4].Text;
            ddlEventCoordinatorEmail.SelectedValue = row.Cells[5].Text;
            ddlNumberOfParticipants.SelectedValue = row.Cells[6].Text;
            txtDateOfTheEvent.Text = row.Cells[7].Text;
            ddlTimeOfTheEvent.SelectedValue = row.Cells[8].Text;
        }
        protected void EditScore(object sender, GridViewEditEventArgs e)
        {
            gvEventDetailsUpdate.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            tblUpdate.Visible = false;
            gvEventDetailsUpdate.EditIndex = -1;
            this.BindGrid();
        }
        protected void TextboxEventName_TextChanged(object sender, EventArgs e)
        {
            EventClass objUpdateEvent = new EventClass(int.Parse(lblId.Text), ddlFestName.SelectedValue, txtEventName.Text, txtEventDescription.Text,
            ddlEventCoordinatorEmail.SelectedValue, ddlNumberOfParticipants.SelectedValue, txtDateOfTheEvent.Text, ddlTimeOfTheEvent.SelectedValue);
            bool Result = objUpdateEvent.CheckEventExists();
            if (Result == false)
            {
                btnUpdate.Visible = true;
                lblMessage.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "The Event already exists!";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EventClass objUpdateEvent = new EventClass(int.Parse(lblId.Text), ddlFestName.SelectedValue, txtEventName.Text, txtEventDescription.Text,
            ddlEventCoordinatorEmail.SelectedValue, ddlNumberOfParticipants.SelectedValue, txtDateOfTheEvent.Text, ddlTimeOfTheEvent.SelectedValue);

            int Result2 = objUpdateEvent.UpdateEventDetails();
            if (Result2 > 0)
            {
                tblUpdate.Visible = false;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Gold;
                lblMessage.Text = "You have sucessfully updated the Event Details!";
            }
            else
            {
                tblUpdate.Visible = false;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Event Details could not be updated.";
            }
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Get the value of column from the DataKeys using the RowIndex.
            int Id = Convert.ToInt32(gvEventDetailsUpdate.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EventDetails WHERE Id = @Id"))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
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
    }
}