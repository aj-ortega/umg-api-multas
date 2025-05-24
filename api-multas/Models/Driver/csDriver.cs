using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.Driver.csEstructDriver;
using static api_multas.Models.User.csEstructUser;

namespace api_multas.Models.Driver
{
    public class csDriver
    {
        public responseDriver insertDriver(string full_name, string id_number, string address, string phone, string license_number)
        {
            responseDriver result = new responseDriver();
            string conection = "";
            SqlConnection con = null;
            string id_pseudo = Guid.NewGuid().ToString("N");

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "INSERT INTO Driver (driver_id, full_name, id_number, address, phone, license_number) VALUES " +
                    "( '" + id_pseudo + "', '" + full_name + "', '" + id_number + "', '" + address + "', '" + phone +"', '" + license_number + "')";
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.driver_id = id_pseudo;
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
        public responseDriver updateDriver(string driver_id, string full_name, string address, string phone, string id_number, string license_number)
        {
            responseDriver result = new responseDriver();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "update Driver set full_name = '" + full_name + "', id_number = '" + id_number + "', license_number = '" + license_number + "' where driver_id = " + driver_id;
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
        public responseDriver deleteDriver(string driver_id)
        {
            responseDriver result = new responseDriver();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "delete from Driver where driver_id = " + "'" + driver_id + "'";
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
        public DataSet getDrivers()
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Driver";
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
        public DataSet getDriverById(string driver_id)
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Driver where driver_id = " + "'" + driver_id + "'";
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

        internal object getAllViolations(string driver_id)
        {
            throw new NotImplementedException();
        }
    }
}