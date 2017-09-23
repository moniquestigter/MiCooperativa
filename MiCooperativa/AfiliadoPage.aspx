<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoPage.aspx.cs" Inherits="MiCooperativa.AfiliadoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AFILIADO PAGINA</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            <p></p>
            <asp:Button ID="verCuentasBT" Text="Ver sus cuentas" runat="server" OnClick="submitEventMethodVerCuentas"/>
            <p></p>
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
            <p></p>
            <asp:Button ID="verAbonosBT" Text="Ver sus abonos" runat="server" OnClick="submitEventMethodVerAbonos"/>
            <p></p>
             <asp:GridView ID ="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
             <p></p>
            <asp:Button ID="verPrestamosBT" Text="Ver sus prestamos" runat="server" OnClick="submitEventMethodVerPrestamos" />
            <p></p>
             <asp:GridView ID ="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <asp:Button ID="verPagosBT" Text="Ver sus pago" runat="server" OnClick="submitEventMethodVerPagos" Visible ="False"/>
             <p></p>
             <asp:Button ID="estadoDeCuentaBT" Text="Generar Estado de Cuenta" runat="server" OnClick="submitEventMethodEstadoDeCuenta"/>
             <p></p>
              <asp:GridView ID ="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <asp:Button ID="realizarPagoPrestamoBT" Text="Realizar pago" runat="server" OnClick="submitEventMethodHacerPago" Visible ="False"/>
            <p></p>
            <asp:Panel ID="panelHacerPago" GroupingText="PAGO" runat="server" Width="585px" Visible="false">
  

            <asp:Label ID="Label6" Text ="Monto de pago: " runat="server"/>
             <asp:TextBox ID ="montoPagoTB" runat="server" />
             </asp:Panel>
            <p></p>
            <asp:Button ID="acceptPagoBT" Text="Aceptar pago" runat="server" OnClick="submitEventMethodGenerarPago" Visible ="False"/>

            <asp:Button ID="cancelPagoBT" Text="Cancelar pago" runat="server" OnClick="submitEventMethodCancelPago" Visible ="False"/>

             <p></p>

        </div>
    </form>
    <p>
     </p>
</body>
</html>
