using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsiteWebAPI.Models
{
    public class Fillup
    {
        public int id { get; set; }
        public int odometer { get; set; }
        public decimal price { get; set; }
        public decimal volume { get; set; }
        public decimal cost { get; set; }
        public char partial { get; set; }
        public char missed { get; set; }
        public string vehicle { get; set; }
        public string date { get; set; }
        public string payment_type { get; set; }
        public string fuel_type { get; set; }
        public string fuel_grade { get; set; }
        public string station_name { get; set; }
        public string station_address { get; set; }
        public string note { get; set; }
    }
}
