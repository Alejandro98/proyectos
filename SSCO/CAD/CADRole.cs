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
    public class CADRole
    {
        DTORole role = new DTORole();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveRole(DTORole role)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarRol";
            cmd.Parameters.AddWithValue("@cod_rol", role.Role_Code);
            cmd.Parameters.AddWithValue("@nom_rol", role.Role_Name);
            cmd.Parameters.AddWithValue("@desc_rol", role.Role_Description);
            try
            {
                if (verifyRole(role.Role_Code) == true)
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
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex.Message);
                con.Close();
                return 0;
            }
        }
        public string[] searchRole(int codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarRol";
            cmd.Parameters.AddWithValue("@cod_rol", codigo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string[] datos = new string[3];
            foreach (var item in dr)
            {
                datos[0] = dr["codigo_Rol"].ToString();
                datos[1] = dr["nombre_Rol"].ToString();
                datos[2] = dr["descripcion_Rol"].ToString();
            }
            con.Close();
            return datos;
        }
        public int modifyRole(DTORole role)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarRol";
            cmd.Parameters.AddWithValue("@cod_rol", role.Role_Code);
            cmd.Parameters.AddWithValue("@nom_rol", role.Role_Name);
            cmd.Parameters.AddWithValue("@desc_rol", role.Role_Description);

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
        public int deleteRole(DTORole role)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarRol";
            cmd.Parameters.AddWithValue("@cod_rol", role.Role_Code);

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
        public DataTable listRoles(DTORole rol)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarRoles";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }

        public Boolean verifyRole(int code)
        {
            int roleCode = 0;
            Boolean existe = false;

            SqlCommand cmdV = new SqlCommand();
            string cadV = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
            SqlConnection conV = new SqlConnection(cadV);

            cmdV.Connection = conV;
            cmdV.CommandType = CommandType.Text;
            cmdV.CommandText = "SELECT * FROM tbl_Rol WHERE codigo_Rol = '" + code + "'";
            conV.Open();
            SqlDataReader dr = cmdV.ExecuteReader();
            foreach (var item in dr)
            {
                roleCode = Int32.Parse(dr["codigo_Rol"].ToString());
            }
            if (roleCode != 0)
            {
                existe = true;
                conV.Close();
            }
            return existe;
        }
    }
}