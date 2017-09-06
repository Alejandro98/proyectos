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
    public class CADSession
    {
        DTOSession session = new DTOSession();        
        static string cad = ConfigurationManager.ConnectionStrings["conSQL"].ConnectionString;
        SqlConnection con = new SqlConnection(cad);
        SqlCommand cmd = new SqlCommand();

        public int login(DTOSession session){
            long us = 0;
            string cl = "";
            int validationValue = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbl_Sesion";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var item in dr)
            {
                us = Int64.Parse(dr["usuario"].ToString());
                cl = dr["clave"].ToString();
            }
            if (session.User != us)
            {
                validationValue = 1;
            }
            else if (!session.Password.Equals(cl))
            {
                validationValue = 2;
            }         
            else if (session.User == us && session.Password.Equals(cl))
            {
                validationValue = 3;
                con.Close();
            }
            con.Close();
            return validationValue;
        }
    }
}
