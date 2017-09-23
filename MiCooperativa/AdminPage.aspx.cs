using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class AdminPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr;
        String name;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
        }

        protected void submitEventMethodNuevoEmpleado(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("NewEmplPage.aspx", false);

        }

        protected void submitEventMethodNuevaCuenta(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("NewCuentaPage.aspx", false);

        }

        protected void submitEventMethodVerCuenta(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("VerCuentaPage.aspx", false);

        }

        protected void submitEventMethodBuscarEmpleado(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("VerEmpleadoPage.aspx", false);

        }

        protected void submitEventMethodSalir(object sender, EventArgs e)
        {
            
            Response.BufferOutput = true;
            Response.Redirect("LogIn.aspx", false);

        }

        protected void submitEventMethodReporteDividendos(object sender, EventArgs e)
        {

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_reporte_dividendos_read()";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                reader.Close();
                GridView1.Visible = true;
  
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView1.DataSource = tab;
                GridView1.DataBind();
            }

            else
            {

                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No hay perrroo");
                reader.Close();
            }

            
            conn.Close();

        }

    }
}