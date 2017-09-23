<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerEmpleadoPage.aspx.cs" Inherits="MiCooperativa.VerEmpleadoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VER EMPLEADO PAGE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <p>Hello
            <asp:Label ID="userLabel" Text ="No User" runat="server" />
            </p>
            
            
            <p>Ingrese el nombre del empleado: </p>
             <asp:TextBox ID ="nomEmpTB" Text="" runat="server" Width="175px" />
             <asp:Button ID="buscarEmpBT" Text="Revisar Empleado" runat="server" OnClick="submitEventMethodVerEmpleado" />

       <p></p>

        <asp:GridView ID ="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
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
            <asp:GridView ID ="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
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

            <asp:Button ID="editEmpBT" Text="Editar" runat="server" OnClick="submitEventMethodEditarEmpleado" Visible="False" />
            <asp:Button ID="deleteEmpBT" Text="Eliminar" runat="server" OnClick="submitEventMethodEliminarEmpleado" Visible ="False"/>
            <p></p>
            
          <asp:Panel ID="panelEmpleado" GroupingText="EMPLEADO" runat="server" Width="585px" Visible="false">

            <asp:Label ID="nomlbl" Text ="Nombre: " runat="server"/>
             <asp:TextBox ID ="editedNombreTB" runat="server" />
            <p></p>
            <asp:Label ID="Label2" Text ="Fecha inicio en empresa: " runat="server"  />
             <asp:TextBox ID ="editedFechaInicioTB" runat="server" />
            <p></p>
            <asp:Label ID="Label3" Text ="Fecha de nacimiento: " runat="server" />
             <asp:TextBox ID ="editedFechaNacimientoTB"  runat="server" />
            <p></p>

          </asp:Panel>
            
           <asp:Panel ID="panelDireccionesEmpl" GroupingText="DIRECCION" runat="server" Width="585px" Visible="false">

             <asp:Label ID="Label5" Text ="Calle: " runat="server" />
             <asp:TextBox ID ="editedCalleTB" Text="" runat="server" />
                <p>
                </p>
                <asp:Label ID="Label6" runat="server" Text="Avenida: " />
                <asp:TextBox ID="editedAvenidaTB" runat="server" Text="" />
                    <p>
                    </p>
                    <asp:Label ID="Label7" runat="server" Text="Numero de casa: " />
                    <asp:TextBox ID="editedNumCasaTB" runat="server" Text="" />
                    <p>
                    </p>
                    <asp:Label ID="Label8" runat="server" Text="Ciudad: " />
                    <asp:TextBox ID="editedCiudadTB" runat="server" Text="" />
                    <p>
                    </p>
                    <asp:Label ID="Label9" runat="server" Text="Departamento: " />
                    <asp:TextBox ID="editedDepartTB" runat="server" Text="" />
                    <p>
                    </p>
                    <asp:Label ID="Label10" runat="server" Text="Referencia: " />
                    <asp:TextBox ID="editedRefTB" runat="server" Text="" />

           </asp:Panel>
            
          <asp:Panel ID="panelCorreos" GroupingText="CORREOS ELECTRONICOS" runat="server" Width="585px" Visible="false">
            
            <asp:Label ID="Label12" Text ="Correo #1" runat="server" />
             <asp:TextBox ID ="editedCorreo1TB" Text="" runat="server" />
              <p></p>
            <asp:Label ID="Label13" Text ="Correo #2" runat="server" />
             <asp:TextBox ID ="editedCorreo2TB" Text="" runat="server" />

           </asp:Panel>

           <asp:Panel ID="paneltel" GroupingText="TELEFONOS" runat="server" Width="585px" Visible="false">

            <asp:Label ID="Label15" Text ="Telefono #1: " runat="server" />
             <asp:TextBox ID ="editedTel1" Text="" runat="server" />
               <p></p>
            <asp:Label ID="Label16" Text ="Telefono #2: " runat="server" />
             <asp:TextBox ID ="editedTel2" Text="" runat="server" />

          </asp:Panel>

             <asp:Button ID="acceptEditBT" Text="Aceptar" runat="server" OnClick="submitEventMethodAceptarEditacion" Visible="False" Height="41px" Width="162px" />
             <asp:Button ID="cancelEditBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancelEdit" Visible="False" Height="41px" Width="162px" />
            <p>
            </p>
            <asp:Button ID="goBackBT" Text="Regresar" runat="server" OnClick="submitEventMethodGoBack"/>

        </div>
    </form>
</body>
</html>
