using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CAD;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SSCO___Crystal.html
{
    public partial class usuarios : System.Web.UI.Page
    {
        DTOUser user = new DTOUser();
        CADUser cadUser = new CADUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listUsers();
                loadProfessionDDL();
                loadRolesDDL();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initializeVars();
            user.User_Doc = Int64.Parse(txtDoc.Text);
            bool exist = cadUser.verifyUser(user);
            bool existEmail = cadUser.verifyUserEmail(user);

            if (exist == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Cédula registrada','El usuario ya existe');", true);
            }
            else if (existEmail == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Cédula registrada','El correo electrónico ya existe');", true);
            }
            else if (exist == false)
            {
                int data = cadUser.saveUser(user);
                if(data==0){
                    ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Registro fallido','El usuario no se pudo guardar');", true);
                }else if(data==1){
                    ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Registro exitoso','Usuario guardado correctamente');", true);   
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            user.User_Doc = Int64.Parse(txtDoc.Text);
            bool exist = cadUser.verifyUser(user);

            if (exist==false)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('No hay datos','Registro no encontrado');", true);   
            }
            else if (exist == true)
            {
                DTOUser us = cadUser.searchUser(user);
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Hay datos','Registro encontrado');", true);   
                txtName.Text = us.User_Name;
                txtLastname.Text = us.User_Lastname;
                txtEmail.Text = us.User_Email;
                txtCellphone.Text = us.User_Cellphone;
                ddlProfession.SelectedIndex = Int32.Parse(us.User_Profession);
                ddlRole.SelectedIndex = Int32.Parse(us.User_Role);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            initializeVars();

            int datos = cadUser.modifyUser(user);

            if (datos == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Modificación exitosa', 'El usuario se modificó correctamente');", true);   
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Modificación fallida','No se pudo modificar el usuario');", true);   
            }
        }

        protected void btnDesactivate_Click(object sender, EventArgs e)
        {
            user.User_Doc = Int64.Parse(txtDoc.Text);

            int datos = cadUser.deleteUser(user);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber eliminado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        private void listUsers()
        {
            grvUsers.DataSource = cadUser.listUsers(user);
            grvUsers.DataBind();
        }

        protected void btnListarUsuarios_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alertify.alert('Has listado');</script>");
            listUsers();
        }

        private void initializeVars()
        {
            user.User_Doc = Int64.Parse(txtDoc.Text);
            user.User_Name = txtName.Text;
            user.User_Lastname = txtLastname.Text;
            user.User_Email = txtEmail.Text;
            user.User_Cellphone = txtCellphone.Text;
            string profession = Convert.ToString(ddlProfession.SelectedIndex);
            string role = Convert.ToString(ddlRole.SelectedIndex);
            user.User_Profession = profession;
            user.User_Role = role;
        }

        private void loadProfessionDDL()
        {
            DataTable dt = cadUser.listProfessions();
            ddlProfession.DataSource = dt;
            ddlProfession.DataTextField = "nombre_Profesion";
            ddlProfession.DataValueField = "codigo_Profesion";
            ddlProfession.DataBind();
        }
        private void loadRolesDDL()
        {
            DataTable dt = cadUser.listRoles();
            ddlRole.DataSource = dt;
            ddlRole.DataTextField = "nombre_Rol";
            ddlRole.DataValueField = "codigo_Rol";
            ddlRole.DataBind();
        }
    }
}