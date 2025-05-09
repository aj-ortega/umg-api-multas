using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_multas.Models.TrafficOfficer
{
    public class csEstructTrafficOfficer
    {
        public class requestTrafficOfficer
        {
            public string officer_id { get; set; }
            public string full_name { get; set; }
            public string id_number { get; set; }
            public string rank_level { get; set; }
            public DateTime created_at { get; set; }
        }
        public class requestDeleteTrafficOfficer
        {
            public string officer_id { get; set; }
        }
        public class responseTrafficOfficer
        {
            public int response { get; set; }
            public string message { get; set; }
            public string officer_id { get; set; }
        }
       
    }
}