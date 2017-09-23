<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="MiCooperativa.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMINISTRADOR PAGINA</title>
</head>
<body style="height: 477px">
    <form id="form1" runat="server">
        <div style="height: 111px">
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            

        </div>
        <p>

            <asp:Button ID="nuevoEmpleadoBt" Text="Nuevo Empleado" runat="server" OnClick="submitEventMethodNuevoEmpleado" />
            <asp:Button ID="buscarEmpleadoBT" Text="Buscar Empleado" runat="server" OnClick="submitEventMethodBuscarEmpleado" />

             </p>
        <p>
            &nbsp;</p>
        <p>

             <asp:Button ID="newcuenaBt" Text="Nueva Cuenta" runat="server" OnClick="submitEventMethodNuevaCuenta" />

             <asp:Button ID="vercuentaBT" Text="Buscar Cuenta" runat="server" OnClick="submitEventMethodVerCuenta" />
            <p></p>
             <asp:Button ID="generarReporteDividendosBT" Text="Generar Reporte Dividendos" runat="server" OnClick="submitEventMethodReporteDividendos" />
             </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
        <asp:Button ID="goBackBT" Text="Salir" runat="server" OnClick="submitEventMethodSalir" />

    </form>
</body>
</html>
