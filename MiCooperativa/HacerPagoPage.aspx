<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HacerPagoPage.aspx.cs" Inherits="MiCooperativa.HacerPagoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hacer Pago Pagina</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <p>Hello
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            <p>Numero de Prestamo: </p>
            <asp:TextBox ID ="numPrestamoTB" Text="" runat="server" />
            <p>Ingrese monto de pago: </p>
            <asp:TextBox ID ="montoPagoTB" Text="" runat="server" />
            <p>Ingrese su codigo de usuario: </p>
            <asp:TextBox ID ="codeUserTB" Text="" runat="server" />

            <asp:Button ID="hacerPagoBT" Text="Realizar Pago" runat="server" OnClick="submitEventMethodHacerPago" />
            </p>
        </div>
    </form>
</body>
</html>
