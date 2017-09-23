using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class AfiliadoPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr;
        String name;
        String codEmpEnSession, numCuentaEmpEnSession, codigoUsuarioEmpEnSession, numPrestamoEmpEnSession, tipoCuentaEmpEnSession, codAbonoEmpEnSession;
        String saldoCuenta, fechaUltima, userUltima;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
            getEmpEnSession();
            getCodUserEnSession();
            getNumCuentaEnSession();
            getNumPrestamoEnSession();
            getTipoCuentaEnSession();
            getCodAbonoEmpEnSession();
        }

        public void getEmpEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codigoemp_session('" + name + "')";
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

        private void getCodAbonoEmpEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codeabono_session(" + Convert.ToInt32(Session["unumCuenta"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                codAbonoEmpEnSession = reader.GetString(reader.GetOrdinal("codigo_abono"));
                Session["ucodeAbono"] = codAbonoEmpEnSession;
            }

            reader.Close();
            conn.Close();
        }

        public void getNumPrestamoEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_numprestamo_session(" + Convert.ToInt32(Session["ucode"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                numPrestamoEmpEnSession = reader.GetString(reader.GetOrdinal("numero_prestamo"));
                Session["unumPrestamo"] = numPrestamoEmpEnSession;
            }
            

            reader.Close();
            conn.Close();
        }


        private void getNumCuentaEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_numcuenta_session(" + Convert.ToInt32(Session["ucode"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                numCuentaEmpEnSession = reader.GetString(reader.GetOrdinal("numero_cuenta"));
                Session["unumCuenta"] = numCuentaEmpEnSession;
            }
            
            reader.Close();
            conn.Close();
        }
        private void getTipoCuentaEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_tipocuenta_session(" + Convert.ToInt32(Session["unumCuenta"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                tipoCuentaEmpEnSession = reader.GetString(reader.GetOrdinal("tipo_cuenta"));
                Session["utipoCuenta"] = tipoCuentaEmpEnSession;
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


        protected void submitEventMethodVerCuentas(object sender, EventArgs e)
        {
            verCuentas();

        }
        private void verCuentas()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_cuentas_read(" + Convert.ToInt32(Session["unumCuenta"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            String tipodecuenta = (String)(Session["utipoCuenta"]);
            if (reader.Read())
            {
                saldoCuenta = reader.GetString(reader.GetOrdinal("saldo_cuenta"));
                Session["usaldoCuenta"] = saldoCuenta;
                fechaUltima = reader.GetString(reader.GetOrdinal("fecha_ultima_act"));
                Session["ufechaUltim"] = fechaUltima;
                userUltima = reader.GetString(reader.GetOrdinal("usuario_ultima_act"));
                Session["uuserUltima"] = userUltima;

                reader.Close();
                GridView1.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView1.DataSource = tab;
                GridView1.DataBind();
      
              
            }
            else if (!reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No tiene cuentas");
                reader.Close();
            }
            conn.Close();
        }

        protected void submitEventMethodVerAbonos(object sender, EventArgs e)
        {
            verAbonos();

        }
        private void verAbonos()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_abonos_read(" + Convert.ToInt32(Session["ucodeAbono"]) + ", " + Convert.ToInt32(Session["unumCuenta"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                reader.Close();
                GridView4.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView4.DataSource = tab;
                GridView4.DataBind();


            }
            else if (!reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No tiene abonos");
                reader.Close();
            }
            conn.Close();
        }



        protected void submitEventMethodVerPrestamos(object sender, EventArgs e)
        {
            verPrestamo();

        }

        private void verPrestamo()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_prestamos_read(" + Convert.ToInt32(Session["unumPrestamo"]) + ", " + Convert.ToInt32(Session["ucode"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                GridView2.Visible = true;
                verPagosBT.Visible = true;
                realizarPagoPrestamoBT.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView2.DataSource = tab;
                GridView2.DataBind();
            }

            else
            {

                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No tiene prestamos pendientes");
            }

            reader.Close();
            conn.Close();
        }

        protected void submitEventMethodVerPagos(object sender, EventArgs e)
        {
            verPagos();

        }

        private void verPagos()
        {
            
            if (panelHacerPago.Visible)
            {
                acceptPagoBT.Visible = false;
                cancelPagoBT.Visible = false;
                panelHacerPago.Visible = false;
                realizarPagoPrestamoBT.Visible = false;

            }
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            string numeroPrestamoARealizarPago = (String)(Session["unumPrestamo"]);
            queryStr = "call mi_cooperativa.p_pagos_read(" + Convert.ToInt32(Session["unumPago"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                reader.Close();
                realizarPagoPrestamoBT.Visible = true;
                GridView3.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView3.DataSource = tab;
                GridView3.DataBind();
            }
            else if (!reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No ha realizado ningun pago");
                realizarPagoPrestamoBT.Visible = true;
                reader.Close();
            }

            conn.Close();

        }

        protected void submitEventMethodHacerPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = true;
            acceptPagoBT.Visible = true;
            cancelPagoBT.Visible = true;

        }
        protected void submitEventMethodGenerarPago(object sender, EventArgs e)
        {
            acceptPago();

        }

        private void acceptPago()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            if (montoPagoTB.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - No puede dejar campos vacios;");
            }
            else
            {
                string numeroPrestamoARealizarPago = (String)(Session["unumPrestamo"]);

                queryStr = "call mi_cooperativa.p_pagos_create('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToSingle(montoPagoTB.Text) + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(Session["ucodeUser"]) + ", " + Convert.ToInt32(Session["ucodeUser"]) + "," + Convert.ToInt32(numeroPrestamoARealizarPago) + ")";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                reader = cmd.ExecuteReader();
            }
            reader.Close();
            conn.Close();
            verPagos();
        }

        protected void submitEventMethodCancelPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = false;
            acceptPagoBT.Visible = false;
            cancelPagoBT.Visible = false;

        }

        protected void submitEventMethodEstadoDeCuenta(object sender, EventArgs e)
        {
            generarEstadoDeCuenta();

        }

        private void generarEstadoDeCuenta()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_prestamos_read(" + Convert.ToInt32(Session["unumPrestamo"]) + ", " + Convert.ToInt32(Session["ucode"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                GridView2.Visible = true;
                verPagosBT.Visible = true;
                realizarPagoPrestamoBT.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView2.DataSource = tab;
                GridView2.DataBind();
            }

            else
            {

                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "No tiene prestamos pendientes");
            }

            reader.Close();
            conn.Close();
        }

        protected void submitEventMethodGoBack(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("LogIn.aspx", false);

        }

    }

}