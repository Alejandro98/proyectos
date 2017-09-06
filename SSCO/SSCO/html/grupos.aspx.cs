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
    public partial class grupos : System.Web.UI.Page
    {
        DTOGroup group = new DTOGroup();
        CADGroup cadGroup = new CADGroup();
        protected void Page_Load(object sender, EventArgs e)
        {
            listGroups();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            group.Group_Code = Int32.Parse(txtCode.Text);
            group.Group_Name = txtName.Text;
            group.Group_Phrase = txtPhrase.Text;
            group.Group_Development_Fase = ddlFase.Text;

            int datos = cadGroup.saveGroup(group);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Grupo guardado correctamente');</script>");
            }
            else if (datos == 0)
            {
                Response.Write("<script language='javascript'>alert('No se guardó el registro');</script>");
            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            listGroups();
        }

        public void listGroups()
        {
            grvGroups.DataSource = cadGroup.listGroups(group);
            grvGroups.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            group.Group_Code = Int32.Parse(txtCode.Text);
            group.Group_Name = txtName.Text;
            group.Group_Phrase = txtPhrase.Text;
            group.Group_Development_Fase = ddlFase.Text;

            int datos = cadGroup.modifyGroup(group);

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
            group.Group_Code = Int32.Parse(txtCode.Text);

            int datos = cadGroup.deleteGroup(group);

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
            String[] d = cadGroup.searchGroup(Int32.Parse(txtCode.Text));

            txtCode.Text = d[0];
            txtName.Text = d[1];
            txtPhrase.Text = d[2];
            ddlFase.Text = d[3];
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
    }
}