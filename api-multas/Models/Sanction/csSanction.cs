using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.Sanction.csEstructSanction;

namespace api_multas.Models.Sanction
{
    public class csSanction
    {
        public responseSanction insertSanction(string description, string sanction_type, decimal cost)
        {
            responseSanction result = new responseSanction();
            string conection = "";
            SqlConnection con = null;
            string id_pseudo = Guid.NewGuid().ToString("N");

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "INSERT INTO Sanction (sanction_id, description, sanction_type, cost) VALUES " +
                    "( '" + id_pseudo + "', '" + description + "', '" + sanction_type + "', " + cost + ")";
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.sanction_id = id_pseudo;
                result.message = "User inserted successfully";
            }
            catch (Exception ex)
            {
                result.response = 0;
                result.message = "Error: " + ex.Message;
                return result;
            }
            con.Close();
            return result;
        }

        public responseSanction updateSanction(string sanction_id, string description, string sanction_type, decimal cost)
        {
                    responseSanction result = new responseSanction();
                    string conection = "";
                    SqlConnection con = null;
                    try
                    {
                        conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                        con = new SqlConnection(conection);
                        con.Open();
                        string cadena = "update Sanction set description = '" + description + "', sanction_type = '" + sanction_type + "', cost = " + cost + " where sanction_id = " + sanction_id;
                        SqlCommand cmd = new SqlCommand(cadena, con);
                        result.response = cmd.ExecuteNonQuery();
                        result.message = "User updated successfully";
                    }
                    catch (Exception ex)
                    {
                        result.response = 0;
                        result.message = "Error: " + ex.Message;
                        return result;
                    }
                    con.Close();
                    return result;
        }

        public responseSanction deleteSanction(string sanction_id)
        {
            responseSanction result = new responseSanction();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "delete from Sanction where sanction_id = " + sanction_id;
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.message = "User deleted successfully";
            }
            catch (Exception ex)
            {
                result.response = 0;
                result.message = "Error: " + ex.Message;
                return result;
            }
            con.Close();
            return result;
        }

        public DataSet getSanctions()
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Sanction";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                return null;
            }
            con.Close();
            return ds;
        }

        public DataSet getSanctionById(string id) {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Sanction where sanction_id = " + id;
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                return null;
            }
            con.Close();
            return ds;
        }
    }
}