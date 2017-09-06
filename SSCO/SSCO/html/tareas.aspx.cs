using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CAD;
using System.IO;

namespace SSCO___Crystal.html
{
    public partial class tareas : System.Web.UI.Page
    {
        DTOTask task = new DTOTask();
        CADTask cadTask = new CADTask();
        static string dp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            listTasks();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initializeVars();

            int datos = cadTask.saveTask(task);

            if (datos == 0)
            {
                Response.Write("<script language='javascript'>alert('No se guardó el registro');</script>");
            }
            else if (datos == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Tarea guardada correctamente');", true);
            }
            else if (datos == 3)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('La tarea ya existe');", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string[] data = cadTask.searchTask(Int32.Parse(txtCode.Text));

            txtCode.Text = data[0];
            txtDescription.Text = data[1];
            txtDuration.Text = data[2];
            DateTime date = DateTime.Parse(data[3]).Date;
            txtDate.Text = date.ToString("yyyy-MM-dd");
            dp = data[4].ToString();
            Response.Write(date);

            foreach (string field in data)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    Response.Write("<script language='javascript'>alert('Registro no encontrado');</script>");
                    break;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Registro encontrado');</script>");
                    spNombreArchivo.Text = dp;
                    break;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            initializeVars();

            int datos = cadTask.modifyTask(task);

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
            task.Task_Code = Int32.Parse(txtCode.Text);

            int data = cadTask.deleteTask(task);

            if (data == 1)
            {
                Response.Write("<script language='javascript'>alert('Debió haber eliminado');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Verifique su programación');</script>");
            }
        }

        private void listTasks()
        {
            grvTask.DataSource = cadTask.listTasks(task);
            grvTask.DataBind();
        }

        protected void btnListTasks_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alertify.alert('Has listado');</script>");
            listTasks();
        }

        private void initializeVars()
        {
            task.Task_Code = Int32.Parse(txtCode.Text);
            task.Task_Description = txtDescription.Text;
            task.Task_Duration = Int32.Parse(txtDuration.Text);
            DateTime date = DateTime.Parse(txtDate.Text);
            task.Task_Date = date.ToString("yyyy-MM-dd");
            task.Task_FileName = Path.GetFileName(fluFile.FileName);

            if (IsPostBack)
            {
                Boolean fileOK = false;
                String path = Server.MapPath("~/images/loaded_files/");
                if (fluFile.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(fluFile.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", ".pdf", ".txt", ".rar", ".zip" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        fluFile.PostedFile.SaveAs(path
                            + fluFile.FileName);
                        ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Archivo cargado');", true);
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('El archivo no pudo ser cargado');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('No se aceptan archivos de este tipo');", true);
                }
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            if (dp.Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Debe buscar el registro');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Archivo encontrado');", true);
                Response.Clear();
                Response.ContentType = "text/csv";

                Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", dp));

                Response.WriteFile("~/images/loaded_files/" + dp);


                Response.End();
            }
        }
    }
}