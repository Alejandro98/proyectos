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
    public class CADMember
    {
        DTOMember member = new DTOMember();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveMember(DTOMember member)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_AsignarMiembro";
            cmd.Parameters.AddWithValue("@cedula", member.Member_Doc);
            cmd.Parameters.AddWithValue("@cod_grupo", member.Member_Group);
            cmd.Parameters.AddWithValue("@alias", member.Member_Nick);
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
        public string[] searchMember(int codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarMiembro";
            cmd.Parameters.AddWithValue("@cedula", codigo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] datos = new string[3];
            foreach (var item in dr)
            {
                datos[0] = dr["documento_Usuario"].ToString();
                datos[1] = dr["codigo_Grupo"].ToString();
                datos[2] = dr["alias_Miembro"].ToString();
            }
            con.Close();
            return datos;
        }
        public int modifyMember(DTOMember member)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarMiembro";
            cmd.Parameters.AddWithValue("@cedula", member.Member_Doc);
            cmd.Parameters.AddWithValue("@cod_grupo", member.Member_Group);
            cmd.Parameters.AddWithValue("@alias", member.Member_Nick);

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
        public int deleteMember(DTOMember member)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarMiembro";
            cmd.Parameters.AddWithValue("@cedula", member.Member_Doc);

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
        public DataTable listMembers(DTOMember member)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarMiembros";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }
    }
}
