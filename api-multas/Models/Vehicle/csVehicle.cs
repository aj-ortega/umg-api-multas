using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.User.csEstructUser;
using static api_multas.Models.Vehicle.csEstructVehicle;

namespace api_multas.Models.Vehicle
{
    public class csVehicle
    {
        public responseVehicle insertVehicle(string license_plate, string brand, string model, string color, string vehicle_type)
        {
            responseVehicle result = new responseVehicle();
            string conection = "";
            SqlConnection con = null;
            string id_pseudo = Guid.NewGuid().ToString("N");

            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);

                con.Open();

                string cadena = "INSERT INTO Vehicle (vehicle_id, license_plate, brand, model, color, vehicle_type) VALUES " +
                    "( '" + id_pseudo + "', '" + license_plate + "', '" + brand + "', '" + model + "', '" + color + "', '" + vehicle_type + "')";
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.vehicle_id = id_pseudo;
                result.message = "Vehicule inserted successfully";
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
        public responseVehicle updateVehicle(string vehicle_id, string plate_number, string brand, string model, string color, string vehicle_type)
        {
            responseVehicle result = new responseVehicle();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "update Vehicle set plate_number = '" + plate_number + "', brand = '" + brand + "', model = '" + model + "', color = '" + color + "', vehicle_type = '" + vehicle_type + "' where vehicle_id = " + vehicle_id;
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.message = "Vehicule updated successfully";
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
        public responseVehicle deleteVehicle(string vehicle_id)
        {
            responseVehicle result = new responseVehicle();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "delete from Vehicle where vehicle_id = " + vehicle_id;
                SqlCommand cmd = new SqlCommand(cadena, con);
                result.response = cmd.ExecuteNonQuery();
                result.message = "Vehicule deleted successfully";
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
        public DataSet getVehicles()
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Vehicle";
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
        public DataSet getVehicleById(string vehicle_id)
        {
            DataSet ds = new DataSet();
            string conection = "";
            SqlConnection con = null;
            try
            {
                conection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(conection);
                con.Open();
                string cadena = "select * from Vehicle where vehicle_id = " + vehicle_id;
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