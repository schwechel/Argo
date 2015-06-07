using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Argo.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public int NumberOfSeats {get;set;}
        public double Price { get; set; }
        public int SeatsAvailable { get; set; }
        public double PricePerSeat
        {
            get
            {
                double price = Price / (NumberOfSeats - SeatsAvailable);
                if(price > 50)
                {
                    return 50;
                }
                else
                {
                    return Price / (NumberOfSeats - SeatsAvailable);
                }
            }
        }
    }
}