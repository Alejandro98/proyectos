<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SSCO___Crystal.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Software de Seguimiento</title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/alertify.css" rel="stylesheet" />
    <link href="css/themes/default.css" rel="stylesheet" />
    <script src="js/alertify.js"></script>
    <script src="js/validation_script.js"></script>
</head>
<body>
    <div class="content">
        <form id="form1" class="basic" runat="server">
            <div class="title">
                <h1>Inicio de sesión</h1>
            </div>
            <div class="imagen ">
                <img src="../images/usuario.png" />
            </div>
            <div class="form">
                <label>
                    <span>Cédula</span>
                    <asp:TextBox ID="txtUser" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Contraseña</span>
                    <asp:TextBox TextMode="Password" ID="txtPassword"   CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form_button">
                <asp:Button ID="btnLogin" CssClass="btn_form" OnClick="btnLogin_Click" OnClientClick="return sesion();" runat="server" Text="Ingresar" />
            </div>
        </form>
    </div>
</body>
</html>
