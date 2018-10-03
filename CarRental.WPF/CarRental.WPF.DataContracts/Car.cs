using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WPF.DataContracts
{
    public enum CarClass { UnKnown, Economy, Premium, Business }
    public enum CarSize { UnKnown, Small, Medium, Large }

    public class Car
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CarClass Class { get; set; }
        public CarSize Size { get; set; }
        public int HourlyRate { get; set; }
    }
}
