using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarsiteWebAPI.Models
{
    public partial class User
    {
        [Key]
        public int carsite_id { get; set; }
        public string auth0_id { get; set; }
        public string google_id { get; set; }
        public string facebook_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool? active { get; set; }
        public string created_at { get; set; }
        public string last_login { get; set; }
    }
}
