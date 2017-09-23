using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class HacerPagoPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr;
        String name;
        String numPrestamo;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
            numPrestamo = Request.QueryString["field1"];
            numPrestamoTB.Text = numPrestamo;
        }

        protected void submitEventMethodHacerPago(object sender, EventArgs e)
        {
            hacerPago();
        }

        private void hacerPago()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();
            queryStr = "";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }
            if (montoPagoTB.Text.Equals("") || codeUserTB.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - No puede dejar campos vacios;");
            }
            else
            {
                Session["uname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("AdminPage.aspx", false);
            }
            reader.Close();
            conn.Close();

        }

        
    }
}