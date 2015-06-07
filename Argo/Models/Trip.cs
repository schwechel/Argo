using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Argo.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        [DisplayName("Depart Time")]
        public DateTime DepartTime { get; set; }
        [DisplayName("Return Time")]
        public DateTime ReturnTime { get; set; }
        public int Type { get; set; }
        public string Event { get; set; }
        [DisplayName("Event Description")]
        public string EventDescription { get; set; }
        [DisplayName("Is Private")]
        public bool IsPrivate { get; set; }
        public int Busid { get; set; }
        public Bus Bus { get; set; }
        public String TypeDisplay
        {
            get
            {
                if (Type == 1)
                {
                    return "Round Trip";
                }
                else
                {
                    return "One Way";
                }
            }
        }
    }
}