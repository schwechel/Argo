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
                int temp = NumberOfSeats - SeatsAvailable;
                while (temp%5 != 0)
                {
                    temp = temp - 1;
                }
                double pricePer = Price / temp;

                if(pricePer > 50)
                {
                    return 50;
                }
                else
                {
                    return Math.Round(pricePer, 2);
                }
            }
        }
    }
}