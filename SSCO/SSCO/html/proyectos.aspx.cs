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
    public partial class proyectos : System.Web.UI.Page
    {
        DTOProject project = new DTOProject();
        CADProject cadProject = new CADProject();
        protected void Page_Load(object sender, EventArgs e)
        {
            listProjects();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initializeVars();

            int datos = cadProject.saveProject(project);

            if (datos == 0)
            {
                Response.Write("<script language='javascript'>alert('No se guardó el registro');</script>");
            }
            else if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Proyecto guardado correctamente');</script>");
            }
            else if (datos == 3)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Hey!You are legible to vote!');", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String[] d = cadProject.searchProject(Int32.Parse(txtCode.Text));

            txtCode.Text = d[0];
            txtName.Text = d[1];
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
            initializeVars();

            int datos = cadProject.modifyProject(project);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber modificado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        protected void btnDesactivate_Click(object sender, EventArgs e)
        {
            project.Project_Code = Int32.Parse(txtCode.Text);

            int datos = cadProject.deleteProject(project);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber eliminado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        private void listProjects()
        {
            grvProjects.DataSource = cadProject.listProjects(project);
            grvProjects.DataBind();
        }

        protected void btnListarProyectos_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alertify.alert('Has listado');</script>");
            listProjects();
        }

        private void initializeVars()
        {
            project.Project_Code = Int32.Parse(txtCode.Text);
            project.Project_Name = txtName.Text;
            project.Project_Description = txtDescription.Text;
        }
    }
}