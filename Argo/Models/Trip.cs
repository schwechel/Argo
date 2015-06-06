using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Argo.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Type { get; set; }
        public string Event { get; set; }
        public int Busid { get; set; }
    }
}