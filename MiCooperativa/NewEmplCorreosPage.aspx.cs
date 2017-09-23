﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class NewEmplCorreos : System.Web.UI.Page
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

        protected void submitEventMethodNewEmployee(object sender, EventArgs e)
        {
            registrarEnTablaCorreosEmpleados();
        }

        private void registrarEnTablaCorreosEmpleados()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryGetId = "call mi_cooperativa.P_GET_EMPLEADO_CODE_FORINFO()";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryGetId, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows && reader.Read())
            {
                id = reader.GetString(reader.GetOrdinal("codigo_emp"));

            }
            reader.Close();

            queryStr = "call mi_cooperativa.p_correos_electronicos_empleados_create('" + correo1TB.Text.ToString() + "','" + correo2TB.Text.ToString() + "','" + Convert.ToInt32(id) + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();

            if (correo1TB.Text.Equals("") || correo2TB.Text.Equals(""))
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