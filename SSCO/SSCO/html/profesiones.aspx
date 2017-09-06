<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profesiones.aspx.cs" Inherits="SSCO___Crystal.html.profesiones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Software de Seguimiento</title>
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <ul>
        <li><a href="usuarios.aspx">Usuario</a></li>
        <li><a href="roles.aspx">Roles</a></li>
        <li><a href="profesiones.aspx" class="active">Profesiones</a></li>
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
        <form id="form3" class="basic" runat="server">
            <div class="title">
                <h1>Gestión - Profesiones</h1>
            </div>
            <div class="form">
                <label>
                    <span>Código</span>
                    <asp:TextBox ID="txtCode" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Rol</span>
                    <asp:TextBox ID="txtProfession" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Descripción</span>
                    <asp:TextBox TextMode="MultiLine" ID="txtDescription" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form_button">
                <asp:Button ID="btnCreate" CssClass="btn_form" OnClick="btnCreate_Click" runat="server" Text="Crear" />
                <asp:Button ID="btnUndo" CssClass="btn_form" OnClick="btnUndo_Click" runat="server" Text="Deshacer" />
            </div>
            <div class="form_button">
                <asp:Button ID="btnSearch" CssClass="btn_form" OnClick="btnSearch_Click" runat="server" Text="Buscar" />
                <asp:Button ID="btnUpdate" CssClass="btn_form" OnClick="btnUpdate_Click" runat="server" Text="Actualizar" />
            </div>
            <asp:GridView ID="grvProfesiones" CssClass="tabla" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo_Profesion" />
                    <asp:BoundField HeaderText="Profesión" DataField="nombre_Profesion" />
                    <asp:BoundField HeaderText="Descripción" DataField="descripcion_Profesion" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>
</html>
