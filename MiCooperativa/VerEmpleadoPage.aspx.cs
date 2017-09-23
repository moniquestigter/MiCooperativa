using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCooperativa
{
    public partial class VerEmpleadoPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        String queryStr, queryInicial;
        String codigoUsuarioEmpEnSession, codEmpEnSession, numPrestamoEmpEnSession, numCuentaEmpEnSession, codAbonoEmpEnSession, numPagoEmpEnSession;
        String name;
        String numPrestamo;
        String codEmp,nameEmp, fechaInicio, usuarioCreador, fechaNaci, codigoUser, calle, avenida, numCasa,city, depart, referencia, correo1, correo2, tel1, tel2, fechaCreacionReg;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["uname"]);
            userLabel.Text = name;
            getCodUserEnSession();
            getEmpEnSession();
            getNumCuentaEnSession();
            getNumPrestamoEnSession();
            getCodAbonoEmpEnSession();

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
            while (reader.HasRows && reader.Read())
            {
                codigoUsuarioEmpEnSession = reader.GetString(reader.GetOrdinal("codigo_usuario"));
                Session["ucodeUser"] = codigoUsuarioEmpEnSession;
            }
            
            reader.Close();
            conn.Close();
        }

        public void getEmpEnSession()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "call mi_cooperativa.p_get_codigoemp_session_admin('" + nomEmpTB.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            while (reader.HasRows && reader.Read())
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

        protected void submitEventMethodVerEmpleado(object sender, EventArgs e)
        {
            verEmp();

        }

        private void verEmp()
        {
            if (GridView1.Visible)
            {
                panelEmpleado.Visible = false;
                panelDireccionesEmpl.Visible = false;
                panelCorreos.Visible = false;
                paneltel.Visible = false;
                acceptEditBT.Visible = false;
                cancelEditBT.Visible = false;
   
                nomEmpTB.Text = editedNombreTB.Text;
            }
            
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            String codigo = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_empleado_read(" + Convert.ToInt32(codigo) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows) {

                nameEmp = reader.GetString(reader.GetOrdinal("nombre_emp"));
                Session["unom"] = nameEmp;
                fechaInicio = reader.GetString(reader.GetOrdinal("fecha_inicio_empresa"));
                Session["ufechaini"] = fechaInicio;
                fechaCreacionReg = reader.GetString(reader.GetOrdinal("fecha_creacion_reg"));
                Session["ufechCrea"] = fechaCreacionReg;
                usuarioCreador = reader.GetString(reader.GetOrdinal("usuario_creacion_reg"));
                Session["uusercrea"] = usuarioCreador;
                fechaNaci = reader.GetString(reader.GetOrdinal("fecha_nacimiento"));
                Session["ufechanaci"] = fechaNaci;
                codigoUser = reader.GetString(reader.GetOrdinal("codigo_usuario"));
                Session["ucodeusuario"] = codigoUser;
                reader.Close();
                
                GridView1.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView1.DataSource = tab;
                GridView1.DataBind();
            }
            else 
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no existe");
                reader.Close();
            }
            
            conn.Close();
            verEmpDireccion();
        }

        private void verEmpDireccion()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            String codigo = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_direcciones_empleado_read(" + Convert.ToInt32(codigo) + ")";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                calle = reader.GetString(reader.GetOrdinal("calle"));
                Session["ucalle"] = calle;
                avenida = reader.GetString(reader.GetOrdinal("avenida"));
                Session["uave"] = avenida;
                numCasa = reader.GetString(reader.GetOrdinal("numero_casa"));
                Session["unumcasa"] = numCasa;
                city = reader.GetString(reader.GetOrdinal("ciudad"));
                Session["ucity"] = city;
                depart = reader.GetString(reader.GetOrdinal("departamento"));
                Session["udepart"] = depart;
                referencia = reader.GetString(reader.GetOrdinal("referencia"));
                Session["uref"] = referencia;
                reader.Close();
                
                GridView2.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView2.DataSource = tab;
                GridView2.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no existe");
                reader.Close();
            }

            conn.Close();
            verEmpCorreos();
        }

        private void verEmpCorreos()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            String codigo = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_correos_electronicos_empleados_read(" + Convert.ToInt32(codigo) + ")";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                correo1 = reader.GetString(reader.GetOrdinal("correo_electronico1"));
                Session["ucor1"] = correo1;
                correo2 = reader.GetString(reader.GetOrdinal("correo_electronico2"));
                Session["ucor2"] = correo2;
                reader.Close();
                
                GridView3.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView3.DataSource = tab;
                GridView3.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no existe");
                reader.Close();
            }

            conn.Close();
            verEmpTelefonos();
        }

        private void verEmpTelefonos()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            String codigo = (String)(Session["ucode"]);
           
            queryStr = "call mi_cooperativa.p_telefonos_empleados_read(" + Convert.ToInt32(codigo) + ")";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                tel1 = reader.GetString(reader.GetOrdinal("telefono1"));
                Session["utel1"] = tel1;
                tel2 = reader.GetString(reader.GetOrdinal("telefono2"));
                Session["utel2"] = tel2;
                reader.Close();
                editEmpBT.Visible = true;
                deleteEmpBT.Visible = true;
                GridView4.Visible = true;
                System.Data.DataTable tab = new System.Data.DataTable();
                adapter.Fill(tab);
                GridView4.DataSource = tab;
                GridView4.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado no existe");
                reader.Close();
            }

            conn.Close();
        }

        public void submitEventMethodEditarEmpleado(object sender, EventArgs e)
        { 
            panelEmpleado.Visible = true;
            panelDireccionesEmpl.Visible = true;
            panelCorreos.Visible = true;
            paneltel.Visible = true;
            acceptEditBT.Visible = true;
            cancelEditBT.Visible = true;
            editedNombreTB.Text = (String)(Session["unom"]);
            editedFechaInicioTB.Text = (String)(Session["ufechaini"]);
            editedFechaNacimientoTB.Text = (String)(Session["ufechanaci"]);
            editedCalleTB.Text = (String)(Session["ucalle"]);
            editedAvenidaTB.Text = (String)(Session["uave"]);
            editedNumCasaTB.Text = (String)(Session["unumcasa"]);
            editedCiudadTB.Text = (String)(Session["ucity"]);
            editedDepartTB.Text = (String)(Session["udepart"]);
            editedRefTB.Text = (String)(Session["uref"]);
            editedCorreo1TB.Text = (String)(Session["ucor1"]);
            editedCorreo2TB.Text = (String)(Session["ucor2"]);
            editedTel1.Text = (String)(Session["utel1"]);
            editedTel2.Text = (String)(Session["utel2"]);

        }

        

        protected void submitEventMethodAceptarEditacion(object sender, EventArgs e)
        {
            editEmp();
        }

        private void editEmp()
        {
            
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            String fech = Session["ufechCrea"].ToString();
            DateTime dateini = DateTime.Parse(editedFechaInicioTB.Text);
            DateTime datecreacion = DateTime.Parse(fech);
            DateTime bday = DateTime.Parse(editedFechaNacimientoTB.Text);
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_empleado_update(" + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + " ," +
                "'" + editedNombreTB.Text + "', " +
                "'" + dateini.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                " " + Convert.ToInt32((String)(Session["uusercrea"])) + "," +
                " " + Convert.ToInt32(Session["ucodeUser"]) + "," +
                "'" + datecreacion.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "'" + bday.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            editDir();
        }

        private void editDir()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_direcciones_empleado_update(" + Convert.ToInt32(editedCalleTB.Text) + ", " +
               "'" + editedAvenidaTB.Text + "'," +
               " " + Convert.ToInt32(editedNumCasaTB.Text) + "," +
               "'" + editedCiudadTB.Text + "'," +
               "'" + editedDepartTB.Text + "'," +
               "'" + editedRefTB.Text + "', " +
               " " + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            editCorreos();
        }

        private void editCorreos()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_correos_electronicos_empleados_update('" + editedCorreo1TB.Text + "', " +
                " '" + editedCorreo2TB.Text + "'," +
                " " + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            editTel();
        }

        private void editTel()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            string codigoEmpleadoAlQueLeEstoyEditing = (String)(Session["ucode"]);
            queryStr = "call mi_cooperativa.p_telefonos_empleados_update('" + editedTel1.Text + "','" + editedTel2.Text + "', " + Convert.ToInt32(codigoEmpleadoAlQueLeEstoyEditing) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

            }
            reader.Close();
            conn.Close();
            verEmp();
        }
        protected void submitEventMethodCancelEdit(object sender, EventArgs e)
        {
            panelEmpleado.Visible = false;
            panelDireccionesEmpl.Visible = false;
            panelCorreos.Visible = false;
            paneltel.Visible = false;
            acceptEditBT.Visible = false;
            cancelEditBT.Visible = false;
     
        }

        protected void submitEventMethodEliminarEmpleado(object sender, EventArgs e)
        {
            deleteEmp();
        }

        private void deleteEmp()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MiCooperativaConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            String eraseCalle = (String)(Session["ucalle"]);
            String eraseAvenida = (String)(Session["uave"]);
            String eraseNumCasa = (String)(Session["unumcasa"]);
            String eraseCity = (String)(Session["ucity"]);
            String eraseDepart = (String)(Session["udepart"]);
            String eraseRef = (String)(Session["uref"]);
            String eraseCorreo1 = (String)(Session["ucor1"]);
            String eraseCorreo2 = (String)(Session["ucor2"]);
            String eraseTel1 = (String)(Session["utel1"]);
            String eraseTel2 = (String)(Session["utel2"]);

            queryInicial = "call mi_cooperativa.p_prestamos_read(" + Convert.ToInt32(Session["unumPrestamo"]) + ")";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryInicial, conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ClientScript.RegisterStartupScript(GetType(), "ShowMessageScript", "Empleado tiene prestamos pendientes");
                reader.Close();

            }
            else
            {
                
                queryStr += "call mi_cooperativa.p_direcciones_empleado_delete(" + Convert.ToInt32(eraseCalle)+ ",'" + eraseAvenida + "'," + Convert.ToInt32(eraseNumCasa) + ",'" + eraseCity + "','" + eraseDepart + "','" + eraseRef + "', " + Convert.ToInt32(Session["ucode"]) + ")";
                queryStr += "call mi_cooperativa.p_correos_electronicos_empleados_delete('" + eraseCorreo1 + "', '" + eraseCorreo2 + "', " + Convert.ToInt32(Session["ucode"]) + ")";
                queryStr += "call mi_cooperativa.p_telefonos_empleados_delete('" + eraseTel1 + "', '" + eraseTel2 + "', " + Convert.ToInt32(Session["ucode"]) + ")";
                queryStr += "call mi_cooperativa.p_abonos_delete(" + Convert.ToInt32(Session["ucodeAbono"]) + ", " + Convert.ToInt32(Session["unumCuenta"]) + " )";
                queryStr += "call mi_coooperativa.p_cuentas_delete(" + Convert.ToInt32(Session["unumCuenta"]) + ", " + Convert.ToInt32(Session["ucode"]) + " )";
                queryStr += "call mi_coooperativa.p_pagos_delete(" + Convert.ToInt32(Session["unumPago"]) + ", " + Convert.ToInt32(Session["unumPrestamo"]) + " )";
                queryStr = "call mi_cooperativa.p_empleado_delete(" + Convert.ToInt32(Session["ucode"]) + ", " + Convert.ToInt32(Session["ucodeUser"]) + ")";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                reader = cmd.ExecuteReader();
            }
            reader.Close();
            conn.Close();
            verEmp();

        }

        protected void submitEventMethodGoBack(object sender, EventArgs e)
        {
            Session["uname"] = name;
            Response.BufferOutput = true;
            Response.Redirect("AdminPage.aspx", false);
        }

    }
}