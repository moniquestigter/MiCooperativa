<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmplPage.aspx.cs" Inherits="MiCooperativa.NewEmplPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nuevo Empleado</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

             <p>Ingrese nombre de empleado: </p>
            <asp:TextBox ID ="employeeNameTB" Text="" runat="server" />
            <p>Ingrese fecha de nacimiento (utilice el formato MM/dd/yyyy): </p>
            <asp:TextBox ID ="birthdayTB" Text="" runat="server" />
           

            <asp:Button ID="nextEmplDirecTB" Text="Siguiente" runat="server" OnClick="submitEventMethodNewEmployeeDirecciones" />

            <p></p>
            <asp:Button ID="cancelBT" Text="Cancelar" runat="server" OnClick="submitEventMethodCancel" />
           

            
        </div>
    </form>
</body>
</html>
