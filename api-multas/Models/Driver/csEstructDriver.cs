using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
   "driver_id": 1,
  "full_name": "Carlos García",
  "id_number": "ID987654321",
  "address": "Calle Ficticia 123, Ciudad X",
  "phone": "+1234567890",
  "license_number": "LIC12345XYZ",
  "registration_date": "2025-04-24T14:40:00"

*/


namespace api_multas.Models.Driver
{
    public class csEstructDriver
    {
        public class requestDriver
        {
            public string driver_id { get; set; }
            public string full_name { get; set; }
            public string id_number { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string license_number { get; set; }
            public DateTime registration_date { get; set; }
        }
        public class requestDeleteDriver
        {
            public string driver_id { get; set; }
        }
        public class responseDriver
        {
            public int response { get; set; }
            public string message { get; set; }
            public string driver_id { get; set; }
        }
    }
}