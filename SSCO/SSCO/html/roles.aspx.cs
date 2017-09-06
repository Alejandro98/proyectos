using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CAD;
namespace SSCO___Crystal.html
{
    public partial class roles : System.Web.UI.Page
    {
        DTORole role = new DTORole();
        CADRole cadRole = new CADRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            listRoles();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            role.Role_Code = Int32.Parse(txtCode.Text);
            role.Role_Name = txtRole.Text;
            role.Role_Description = txtDescription.Text;

            int datos = cadRole.saveRole(role);

            if (datos == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('No se guardo el registro');", true);
            }
            else if (datos == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Rol guardado correctamente');", true);
            }
            else if (datos == 3)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('El rol ya existe!');", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            role.Role_Code = Int32.Parse(txtCode.Text);
            int datos = cadRole.deleteRole(role);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber eliminado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String[] d = cadRole.searchRole(Int32.Parse(txtCode.Text));

            txtCode.Text = d[0];
            txtRole.Text = d[1];
            txtDescription.Text = d[2];
            foreach (string field in d)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    Response.Write("<script language='javascript'>alert('Registro no encontrado');</script>");
                    break;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Registro encontrado');</script>");
                    break;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            role.Role_Code = Int32.Parse(txtCode.Text);
            role.Role_Name = txtRole.Text;
            role.Role_Description = txtDescription.Text;

            int datos = cadRole.modifyRole(role);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber modificado');</script>");
            }
            else
            {
                Console.WriteLine("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        public void listRoles()
        {
            grvRoles.DataSource = cadRole.listRoles(role);
            grvRoles.DataBind();
        }
    }
}