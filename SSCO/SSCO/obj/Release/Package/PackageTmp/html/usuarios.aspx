<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="SSCO___Crystal.html.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Software de Seguimiento</title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/alertify.css" rel="stylesheet" />
    <script src="../js/jquery-3.2.1.min.js"></script>
    <script src="../js/alertify.js"></script>
    <script src="../js/validation_script.js"></script>
    <link href="../css/themes/default.css" rel="stylesheet" />
</head>
<body>
    <ul>
        <li><a href="usuarios.aspx" class="active">Usuario</a></li>
        <li><a href="roles.aspx">Roles</a></li>
        <li><a href="profesiones.aspx">Profesiones</a></li>
        <li><a href="grupos.aspx">Grupos</a></li>
        <li><a href="asignar_miembros.aspx">Miembros</a></li>
        <li><a href="proyectos.aspx">Proyectos</a></li>
        <li><a href="estados_proyecto.html">Estados Proyecto</a></li>
        <li><a href="fases_desarrollo.html">Fases Desarrollo</a></li>
        <li><a href="tareas.aspx">Tareas</a></li>
        <li><a href="entregables.html">Entregables</a></li>
        <li><a href="asignacion_entregables.html">Asignación Entregables</a></li>
        <li><a href="estados_entregables.html">Estados Entregables</a></li>
    </ul>
    <div class="content">
        <form id="form1" class="basic" runat="server">
            <div class="title">
                <h1>Gestión - Usuarios</h1>
            </div>
            <div class="imagen ">
                <img src="../images/usuario.png" />
            </div>
            <div class="form">
                <label>
                    <span>Cédula</span>
                    <asp:TextBox ID="txtDoc" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Nombre</span>
                    <asp:TextBox ID="txtName" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Apellidos</span>
                    <asp:TextBox ID="txtLastname" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Correo</span>
                    <asp:TextBox ID="txtEmail" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Celular</span>
                    <asp:TextBox ID="txtCellphone" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Profesión</span>
                    <asp:DropDownList CssClass="select" ID="ddlProfession" runat="server">

                    </asp:DropDownList>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Rol</span>
                    <asp:DropDownList CssClass="select" ID="ddlRole" runat="server">

                    </asp:DropDownList>
                </label>
            </div>

            <div class="form_button">
                <asp:Button ID="btnSave" CssClass="btn_form" OnClick="btnSave_Click" OnClientClick="return validar();" runat="server" Text="Guardar" />
                <asp:Button ID="btnSearch" CssClass="btn_form" OnClick="btnSearch_Click" runat="server" Text="Buscar" />
            </div>
            <div class="form_button">
                <asp:Button ID="btnUpdate" CssClass="btn_form" OnClick="btnUpdate_Click" runat="server" Text="Actualizar" />
                <asp:Button ID="btnDesactivate" CssClass="btn_form" OnClick="btnDesactivate_Click" runat="server" Text="Desactivar" />
            </div>
            <asp:Button ID="btnListarUsuarios" CssClass="btn_form" OnClick="btnListarUsuarios_Click" runat="server" Text="Listar Usuarios" />
            <asp:GridView ID="grvUsers" CssClass="tabla tabla_usuarios" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Cédula" DataField="cedula_Usuario" />
                    <asp:BoundField HeaderText="Nombre" DataField="nombre_Usuario" />
                    <asp:BoundField HeaderText="Apellidos" DataField="apellidos_Usuario" />
                    <asp:BoundField HeaderText="Correo" DataField="correo_Usuario" />
                    <asp:BoundField HeaderText="Celular" DataField="celular_Usuario" />
                    <asp:BoundField HeaderText="Profesión" DataField="nombre_Profesion" />
                    <asp:BoundField HeaderText="Rol" DataField="nombre_Rol" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
        </form>
    </div>
    <script src="../js/jquery-3.2.1.min.js"></script>
    <script src="../js/alertify.js"></script>
    <script src="../js/validation_script.js"></script>
</body>
</html>
