using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.User.csEstructUser;

namespace api_multas.Models.User
{
    public class csUser
    {
        public responseUser insertUser(string full_name, string username, string password_hash, string role_user)
        {

            responseUser result = new responseUser();
            string conection = "";
            SqlConnection con = null;
            string id_pseudo = Guid.NewGuid().ToString("N");

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "INSERT INTO users (user_id, full_name, username, password_hash, role_user) VALUES " +
                    "( '" + id_pseudo + "', '" + full_name + "', '" + username + "', '" + password_hash + "', '" + role_user + "')";
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
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

        public responseUser updateUser(int user_id, string full_name, string username, string password_hash, string role_user)
        {

            responseUser result = new responseUser();
            string conection = "";
            SqlConnection con = null;

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "update users set full_name = '" + full_name + "', username = '" + username + "', password_hash = '" + password_hash + "', role_user = '" + role_user + "' where user_id = " + user_id;
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
        public responseUser deleteUser(string user_id)
        {
            responseUser result = new responseUser();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "delete from users where user_id = " + user_id;
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

        public DataSet getUsers()
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from users";
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

        public DataSet getUserById(string user_id)
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from users where user_id = " + user_id;
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