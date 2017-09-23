<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCuentaPage.aspx.cs" Inherits="MiCooperativa.VerCuentaPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VER CUENTA PAGE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            <p>
            <p>Ingrese el nombre del empleado: </p>
             <asp:TextBox ID ="nomEmpleadoTB" Text="" runat="server" Width="175px" />
             <asp:Button ID="vercuentaBT" Text="Revisar Cuenta" runat="server" OnClick="submitEventMethodVerCuenta" />

        </p>

        <asp:GridView ID ="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
             <p></p>
            <asp:Button ID="editCuentaBT" Text="Editar" runat="server" OnClick="submitEventMethodEditarCuenta" Visible="False" />
            <asp:Button ID="deleteCuentaBT" Text="Eliminar" runat="server" OnClick="submitEventMethodEliminarCuenta" Visible ="False"/>
            <p></p>

            <asp:Panel ID="panelCuenta" GroupingText="CUENTA" runat="server" Width="585px" Visible="false">

            <asp:Label ID="nomlbl" Text ="Tipo de cuenta: " runat="server"/>
             <asp:TextBox ID ="editedTipoCuentaTB" runat="server" />
            <p></p>
            <asp:Label ID="Label2" Text ="Abono Mensual: " runat="server"  />
             <asp:TextBox ID ="editedAbonoMenTB" runat="server" />
            <p></p>

          </asp:Panel>
            
             <asp:Button ID="aceptarEditCuentaBT" Text="Aceptar" runat="server" OnClick="submitEventMethodAceptacionEditarCuenta" Visible="False" />
            <asp:Button ID="cancelEditCuentaBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelEditCuenta" Visible ="False"/>
            <p></p>
            <asp:Button ID="verPrestamoBT" Text="Ver Prestamo" runat="server" OnClick="submitEventMethodVerPrestamo" />
            <p></p>
            
            <asp:Button ID="hacerPrestamoBT" Text="Generar Prestamo" runat="server" OnClick="submitEventMethodHacerPrestamo" Visible="False" />
            
            
           
           
         <asp:Panel ID="panelHacerPrestamo" GroupingText="PRESTAMO" runat="server" Width="585px" Visible="false">
  

            <asp:Label ID="Label1" Text ="Monto de prestamo: " runat="server"/>
             <asp:TextBox ID ="montoPreTB" runat="server" />
            <p></p>
            <asp:Label ID="Label3" Text ="Periodos del prestamo: " runat="server"  />
             <asp:TextBox ID ="periodosPreTB" runat="server" />
            <p></p>
             <asp:Label ID="Label4" Text ="Tipo de prestamo: " runat="server"  />
             <asp:TextBox ID ="tipoPreTB" runat="server" />
             
               </asp:Panel>

            <asp:Button ID="aceptarPrestamoBT" Text="Listo" runat="server" OnClick="submitEventMethodAceptarPrestamo"  Visible="false" Height="46px" Width="139px"/>
 
            <asp:Button ID="cancelPrestamoBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelarPrestamo" Visible="False" Height="47px" Width="151px" />

            <asp:Button ID="aceptarEditacionPrestamoBT" Text="Listo" runat="server" OnClick="submitEventMethodAceptacionEditPrestamo"  Visible="false" Height="46px" Width="139px"/>
 
            <asp:Button ID="cancelarEditacionPrestamoBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelarEditPrestamo" Visible="False" Height="47px" Width="151px" />

            <asp:GridView ID ="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <p></p>
            <asp:Button ID="editarPrestamoBT" Text="Editar" runat="server" OnClick="submitEventMethodEditPrestamo"  Visible="false"/>
            <asp:Button ID="deletePrestamoBT" Text="Eliminar" runat="server" OnClick="submitEventMethodDeletePrestamo"  Visible="false"/>
            <p></p>
            <asp:Button ID="verPagosBT" Text="Ver Pagos" runat="server" OnClick="submitEventMethodVerPagos" Visible="False" />
            <p></p>
            
             <asp:GridView ID ="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <p></p>
            <asp:Button ID="editPagoBT" Text="Editar" runat="server" OnClick="submitEventMethodEditarPago" Visible="False" />
            <asp:Button ID="deletePagoBT" Text="Eliminar" runat="server" OnClick="submitEventMethodEliminarPago" Visible="False" />
            <p></p>
            <asp:Button ID="realizarPagoBT" Text="Realizar Pago" runat="server" OnClick="submitEventMethodHacerPago" Visible="False" />
             <asp:Panel ID="panelHacerPago" GroupingText="PAGO" runat="server" Width="585px" Visible="false">
  

            <asp:Label ID="Label6" Text ="Monto de pago: " runat="server"/>
             <asp:TextBox ID ="montoPagoTB" runat="server" />
       
               </asp:Panel>

            <asp:Button ID="aceptarPagoBT" Text="Listo" runat="server" OnClick="submitEventMethodAceptarPago"  Visible="false" Height="46px" Width="139px"/>
 
            <asp:Button ID="cancelarPagoBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelarPago" Visible="False" Height="47px" Width="151px" />

            <asp:Button ID="aceptarPagoEditBT" Text="Listo" runat="server" OnClick="submitEventMethodAceptacionEditPago"  Visible="false" Height="46px" Width="139px"/>
 
            <asp:Button ID="cancelarPagoEditBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelarEditPago" Visible="False" Height="47px" Width="151px" />

            <asp:Button ID="goBackBT" Text="Regresar" runat="server" OnClick="submitEventMethodGoBack" Visible="True" Height="47px" Width="151px" />
        </div>
    </form>
</body>
</html>
