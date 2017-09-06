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
    public class CADUser
    {
        DTOUser user = new DTOUser();
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int saveUser(DTOUser user)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_GuardarUsuario";
            cmd.Parameters.AddWithValue("@cedula", user.User_Doc);
            cmd.Parameters.AddWithValue("@nombre", user.User_Name);
            cmd.Parameters.AddWithValue("@apellidos", user.User_Lastname);
            cmd.Parameters.AddWithValue("@correo", user.User_Email);
            cmd.Parameters.AddWithValue("@celular", user.User_Cellphone);
            cmd.Parameters.AddWithValue("@profesion", user.User_Profession);
            cmd.Parameters.AddWithValue("@rol", user.User_Role);

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
        public DTOUser searchUser(DTOUser user)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_BuscarUsuario";
            cmd.Parameters.AddWithValue("@cedula", user.User_Doc);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.User_Name = Convert.ToString(dr[0]);
                user.User_Lastname = Convert.ToString(dr[1]);
                user.User_Email = Convert.ToString(dr[2]);
                user.User_Cellphone = Convert.ToString(dr[3]);
                user.User_Profession = Convert.ToString(dr[4]);
                user.User_Role = Convert.ToString(dr[5]);
            }
            con.Close();
            return user;
        }
        public int modifyUser(DTOUser user)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ModificarUsuario";
            cmd.Parameters.AddWithValue("@cedula", user.User_Doc);
            cmd.Parameters.AddWithValue("@nombre", user.User_Name);
            cmd.Parameters.AddWithValue("@apellidos", user.User_Lastname);
            cmd.Parameters.AddWithValue("@correo", user.User_Email);
            cmd.Parameters.AddWithValue("@celular", user.User_Cellphone);
            cmd.Parameters.AddWithValue("@profesion", user.User_Profession);
            cmd.Parameters.AddWithValue("@rol", user.User_Role);

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
        public int deleteUser(DTOUser user)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_EliminarUsuario";
            cmd.Parameters.AddWithValue("@cedula", user.User_Doc);

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
        public DataTable listUsers(DTOUser user)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prc_ListarUsuarios";
            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            sda.Fill(data);
            con.Close();
            return data;
        }
        public DataTable listProfessions()
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

        public DataTable listRoles()
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
        public bool verifyUser(DTOUser user)
        {
            SqlCommand cmdV = new SqlCommand("");
            string cadV = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
            SqlConnection conV = new SqlConnection(cadV);

            cmdV.Connection = conV;
            cmdV.CommandType = CommandType.Text;
            cmdV.CommandText = "SELECT COUNT(*) FROM tbl_Usuario WHERE cedula_Usuario = '" + user.User_Doc + "'";
            conV.Open();
            int count = Convert.ToInt32(cmdV.ExecuteScalar());
            if (count == 0)
            {
                return false;
            }
            con.Close();
            return true;
        }
        public bool verifyUserEmail(DTOUser user)
        {
            SqlCommand cmdVE = new SqlCommand("");
            string cadVE = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
            SqlConnection conVE = new SqlConnection(cadVE);

            cmdVE.Connection = conVE;
            cmdVE.CommandType = CommandType.Text;
            cmdVE.CommandText = "SELECT COUNT(*) FROM tbl_Usuario WHERE correo_Usuario = '" + user.User_Email + "'";
            conVE.Open();
            int count = Convert.ToInt32(cmdVE.ExecuteScalar());
            if (count == 0)
            {
                return false;
            }
            con.Close();
            return true;
        }
    }
}
