using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace CAD
{
    public class CADProject
    {
        DTOProject project = new DTOProject();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveProject(DTOProject project)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarProyecto";
            cmd.Parameters.AddWithValue("@cod_proyecto", project.Project_Code);
            cmd.Parameters.AddWithValue("@nom_proyecto", project.Project_Name);
            cmd.Parameters.AddWithValue("@desc_proyecto", project.Project_Description);

            try
            {
                if (verifyProject(project.Project_Code) == true)
                {
                    return 3;
                }
                else
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                con.Close();
                return 0;
            }
        }
        public string[] searchProject(long codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarProyecto";
            cmd.Parameters.AddWithValue("@cod_proyecto", codigo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] datos = new string[3];
            foreach (var item in dr)
            {
                datos[0] = dr["codigo_Proyecto"].ToString();
                datos[1] = dr["nombre_Proyecto"].ToString();
                datos[2] = dr["descripcion_Proyecto"].ToString();
            }
            con.Close();
            return datos;
        }
        public int modifyProject(DTOProject project)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarProyecto";
            cmd.Parameters.AddWithValue("@cod_proyecto", project.Project_Code);
            cmd.Parameters.AddWithValue("@nom_proyecto", project.Project_Name);
            cmd.Parameters.AddWithValue("@desc_proyecto", project.Project_Description);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                con.Close();
                return 0;
            }
        }
        public int deleteProject(DTOProject project)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarProyecto";
            cmd.Parameters.AddWithValue("@cod_proyecto", project.Project_Code);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                con.Close();
                return 0;
            }
        }
        public DataTable listProjects(DTOProject project)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarProyectos";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }

        public Boolean verifyProject(long code)
        {
            long projectCode = 0;
            Boolean existe = false;

            SqlCommand cmdV = new SqlCommand();
            string cadV = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
            SqlConnection conV = new SqlConnection(cadV);

            cmdV.Connection = conV;
            cmdV.CommandType = CommandType.Text;
            cmdV.CommandText = "SELECT * FROM tbl_Proyecto WHERE codigo_Proyecto = '" + code + "'";
            conV.Open();
            SqlDataReader dr = cmdV.ExecuteReader();
            foreach (var item in dr)
            {
                projectCode = Int32.Parse(dr["codigo_Proyecto"].ToString());
            }
            if (projectCode != 0)
            {
                existe = true;
                conV.Close();
            }
            return existe;
        }
    }
}
