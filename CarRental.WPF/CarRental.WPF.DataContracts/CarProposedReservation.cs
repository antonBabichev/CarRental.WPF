using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WPF.DataContracts
{
    public class CarProposedReservation
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string PickupLocation { get; set; }
    }
}
