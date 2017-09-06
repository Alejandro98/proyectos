<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asignar_miembros.aspx.cs" Inherits="SSCO___Crystal.html.asignar_miembros" %>

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
        <li><a href="profesiones.aspx">Profesiones</a></li>
        <li><a href="grupos.aspx">Grupos</a></li>
        <li><a href="asignar_miembros.aspx" class="active">Miembros</a></li>
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
                <h1>Asignación de Miembros</h1>
            </div>
            <div class="form">
                <label>
                    <span>Documento del usuario</span>
                    <asp:TextBox ID="txtDoc" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Código del grupo</span>
                    <asp:TextBox ID="txtGroup_Code" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Alias del miembro</span>
                    <asp:TextBox ID="txtNick" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <asp:Button ID="btnListMembers" CssClass="btn_form" OnClick="btnListMembers_Click" runat="server" Text="Listar miembros" />
            <div class="form_button">
                <asp:Button ID="btnAssign" CssClass="btn_form" OnClick="btnAssign_Click" runat="server" Text="Asignar" />
                <asp:Button ID="btnDesactivate" CssClass="btn_form" OnClick="btnDesactivate_Click" runat="server" Text="Desactivar" />
            </div>
            <div class="form_button">
                <asp:Button ID="btnBuscar" CssClass="btn_form" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                <asp:Button ID="btnUpdate" CssClass="btn_form" OnClick="btnUpdate_Click" runat="server" Text="Actualizar" />
            </div>
            <asp:GridView ID="grvMembers" CssClass="tabla" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Cédula" DataField="nombre_Usuario" />
                    <asp:BoundField HeaderText="Código del grupo" DataField="nombre_Grupo" />
                    <asp:BoundField HeaderText="Alias del miembto" DataField="alias_Miembro" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>
</html>
