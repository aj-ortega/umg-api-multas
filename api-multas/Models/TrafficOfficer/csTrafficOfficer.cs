using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.TrafficOfficer.csEstructTrafficOfficer;

namespace api_multas.Models.TrafficOfficer
{
    public class csTrafficOfficer
    {
        public responseTrafficOfficer insertTrafficOfficer(string full_name, string id_number, string rank_level)
        {
            responseTrafficOfficer result = new responseTrafficOfficer();
            string conection = "";
            SqlConnection con = null;
            string id_pseudo = Guid.NewGuid().ToString("N");

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "INSERT INTO Traffic_Officer (officer_id, full_name, id_number, rank_level) VALUES " +
                    "('" + id_pseudo + "', '" + full_name + "', '" + id_number + "', '" + rank_level + "')";
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.officer_id = id_pseudo;
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

        public responseTrafficOfficer updateTrafficOfficer(string officer_id, string full_name, string id_number, string rank_level)
        {
            responseTrafficOfficer result = new responseTrafficOfficer();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "update Traffic_Officer set full_name = '" + full_name + "', id_number = '" + id_number + "', rank_level = '" + rank_level + "' where officer_id = " + officer_id;
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

        public responseTrafficOfficer deleteTrafficOfficer(string officer_id)
        {
            responseTrafficOfficer result = new responseTrafficOfficer();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "delete from Traffic_Officer where officer_id = " + officer_id;
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

        public DataSet getTrafficOfficers()
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Traffic_Officer";
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

        public DataSet getTrafficOfficerById(string officer_id)
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Traffic_Officer where officer_id = " + officer_id;
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