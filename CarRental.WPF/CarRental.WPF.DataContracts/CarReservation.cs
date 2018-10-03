using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WPF.DataContracts
{
    public class CarReservation
    {
        public Car Car { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
    }
}
