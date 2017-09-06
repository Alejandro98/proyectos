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
    public partial class profesiones : System.Web.UI.Page
    {
        DTOProfession profession = new DTOProfession();
        CADProfession cadProfession = new CADProfession();
        protected void Page_Load(object sender, EventArgs e)
        {
            listProfessions();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            profession.Profession_Code = Int32.Parse(txtCode.Text);
            profession.Profession_Name = txtProfession.Text;
            profession.Profession_Description = txtDescription.Text;

            int datos = cadProfession.saveProfession(profession);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Profesión guardada correctamente');</script>");
            }
            else if (datos == 0)
            {
                Response.Write("<script language='javascript'>alert('No se guardó el registro');</script>");
            }
        }

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            int datos = cadProfession.undoProfession();

            if (datos == 1)
            {
                Console.WriteLine("Acción completada");
            }
            else
            {
                Console.WriteLine("Verifique su programación");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String[] d = cadProfession.searchProfession(Int32.Parse(txtCode.Text));

            txtCode.Text = d[0];
            txtProfession.Text = d[1];
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
            profession.Profession_Code = Int32.Parse(txtCode.Text);
            profession.Profession_Name= txtProfession.Text;
            profession.Profession_Description = txtDescription.Text;

            int datos = cadProfession.modifyProfession(profession);

            if (datos == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber modificado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        public void listProfessions()
        {
            grvProfesiones.DataSource = cadProfession.listProfessions(profession);
            grvProfesiones.DataBind();
        }
    }
}