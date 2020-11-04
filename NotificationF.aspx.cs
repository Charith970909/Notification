using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Harvest_Ordering_System
{
    public partial class Notification : System.Web.UI.Page
    {
        private int txtId = 0;
        private int newQty = 0;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-26VBTK1;Initial Catalog=HarvestOrderSystemDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Session["email"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "accept")
            {
                string upd = "UPDATE Cropadd SET Quntity = '" + newQty + "' WHERE Id = '" + txtId + "';";
                SqlCommand com2 = new SqlCommand(upd, con);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();

                string del = "DELETE Cropadd SET Quntity = '" + newQty + "' WHERE Id = '" + txtId + "';";
                SqlCommand com3 = new SqlCommand(del, con);
                con.Open();
                com3.ExecuteNonQuery();
                con.Close();
            }

           if (e.CommandName == "cancel")
            {
                string del = "DELETE Cropadd SET Quntity = '" + newQty + "' WHERE Id = '" + txtId + "';";
                SqlCommand com3 = new SqlCommand(del, con);
                con.Open();
                com3.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}