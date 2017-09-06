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
    public class CADTask
    {
        DTOTask task = new DTOTask();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveTask(DTOTask task)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarTarea";
            cmd.Parameters.AddWithValue("@cod_tarea", task.Task_Code);
            cmd.Parameters.AddWithValue("@desc_tarea", task.Task_Description);
            cmd.Parameters.AddWithValue("@dur_aproximada", task.Task_Duration);
            cmd.Parameters.AddWithValue("@fecha", task.Task_Date);
            cmd.Parameters.AddWithValue("@nom_archivo", task.Task_FileName);

            try
            {
                if (verifyTask(task.Task_Code) == true)
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
        public string[] searchTask(int code)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarTarea";
            cmd.Parameters.AddWithValue("@cod_tarea", code);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] data = new string[5];
            foreach (var item in dr)
            {
                data[0] = dr["codigo_Tarea"].ToString();
                data[1] = dr["descripcion_Tarea"].ToString();
                data[2] = dr["duracion_Aproximada"].ToString();
                data[3] = dr["fecha_Entrega"].ToString();
                data[4] = dr["nombre_Archivo"].ToString();
            }

            con.Close();
            return data;
        }
        public int modifyTask(DTOTask task)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarTarea";
            cmd.Parameters.AddWithValue("@cod_tarea", task.Task_Code);
            cmd.Parameters.AddWithValue("@desc_tarea", task.Task_Description);
            cmd.Parameters.AddWithValue("@dur_aproximada", task.Task_Duration);
            cmd.Parameters.AddWithValue("@fecha", task.Task_Date);
            cmd.Parameters.AddWithValue("@nom_archivo", task.Task_FileName);

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
        public int deleteTask(DTOTask task)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarTarea";
            cmd.Parameters.AddWithValue("@cod_tarea", task.Task_Code);

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
        public DataTable listTasks(DTOTask task)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarTareas";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }

        public Boolean verifyTask(int code)
        {
            int taskCode = 0;
            Boolean existe = false;

            SqlCommand cmdV = new SqlCommand();
            string cadV = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
            SqlConnection conV = new SqlConnection(cadV);

            cmdV.Connection = conV;
            cmdV.CommandType = CommandType.Text;
            cmdV.CommandText = "SELECT * FROM tbl_Tarea WHERE codigo_Tarea = '" + code + "'";
            conV.Open();
            SqlDataReader dr = cmdV.ExecuteReader();
            foreach (var item in dr)
            {
                taskCode = Int32.Parse(dr["codigo_Tarea"].ToString());
            }
            if (taskCode != 0)
            {
                existe = true;
                conV.Close();
            }
            return existe;
        }
    }
}
