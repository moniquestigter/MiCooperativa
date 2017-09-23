<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCuentaPage.aspx.cs" Inherits="MiCooperativa.NewCuentaPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NUEVA CUENTA PAGE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

             <p>Nombre del empleado: </p>
             <asp:TextBox ID ="nomEmpTB" Text="" runat="server" />
            <p>Ingrese el saldo inicial: </p>
             <asp:TextBox ID ="saldoTB" Text="" runat="server" />
            <p>Ingrese el tipo de cuenta: </p>
             <asp:TextBox ID ="tipoCuentaTB" Text="" runat="server" />
            <p>Ingrese el abono mensual: </p>
             <asp:TextBox ID ="abonoMenTB" Text="" runat="server" />

            <asp:Button ID="crearCuentaBT" Text="Crear Cuenta" runat="server" OnClick="submitEventMethodCrearCuenta" />

            <asp:Button ID="cancelarCuentaBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancel" />
        </div>
    </form>
</body>
</html>
