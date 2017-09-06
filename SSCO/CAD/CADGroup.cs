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
    public class CADGroup
    {
        DTOGroup group = new DTOGroup();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveGroup(DTOGroup group)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarGrupo";
            cmd.Parameters.AddWithValue("@cod_grupo", group.Group_Code);
            cmd.Parameters.AddWithValue("@nom_grupo", group.Group_Name);
            cmd.Parameters.AddWithValue("@fra_grupo", group.Group_Phrase);
            cmd.Parameters.AddWithValue("@fas_des_grupo", group.Group_Development_Fase);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex.Message);
                con.Close();
                return 0;
            }
        }
        public string[] searchGroup(int codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarGrupo";
            cmd.Parameters.AddWithValue("@cod_grupo", codigo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] datos = new string[4];
            foreach (var item in dr)
            {
                datos[0] = dr["codigo_Grupo"].ToString();
                datos[1] = dr["nombre_Grupo"].ToString();
                datos[2] = dr["frase_Grupo"].ToString();
                datos[3] = dr["fase_Desarrollo_Grupo"].ToString();
            }
            con.Close();
            return datos;
        }
        public int modifyGroup(DTOGroup group)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarGrupo";
            cmd.Parameters.AddWithValue("@cod_grupo", group.Group_Code);
            cmd.Parameters.AddWithValue("@nom_grupo", group.Group_Name);
            cmd.Parameters.AddWithValue("@fra_grupo", group.Group_Phrase);
            cmd.Parameters.AddWithValue("@fas_des_grupo", group.Group_Development_Fase);

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
        public int deleteGroup(DTOGroup group)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarGrupo";
            cmd.Parameters.AddWithValue("@cod_prof", group.Group_Code);

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
        public DataTable listGroups(DTOGroup group)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarGrupos";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }
    }
}
