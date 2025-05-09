using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
{
  "sanction_id": 1,
  "description": "Exceso de velocidad en zona escolar",
  "sanction_type": "Multa",
  "cost": 150.00,
  "created_at": "2025-04-24T14:35:00"
}
*/
namespace api_multas.Models.Sanction
{
    public class csEstructSanction
    {
        public class requestSanction
        {
            public string sanction_id { get; set; }
            public string description { get; set; }
            public string sanction_type { get; set; }
            public decimal cost { get; set; }
            public DateTime created_at { get; set; }
        }
        public class requestDeleteSanction
        {
            public string sanction_id { get; set; }
        }
        public class responseSanction
        {
            public int response { get; set; }
            public string message { get; set; }
            public string sanction_id { get; set; }
        }
    }
}