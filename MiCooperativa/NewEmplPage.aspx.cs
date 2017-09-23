using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class NewEmplPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr;
        String name;
        String codigoUsuarioEmpEnSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
            getCodUserEnSession();
        }

        private void getCodUserEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codeusuario_session('" + name + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            codigoUsuarioEmpEnSession = reader.GetString(reader.GetOrdinal("codigo_usuario"));
            Session["ucodeUser"] = codigoUsuarioEmpEnSession;
            reader.Close();
            conn.Close();
        }

        protected void submitEventMethodNewEmployeeDirecciones(object sender, EventArgs e)
        {
            registrarEnTablaEmpleado();
        }

        private void registrarEnTablaEmpleado()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
 
            conn.Open();

            DateTime bday = DateTime.Parse(birthdayTB.Text.ToString());
           
            queryStr = "call mi_cooperativa.p_empleado_create('"+employeeNameTB.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Convert.ToInt32(Session["ucodeUser"]) + "," + Convert.ToInt32(Session["ucodeUser"]) + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + bday.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Convert.ToInt32(Session["ucodeUser"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }
            if(employeeNameTB.Text.Equals("") || birthdayTB.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - No puede dejar campos vacios;");
            }
            else
            {
                Session["uname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("NewEmplDireccionesPage.aspx", false);
            }
            reader.Close();
            conn.Close();
        }

        protected void submitEventMethodCancel(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("AdminPage.aspx", false);
        }
    }
}