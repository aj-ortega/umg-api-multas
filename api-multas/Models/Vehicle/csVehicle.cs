using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_multas.Models.Driver.csEstructDriver;
using static api_multas.Models.Sanction.csEstructSanction;
using static api_multas.Models.TrafficOfficer.csEstructTrafficOfficer;
using static api_multas.Models.User.csEstructUser;
using static api_multas.Models.Vehicle.csEstructVehicle;
using static api_multas.Models.Violation.csEstructViolation;

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
                string cadena = "update Vehicle set plate_number = '" + plate_number + "', brand = '" + brand + "', model = '" + model + "', color = '" + color + "', vehicle_type = '" + vehicle_type + "' where vehicle_id = " + "'" + vehicle_id + "'";
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
                string cadena = "delete from Vehicle where vehicle_id = " + "'" + vehicle_id + "'";
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
                string cadena = "select * from Vehicle where vehicle_id = " + "'" + vehicle_id + "'";
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

        public List<requestViolation> getViolationsByVehicleId(string vehicleId)
        {
            List<requestViolation> violations = new List<requestViolation>();
            string connection = "";
            SqlConnection con = null;

            try
            {
                connection = ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                con = new SqlConnection(connection);
                con.Open();

                string query = @"
            SELECT 
                v.violation_id, v.violation_date, v.status_infraction,
                ve.vehicle_id, ve.license_plate, ve.brand, ve.model, ve.color, ve.vehicle_type,
                d.driver_id, d.full_name AS driver_name, d.id_number AS driver_id_number, d.address AS driver_address, d.phone AS driver_phone, d.license_number, d.registration_date,
                s.sanction_id, s.description, s.sanction_type, s.cost, s.created_at AS sanction_created_at,
                o.officer_id, o.full_name AS officer_name, o.id_number AS officer_id_number, o.rank_level, o.created_at AS officer_created_at
            FROM Violation v
            INNER JOIN Vehicle ve ON ve.vehicle_id = v.vehicle_id
            INNER JOIN Driver d ON d.driver_id = v.driver_id
            INNER JOIN Sanction s ON s.sanction_id = v.sanction_id
            INNER JOIN Traffic_Officer o ON o.officer_id = v.officer_id
            WHERE ve.vehicle_id = @vehicleId
        ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@vehicleId", vehicleId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        requestViolation v = new requestViolation
                        {
                            violation_id = row["violation_id"].ToString(),
                            violation_date = Convert.ToDateTime(row["violation_date"]),
                            status_infraction = row["status_infraction"].ToString(),

                            vehicle = new requestVehicle
                            {
                                vehicle_id = row["vehicle_id"].ToString(),
                                license_plate = row["license_plate"].ToString(),
                                brand = row["brand"].ToString(),
                                model = row["model"].ToString(),
                                color = row["color"].ToString(),
                                vehicle_type = row["vehicle_type"].ToString()
                            },

                            driver = new requestDriver
                            {
                                driver_id = row["driver_id"].ToString(),
                                full_name = row["driver_name"].ToString(),
                                id_number = row["driver_id_number"].ToString(),
                                address = row["driver_address"].ToString(),
                                phone = row["driver_phone"].ToString(),
                                license_number = row["license_number"].ToString(),
                                registration_date = Convert.ToDateTime(row["registration_date"])
                            },

                            sanction = new requestSanction
                            {
                                sanction_id = row["sanction_id"].ToString(),
                                description = row["description"].ToString(),
                                sanction_type = row["sanction_type"].ToString(),
                                cost = Convert.ToDecimal(row["cost"]),
                                created_at = Convert.ToDateTime(row["sanction_created_at"])
                            },

                            officer = new requestTrafficOfficer
                            {
                                officer_id = row["officer_id"].ToString(),
                                full_name = row["officer_name"].ToString(),
                                id_number = row["officer_id_number"].ToString(),
                                rank_level = row["rank_level"].ToString(),
                                created_at = Convert.ToDateTime(row["officer_created_at"])
                            }
                        };

                        violations.Add(v);
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error con log o devolver una lista vacía
                return null;
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return violations;
        }

    }
}