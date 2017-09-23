<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmploTelPage.aspx.cs" Inherits="MiCooperativa.NewEmploTelPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nuevo Empleado Telefono Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

            <p>Ingrese numero de telefono #1: </p>
            <asp:TextBox ID ="tel1TB" Text="" runat="server" />
            <p>Ingrese numero de telefono #2: </p>
            <asp:TextBox ID ="tel2TB" Text="" runat="server" />


            <asp:Button ID="submitNewEmpBt" Text="Siguiente" runat="server" OnClick="submitEventMethodNewEmployee" />

        </div>
    </form>
</body>
</html>
