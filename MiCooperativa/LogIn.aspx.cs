using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class Login : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String name;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void submitEventMethodAdmin(object sender, EventArgs e)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_check_login_admin('" + usuarioTB.Text + "', '" + passwordTB.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            name = "";
            while (reader.HasRows && reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("usuario"));

            }
            if (reader.HasRows) {
                Session["uname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("AdminPage.aspx", false);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - Usuario invalido;");
            }
            reader.Close();
            conn.Close();
        }

        protected void submitEventMethodAfiliado(object sender, EventArgs e)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_check_login_afiliado('" + usuarioTB.Text + "', '" + passwordTB.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);


            reader = cmd.ExecuteReader();
            name = "";
            while (reader.HasRows && reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("usuario"));
            }

            if (reader.HasRows)
            {
                Session["uname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("AfiliadoPage.aspx", false);
            }
            else
            {
                passwordTB.Text = "usuario invalido";
            }
            reader.Close();
            conn.Close();

        }
    }
}