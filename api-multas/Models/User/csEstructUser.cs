using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_multas.Models.User
{
    public class csEstructUser
    {
        public class requestUser{
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string username { get; set; }
            public string password_hash { get; set; }
            public string role_user { get; set; }

        }

        public class responseUser
        {
            public int response { get; set; }
            public string message { get; set; }
            public string user_id { get; set; }
        }

        public class requestDeleteUser
        {
            public string user_id { get; set; }
    }
    }
}