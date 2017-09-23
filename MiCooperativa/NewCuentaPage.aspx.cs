using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class NewCuentaPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String codigoUsuarioEmpEnSession, codEmpEnSession;
        String queryStr;
        String name;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;

            getCodUserEnSession();
            getEmpEnSession();

        }

        public void getEmpEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codigoemp_session('" + nomEmpTB.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                codEmpEnSession = reader.GetString(reader.GetOrdinal("codigo_emp"));
                Session["ucode"] = codEmpEnSession;
            }
            

            reader.Close();
            conn.Close();
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
            if (reader.HasRows)
            {
                codigoUsuarioEmpEnSession = reader.GetString(reader.GetOrdinal("codigo_usuario"));
                Session["ucodeUser"] = codigoUsuarioEmpEnSession;
            }
            
            reader.Close();
            conn.Close();
        }

        private int antiguedad(DateTime initial)
        {
         
          return Math.Abs((DateTime.Now.Month - initial.Month) + 12 * (DateTime.Now.Year - initial.Year));
            
        }

        protected void submitEventMethodCrearCuenta(object sender, EventArgs e)
        {
            crearCuenta();
        }

        private void crearCuenta()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();


            queryStr = "call mi_cooperativa.p_cuentas_create('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', "+ Convert.ToSingle(saldoTB.Text) + "," + antiguedad(DateTime.Now) + ", " + Convert.ToInt32(Session["ucode"]) + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(Session["ucodeUser"]) + ", " + Convert.ToInt32(Session["ucodeUser"]) + ", '" + tipoCuentaTB.Text.ToString() + "', " + Convert.ToSingle(abonoMenTB.Text) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            { 

            }
            if (nomEmpTB.Text.Equals("") || saldoTB.Text.Equals("") || tipoCuentaTB.Text.Equals("") || abonoMenTB.Text.Equals(""))
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
        protected void submitEventMethodCancel(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("AdminPage.aspx", false);
        }
    }
}