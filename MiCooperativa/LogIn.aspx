




<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MiCooperativa.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <p>Login</p>
    <form id="form1" runat="server">
        <div>

            <p>Ingrese su usuario: </p>
            <asp:TextBox ID ="usuarioTB" Text="" runat="server" />
            <p>Ingrese su contraseña: </p>
            <asp:TextBox ID ="passwordTB" Text="" runat="server" />
            <p></p>
            <asp:Button ID="submitBt" Text="Ingresar Administrador" runat="server" OnClick="submitEventMethodAdmin" />
            
            <asp:Button ID="submitBt2" Text="Ingresar Cliente" runat="server" OnClick="submitEventMethodAfiliado" />

        </div>
    </form>
</body>
</html>
