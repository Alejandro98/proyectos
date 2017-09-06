<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proyectos.aspx.cs" Inherits="SSCO___Crystal.html.proyectos" %>

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
    <link href="../css/themes/default.css" rel="stylesheet" />
</head>
<body>
    <ul>
        <li><a href="usuarios.aspx">Usuario</a></li>
        <li><a href="roles.aspx">Roles</a></li>
        <li><a href="profesiones.aspx">Profesiones</a></li>
        <li><a href="grupos.aspx">Grupos</a></li>
        <li><a href="asignar_miembros.aspx">Miembros</a></li>
        <li><a href="proyectos.aspx" class="active">Proyectos</a></li>
        <li><a href="estados_proyecto.html">Estados Proyecto</a></li>
        <li><a href="fases_desarrollo.html">Fases Desarrollo</a></li>
        <li><a href="tareas.aspx">Tareas</a></li>
        <li><a href="entregables.html">Entregables</a></li>
        <li><a href="asignacion_entregables.html">Asignación Entregables</a></li>
        <li><a href="estados_entregables.html">Estados Entregables</a></li>
    </ul>
    <div class="content">
        <form id="form6" class="basic" runat="server">
            <div class="title">
                <h1>Gestión - Proyectos</h1>
            </div>
            <div class="imagen ">
                <img src="../images/grupo.png" />
            </div>
            <div class="form">
                <label>
                    <span>Código</span>
                    <asp:TextBox ID="txtCode" CssClass="input-form" runat="server"></asp:TextBox>
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
                    <span>Descripción</span>
                    <asp:TextBox TextMode="MultiLine" ID="txtDescription" CssClass="input-form" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnListarProyectos" CssClass="btn_form" OnClick="btnListarProyectos_Click" runat="server" Text="Listar Proyectos" />
            <asp:GridView ID="grvProjects" CssClass="tabla tabla_usuarios" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo_Proyecto" />
                    <asp:BoundField HeaderText="Nombre" DataField="nombre_Proyecto" />
                    <asp:BoundField HeaderText="Descripción" DataField="descripcion_Proyecto" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
        </form>
    </div>
</body>
</html>
