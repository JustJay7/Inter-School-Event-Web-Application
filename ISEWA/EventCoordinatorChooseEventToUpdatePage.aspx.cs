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
    public partial class EventCoordinatorChooseEventToUpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEventCoordinatorEmail.Text = Session["EventCoordinatorEmail"].ToString();
                string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("SELECT DISTINCT FestName FROM EventDetails WHERE EventCoordinator like '" + Session["EventCoordinatorEmail"].ToString() + "%'", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                ddlFestName.DataTextField = ds.Tables[0].Columns["FestName"].ToString(); // text field name of table dispalyed in dropdown       
                                                                                         // to retrive specific  textfield name   
                ddlFestName.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                ddlFestName.DataBind();  //binding dropdownlist
            }
            ddlFestName.Items.Insert(0, new ListItem("Select", "Select"));
        }
        protected void btnNextScreen_Click(object sender, EventArgs e)
        {
            Session["ChosenEvent"] = ddlEventName.SelectedValue;
            Session["ChosenFest"] = ddlFestName.SelectedValue;
            Response.Redirect("EventCoordinatorUpdateScoresPage.aspx");
        }

        protected void btnLogoutEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorLoginPage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorHomePage.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ddlFestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection connn = new SqlConnection(myconn))
            {
                SqlCommand cmd = new SqlCommand("SELECT EventName FROM EventDetails WHERE EventCoordinator = '" + Session["EventCoordinatorEmail"].ToString() + "' AND FestName = '" + ddlFestName.SelectedValue + "'");
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connn;
                    connn.Open();
                    ddlEventName.DataSource = cmd.ExecuteReader();
                    ddlEventName.DataTextField = "EventName";
                    //ddlEventName.DataValueField = "CustomerId";
                    ddlEventName.DataBind();
                    connn.Close();
                }
            }
        }
    }
}