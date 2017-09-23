<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmplDireccionesPage.aspx.cs" Inherits="MiCooperativa.NewEmplDireccionesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nuevo Empleado Direcciones</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <p>Hello</p>
            <asp:Label ID="userLabel" Text ="No User" runat="server" />

             <p>Ingrese numero de calle: </p>
            <asp:TextBox ID ="calleNumTB" Text="" runat="server" />
            <p>Ingrese avenida: </p>
            <asp:TextBox ID ="avenidaTB" Text="" runat="server" />
            <p>Ingrese numero de casa: </p>
            <asp:TextBox ID ="casaNumTB" Text="" runat="server" />
            <p>Ingrese ciudad: </p>
            <asp:TextBox ID ="ciudadTB" Text="" runat="server" />
            <p>Ingrese departamento: </p>
            <asp:TextBox ID ="departTB" Text="" runat="server" />
            <p>Ingrese referencia: </p>
            <asp:TextBox ID ="refTB" Text="" runat="server" />

            <asp:Button ID="nextEmplToTelefonosBT" Text="Siguiente" runat="server" OnClick="submitEventMethodNewEmployeeTelefonos" />

        </div>
    </form>
</body>
</html>
