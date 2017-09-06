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
    public class CADProfession
    {
        DTOProfession profession = new DTOProfession();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveProfession(DTOProfession profession)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarProfesion";
            cmd.Parameters.AddWithValue("@cod_prof", profession.Profession_Code);
            cmd.Parameters.AddWithValue("@nom_prof", profession.Profession_Name);
            cmd.Parameters.AddWithValue("@desc_prof", profession.Profession_Description);
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
        public string[] searchProfession(int codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarProfesion";
            cmd.Parameters.AddWithValue("@cod_prof", codigo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] datos = new string[3];
            foreach (var item in dr)
            {
                datos[0] = dr["codigo_Profesion"].ToString();
                datos[1] = dr["nombre_Profesion"].ToString();
                datos[2] = dr["descripcion_Profesion"].ToString();
            }
            con.Close();
            return datos;
        }
        public int modifyProfession(DTOProfession profession)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarProfesion";
            cmd.Parameters.AddWithValue("@cod_prof", profession.Profession_Code);
            cmd.Parameters.AddWithValue("@nom_prof", profession.Profession_Name);
            cmd.Parameters.AddWithValue("@desc_prof", profession.Profession_Description);

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
        public int deleteProfession(DTOProfession profession)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarProfesion";
            cmd.Parameters.AddWithValue("@cod_prof", profession.Profession_Code);

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
        public DataTable listProfessions(DTOProfession profession)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarProfesiones";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }
        public int undoProfession()
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_DeshacerProfesion";

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
    }
}
