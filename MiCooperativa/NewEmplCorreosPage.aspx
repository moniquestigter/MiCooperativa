<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmplCorreosPage.aspx.cs" Inherits="MiCooperativa.NewEmplCorreos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Empleados Correos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <p>Hello
            <asp:Label ID="userLabel" Text ="No User" runat="server" />
            </p>

            <p>Ingrese el correo electronico #1: </p>
            <asp:TextBox ID ="correo1TB" Text="" runat="server" />
            <p>Ingrese el correo electronico #2: </p>
            <asp:TextBox ID ="correo2TB" Text="" runat="server" />


            <asp:Button ID="submitNewEmpBt" Text="Listo" runat="server" OnClick="submitEventMethodNewEmployee" />

        </div>
    </form>
</body>
</html>
