using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWeb.Models
{
    public class LoginModel
    {
        public string in_date { get; set; }
        public string interface_id { get; set; }
        public string user_phone { get; set; }
        public string pass { get; set; }
        public string device_type { get; set; }
        public string device_token { get; set; }
    }
}