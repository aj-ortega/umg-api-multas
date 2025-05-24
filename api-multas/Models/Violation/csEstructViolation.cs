using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static api_multas.Models.Driver.csEstructDriver;
using static api_multas.Models.Sanction.csEstructSanction;
using static api_multas.Models.TrafficOfficer.csEstructTrafficOfficer;
using static api_multas.Models.Vehicle.csEstructVehicle;

namespace api_multas.Models.Violation
{
    public class csEstructViolation
    {
        public class requestViolation
        {
            public string violation_id { get; set; }
            public DateTime violation_date { get; set; }
            public string status_infraction { get; set; }
            public requestVehicle vehicle { get; set; }
            public requestDriver driver { get; set; }
            public requestTrafficOfficer officer { get; set; }
            public requestSanction sanction { get; set; }
        }

        public class insertViolation
        {
            public string violation_id { get; set; }
            public DateTime violation_date { get; set; }
            public string status_infraction { get; set; }
            public string vehicle_id { get; set; }
            public string driver_id { get; set; }
            public string officer_id { get; set; }
            public requestSanction sanction { get; set; }
        }

        public class requestDeleteViolation
        {
            public string violation_id { get; set; }
        }

        public class responseViolation
        {
            public int response { get; set; }
            public string message { get; set; }
            public string violation_id { get; set; }
        }
    }
}