using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 "vehicle_id": 1,
  "license_plate": "ABC1234",
  "brand": "Toyota",
  "model": "Corolla",
  "color": "Rojo",
  "vehicle_type": "Sedán",
  "registration_date": "2025-04-24T14:45:00" 
 */

namespace api_multas.Models.Vehicle
{
    public class csEstructVehicle
    {
        public class requestVehicle
        {
            public string vehicle_id { get; set; }
            public string license_plate { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public string vehicle_type { get; set; }
        }
        public class requestDeleteVehicle
        {
            public string vehicle_id { get; set; }
        }
        public class responseVehicle
        {
            public int response { get; set; }
            public string message { get; set; }

            public string vehicle_id { get; set; }
        }

    }
}