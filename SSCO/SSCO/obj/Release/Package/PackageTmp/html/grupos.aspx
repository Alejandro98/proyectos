<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grupos.aspx.cs" Inherits="SSCO___Crystal.html.grupos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <li><a href="grupos.aspx" class="active">Grupos</a></li>
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
                <h1>Gestión - Grupos</h1>
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
                    <span>Frase</span>
                    <asp:TextBox ID="txtPhrase" CssClass="input-form" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form">
                <label>
                    <span>Fase - Desarrollo</span>
                    <asp:DropDownList CssClass="select" ID="ddlFase" runat="server">
                        <asp:ListItem>Preproducción</asp:ListItem>
                        <asp:ListItem>Producción</asp:ListItem>
                        <asp:ListItem>Posproducción</asp:ListItem>
                    </asp:DropDownList>
                </label>
            </div>
            <input class="in_button" type="button"  value="Ver miembros" />
            <div class="form_button">
                <asp:Button ID="btnCreate" CssClass="btn_form" OnClick="btnCreate_Click" runat="server" Text="Crear" />
                <asp:Button ID="btnSearch" CssClass="btn_form" OnClick="btnSearch_Click" runat="server" Text="Buscar" />
            </div>
            <div class="form_button">
                <asp:Button ID="btnList" CssClass="btn_form" OnClick="btnList_Click" runat="server" Text="Listar grupos" />
            </div>
            <div class="form_button">
                <asp:Button ID="btnUpdate" CssClass="btn_form" OnClick="btnUpdate_Click" runat="server" Text="Actualizar" />
                <asp:Button ID="btnDesactivate" CssClass="btn_form" OnClick="btnDesactivate_Click" runat="server" Text="Desactivar" />
            </div>
            <asp:GridView ID="grvGroups" CssClass="tabla tabla_grupos" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo_Grupo" />
                    <asp:BoundField HeaderText="Nombre" DataField="nombre_Grupo" />
                    <asp:BoundField HeaderText="Frase" DataField="frase_Grupo" />
                    <asp:BoundField HeaderText="Fase Desarrollo" DataField="fase_Desarrollo_Grupo" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>
</html>
