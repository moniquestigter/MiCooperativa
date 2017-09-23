using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class NewEmplDireccionesPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr, queryGetId;
        String name;
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
        }
        
        protected void submitEventMethodNewEmployeeTelefonos(object sender, EventArgs e)
        {
            registrarEnTablaDireccionesEmpleados();
        }


        private void registrarEnTablaDireccionesEmpleados()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryGetId = "call MI_COOPERATIVA.P_GET_EMPLEADO_CODE_FORINFO()";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryGetId, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows && reader.Read())
            {
                id = reader.GetString(reader.GetOrdinal("codigo_emp"));

            }
            reader.Close();
            queryStr = "call mi_cooperativa.p_direcciones_empleado_create('" + Convert.ToInt32(calleNumTB.Text.ToString()) + "','" + avenidaTB.Text.ToString() + "','" + Convert.ToInt32(casaNumTB.Text.ToString()) + "','" + ciudadTB.Text.ToString() + "','" + departTB.Text.ToString() + "','" + refTB.Text.ToString() + "', '" + Convert.ToInt32(id)+ "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();

            if (calleNumTB.Text.Equals("") || avenidaTB.Text.Equals("") || casaNumTB.Text.Equals("") || ciudadTB.Text.Equals("") || departTB.Text.Equals("") || refTB.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - No puede dejar campos vacios;");
            }
            else
            {
                Session["uname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("NewEmploTelPage.aspx", false);
            }
            reader.Close();
            conn.Close();
        }
    }
}