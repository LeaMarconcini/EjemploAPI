using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ejemploApi.Model
{
    public class Car
    {

        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color{ get; set; }
        public int years { get; set; }
        public int doors { get; set; }
    }
}
