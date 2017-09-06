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
    public partial class asignar_miembros : System.Web.UI.Page
    {
        DTOMember member = new DTOMember();
        CADMember cadMember = new CADMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            listMembers();
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            member.Member_Doc = Int32.Parse(txtDoc.Text);
            member.Member_Group = Int32.Parse(txtGroup_Code.Text);
            member.Member_Nick = txtNick.Text;

            int datos = cadMember.saveMember(member);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Miembro asignado correctamente');</script>");
            }
            else if (datos == 0)
            {
                Response.Write("<script language='javascript'>alert('No se guardó el registro');</script>");
            }
        }

        protected void btnListMembers_Click(object sender, EventArgs e)
        {
            listMembers();
        }

        public void listMembers()
        {
            grvMembers.DataSource = cadMember.listMembers(member);
            grvMembers.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String[] d = cadMember.searchMember(Int32.Parse(txtDoc.Text));

            txtDoc.Text = d[0];
            txtGroup_Code.Text = d[1];
            txtNick.Text = d[2];

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
            member.Member_Doc = Int32.Parse(txtDoc.Text);
            member.Member_Group = Int32.Parse(txtGroup_Code.Text);
            member.Member_Nick = txtNick.Text;

            int datos = cadMember.modifyMember(member);

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
            member.Member_Doc = Int32.Parse(txtDoc.Text);

            int datos = cadMember.deleteMember(member);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber eliminado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }
    }
}