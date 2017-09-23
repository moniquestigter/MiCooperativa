using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class VerCuentaPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr;
        String name;
        String codEmpEnSession, numCuentaEmpEnSession, codigoUsuarioEmpEnSession, numPrestamoEmpEnSession, numPagoEmpEnSession;
        String numCuenta, codEmp, fechaAper, saldoCu, antiCuenta, fechaCreacion, fechaUltima, userCreador, userUltima, tipoCuenta, abonoMen;
        String numPrestamo, montoPre, periodosPre, tipoPre, userCreadorPreReg, fechaCreacionPreReg, fechaPrestamoHecho, saldoPre, codigoEmpleadoPre;
        String numPago, fechaPago, montoPago, interesesPago, capitalPago, fechaCreacionPagoReg, userCreadorPagoReg, numeroPrestamoPago;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
            getEmpEnSession();
            getCodUserEnSession();

        }
        public void getEmpEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codigoemp_session_admin('" + nomEmpleadoTB.Text + "')";
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
        private void getNumPagoEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_numpago_session(" + Convert.ToInt32(Session["unumPrestamo"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                numPagoEmpEnSession = reader.GetString(reader.GetOrdinal("numero_pago"));
                Session["unumPago"] = numPagoEmpEnSession;
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

        protected void submitEventMethodVerCuenta(object sender, EventArgs e)
        {
            verCuenta();

        }

        private void verCuenta()
        {
            getNumCuentaEnSession();
            if (GridView1.Visible)
            {
                panelCuenta.Visible = false;
                aceptarEditCuentaBT.Visible = false;
                cancelEditCuentaBT.Visible = false;

            }
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_cuentas_read(" + Convert.ToInt32(Session["unumCuenta"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
              
                tipoCuenta = reader.GetString(reader.GetOrdinal("tipo_cuenta"));
                Session["utipoCuenta"] = tipoCuenta;
                abonoMen = reader.GetString(reader.GetOrdinal("abono_mensual"));
                Session["uabonoMen"] = abonoMen;
                fechaCreacion = reader.GetString(reader.GetOrdinal("fecha_creacion_reg"));
                Session["ufechacrea"] = fechaCreacion;
                userCreador = reader.GetString(reader.GetOrdinal("usuario_creador_reg"));
                Session["uusercrea"] = userCreador;
                antiCuenta = reader.GetString(reader.GetOrdinal("antiguedad_cuenta"));
                Session["uantiguedad"] = antiCuenta;

                reader.Close();
                editCuentaBT.Visible = true;
                deleteCuentaBT.Visible = true;
                GridView1.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView1.DataSource = tab;
                GridView1.DataBind();
            }
            else if (!reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no existe");
                reader.Close();
            }

            conn.Close();

        }
        public void submitEventMethodEditarCuenta(object sender, EventArgs e)
        {
            panelCuenta.Visible = true;

            aceptarEditCuentaBT.Visible = true;
            cancelEditCuentaBT.Visible = true;
            editedTipoCuentaTB.Text = (String)(Session["utipoCuenta"]);
            editedAbonoMenTB.Text = (String)(Session["uabonoMen"]);
        }

        protected void submitEventMethodAceptacionEditarCuenta(object sender, EventArgs e)
        {
            editCuenta();
        }

        private void editCuenta()
        {

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            string codigoCuentaQueEstoyEditing = (String)(Session["unumCuenta"]);
            string tipoCuentaEdit = editedTipoCuentaTB.Text;
            string abonoMenEdit = editedAbonoMenTB.Text;
            string fechaCreacionEdit = (String)(Session["ufechacrea"]);
            string userCreadorEdit = (String)(Session["uusercrea"]);
            string antiCuentaEdit = (String)(Session["uantiguedad"]);

            DateTime fcEDate = DateTime.Parse(fechaCreacionEdit);

            queryStr = "call mi_cooperativa.p_cuentas_update(" + Convert.ToInt32(codigoCuentaQueEstoyEditing) + ", '"+ fcEDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                " " + Convert.ToSingle(abonoMenEdit) + ", " + Convert.ToInt32(antiCuentaEdit) + ", " + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + ", " +
                "'" + fcEDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(userCreadorEdit) + ", " +
                " " + Convert.ToInt32(Session["ucodeUser"]) + ", '" + tipoCuentaEdit + "', " + Convert.ToSingle(abonoMenEdit) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            verCuenta();

        }

        protected void submitEventMethodEliminarCuenta(object sender, EventArgs e)
        {
           
        }

        protected void submitEventMethodCancelEditCuenta(object sender, EventArgs e)
        {
            panelCuenta.Visible = false;
            aceptarEditCuentaBT.Visible = false;
            cancelEditCuentaBT.Visible = false;
            
        }

        protected void submitEventMethodVerPrestamo(object sender, EventArgs e)
        {
            verPrestamo();
        }

        private void verPrestamo()
        {
            getNumPrestamoEnSession();
            if (panelHacerPrestamo.Visible)
            {
                aceptarEditacionPrestamoBT.Visible = false;
                cancelarEditacionPrestamoBT.Visible = false;
                panelHacerPrestamo.Visible = false;
                hacerPrestamoBT.Visible = false;
                aceptarPrestamoBT.Visible = false;
                cancelPrestamoBT.Visible = false;

            }
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_prestamos_read(" + Convert.ToInt32(Session["unumPrestamo"]) + ", " + Convert.ToInt32(Session["ucode"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            numPrestamo = "";
            reader.Read();
            if (reader.HasRows)
            {

                fechaPrestamoHecho = reader.GetString(reader.GetOrdinal("fecha_prestamo"));
                Session["ufechaPrestamo"] = fechaPrestamoHecho;
                saldoPre = reader.GetString(reader.GetOrdinal("saldo_prestamo"));
                Session["usaldoPrestamo"] = saldoPre;
                montoPre = reader.GetString(reader.GetOrdinal("monto_prestamo"));
                Session["umontoPre"] = montoPre;
                periodosPre = reader.GetString(reader.GetOrdinal("periodos_prestamo"));
                Session["uperiodosPre"] = periodosPre;
                fechaCreacionPreReg = reader.GetString(reader.GetOrdinal("fecha_creacion_reg"));
                Session["ufechaCreacionPreReg"] = fechaCreacionPreReg;
                userCreadorPreReg = reader.GetString(reader.GetOrdinal("usuario_creador_reg"));
                Session["uusercreaPre"] = userCreadorPreReg;
                tipoPre = reader.GetString(reader.GetOrdinal("tipo_prestamo"));
                Session["utipoPre"] = tipoPre;
                
                
                reader.Close();
                adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                GridView2.Visible = true;
                verPagosBT.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView2.DataSource = tab;
                GridView2.DataBind();
                editarPrestamoBT.Visible = true;
                deletePrestamoBT.Visible = true;
            }

            else
            {

                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Este empleado no tiene prestamos pendientes");
                reader.Close();
                hacerPrestamoBT.Visible = true;
            }


            conn.Close();
        }

        protected void submitEventMethodHacerPrestamo(object sender, EventArgs e)
        {
            panelHacerPrestamo.Visible = true;
            aceptarPrestamoBT.Visible = true;
            cancelPrestamoBT.Visible = true;

        }

        protected void submitEventMethodAceptarPrestamo(object sender, EventArgs e)
        {
            generarPrestamo();

        }
        private void generarPrestamo()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            if (montoPreTB.Text.Equals("") || periodosPreTB.Text.Equals("") || tipoPreTB.Text.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "ERROR - No puede dejar campos vacios;");
            }
            else
            {
                string clienteDelPrestamo = (String)(Session["ucode"]);
                
                queryStr = "call mi_cooperativa.p_prestamos_create('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToSingle(montoPreTB.Text) + "," + Convert.ToSingle(montoPreTB.Text) + ", " + Convert.ToInt32(periodosPreTB.Text) + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(Session["ucodeUser"]) + ", " + Convert.ToInt32(Session["ucodeUser"]) + ", '" + tipoPreTB.Text.ToString() + "', " + Convert.ToInt32(clienteDelPrestamo) + ")";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                reader = cmd.ExecuteReader();
            }
            reader.Close();
            conn.Close();
            verPrestamo();
          
        }

        protected void submitEventMethodCancelarPrestamo(object sender, EventArgs e)
        {
            panelHacerPrestamo.Visible = false;
            aceptarPrestamoBT.Visible = false;
            cancelPrestamoBT.Visible = false;
            

        }


        protected void submitEventMethodEditPrestamo(object sender, EventArgs e)
        {
            panelHacerPrestamo.Visible = true;
            montoPreTB.Text = (String)(Session["umontoPre"]);
            periodosPreTB.Text = (String)(Session["uperiodosPre"]);
            tipoPreTB.Text = (String)(Session["utipoPre"]);
            aceptarEditacionPrestamoBT.Visible = true;
            cancelarEditacionPrestamoBT.Visible = true;
            

        }
        protected void submitEventMethodAceptacionEditPrestamo(object sender, EventArgs e)
        {
            editPrestamo();

        }

        private void editPrestamo()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            string numeroPrestamoQueEstoyEditing = (String)(Session["unumPrestamo"]);
            string fechaPrestamoDoneEdit = (String)(Session["ufechaPrestamo"]);
            string saldoPrestamoEdit = montoPreTB.Text;
            string montoPrestamoEdit = montoPreTB.Text;
            string periodosPrestamoEdit = periodosPreTB.Text;
            string fechaCrecionPreRegEdit = (String)(Session["ufechaCreacionPreReg"]);
            string userCreadorPreRegEdit = (String)(Session["uusercreaPre"]);
            string tipoPrestamoEdit = tipoPreTB.Text;
            string userUltimaEdit = (String)(Session["ucodeUser"]);

            DateTime fpde = DateTime.Parse(fechaPrestamoDoneEdit);
            DateTime fcpr = DateTime.Parse(fechaCrecionPreRegEdit);

            queryStr = "call mi_cooperativa.p_prestamos_update(" + Convert.ToInt32(numeroPrestamoQueEstoyEditing) + ", '" + fpde.ToString("yyyy-MM-dd HH:mm:ss")+ "'," +
                "" + Convert.ToSingle(saldoPrestamoEdit) + ", " + Convert.ToSingle(montoPrestamoEdit) + ", " + Convert.ToInt32(periodosPrestamoEdit) + ", " +
                " '" + fcpr.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' , " + Convert.ToInt32(userCreadorPreRegEdit) + ", " +
                " " + Convert.ToInt32(userUltimaEdit) + ", '" + tipoPrestamoEdit + "', " + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            verPrestamo();

        }

        protected void submitEventMethodCancelarEditPrestamo(object sender, EventArgs e)
        {
            panelHacerPrestamo.Visible = false;
            aceptarEditacionPrestamoBT.Visible = false;
            cancelarEditacionPrestamoBT.Visible = false;
            

        }

        protected void submitEventMethodDeletePrestamo(object sender, EventArgs e)
        {
            

        }


        protected void submitEventMethodVerPagos(object sender, EventArgs e)
        {
            verPagos();

        }

        private void verPagos()
        {
            getNumPagoEnSession();
            if (panelHacerPago.Visible)
            {
                aceptarPagoEditBT.Visible = false;
                cancelarPagoEditBT.Visible = false;
                panelHacerPago.Visible = false;
                realizarPagoBT.Visible = false;
                aceptarPagoBT.Visible = false;
                cancelarPagoBT.Visible = false;

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
 
                fechaPago = reader.GetString(reader.GetOrdinal("fecha_pago"));
                Session["ufechaPago"] = fechaPago;
                montoPago = reader.GetString(reader.GetOrdinal("monto_pago"));
                Session["umontoPago"] = montoPago;
                interesesPago = reader.GetString(reader.GetOrdinal("intereses_pagados"));
                Session["uinteresesPago"] = interesesPago;
                capitalPago = reader.GetString(reader.GetOrdinal("capital_pagado"));
                Session["ucapitalPago"] = capitalPago;
                fechaCreacionPagoReg = reader.GetString(reader.GetOrdinal("fecha_creacion_reg"));
                Session["ufechaCreacionPagoReg"] = fechaCreacionPagoReg;
                userCreadorPagoReg = reader.GetString(reader.GetOrdinal("usuario_creador_reg"));
                Session["uuserCreadorPagoReg"] = userCreadorPagoReg;

                reader.Close();
                realizarPagoBT.Visible = true;
                editPagoBT.Visible = true;
                deletePagoBT.Visible = true;
                GridView3.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView3.DataSource = tab;
                GridView3.DataBind();
            }
            else if (!reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no ha realizado pagos");
                realizarPagoBT.Visible = true;
                reader.Close();
            }

            conn.Close();

        }

        protected void submitEventMethodHacerPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = true;
            aceptarPagoBT.Visible = true;
            cancelarPagoBT.Visible = true;

        }

        protected void submitEventMethodAceptarPago(object sender, EventArgs e)
        {

            generarPago();
        }

        private void generarPago()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            if (montoPagoTB.Text.Equals("") )
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

        protected void submitEventMethodEliminarPago(object sender, EventArgs e)
        {


        }

        

        protected void submitEventMethodCancelarPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = false;
            aceptarPagoBT.Visible = false;
            cancelarPagoBT.Visible = false;

        }

        protected void submitEventMethodEditarPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = true;
            montoPagoTB.Text = (String)(Session["umontoPago"]);
            aceptarEditacionPrestamoBT.Visible = true;
            cancelarEditacionPrestamoBT.Visible = true;

        }

        protected void submitEventMethodAceptacionEditPago(object sender, EventArgs e)
        {
            editPago();

        }

        private void editPago()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            string numeroPrestamoQueEstoyEditingElPagoDe = (String)(Session["unumPrestamo"]);
            string numeroPagoEdit = (String)(Session["unumPago"]);
            string fechaPagoEdit = (String)(Session["ufechaPago"]);
            string montoPagoEdit = montoPagoTB.Text;
            string interesesPagoEdit = (String)(Session["uinteresesPago"]);
            string capitalPagoEdit = (String)(Session["ucapitalPago"]);
            string fechaCreacionPagoRegEdit = (String)(Session["ufechaCreacionPagoReg"]);
            string userCreadorPagoRegEdit = (String)(Session["uuserCreadorPagoReg"]);
            string userUltimaEdit = (String)(Session["ucodeUser"]);

            DateTime fpe = DateTime.Parse(fechaPagoEdit);
            DateTime fcpre = DateTime.Parse(fechaCreacionPagoRegEdit);

            queryStr = "call mi_cooperativa.p_pagos_update(" + Convert.ToInt32(numeroPagoEdit) + ", '" + fpe.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "" + Convert.ToSingle(montoPagoEdit) + ", '" + fcpre.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' , " + Convert.ToInt32(userCreadorPagoRegEdit) + ", " +
                " " + Convert.ToInt32(userUltimaEdit) + "," + Convert.ToInt32(numeroPrestamoQueEstoyEditingElPagoDe) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            verPagos();

        }

        protected void submitEventMethodCancelarEditPago(object sender, EventArgs e)
        {
            panelHacerPago.Visible = false;
            aceptarEditacionPrestamoBT.Visible = false;
            cancelarEditacionPrestamoBT.Visible = false;

        }

        protected void submitEventMethodGoBack(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("AdminPage.aspx", false);

        }
    }
}