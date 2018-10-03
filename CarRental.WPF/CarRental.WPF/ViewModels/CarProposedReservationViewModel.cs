using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WPF.DataContracts;

namespace CarRental.WPF.ViewModels
{
    public class CarProposedReservationViewModel : INotifyPropertyChanged 
    {
        private string pickupLocation;
        public string PickupLocation
        {
            get
            {
                return pickupLocation;
            }
            set
            {
                this.pickupLocation = value;
                NotifyPropertyChanged("PickupLocation");
            }
        }

        private string dropoffLocation;
        public string DropoffLocation
        {
            get
            {
                return dropoffLocation;
            }
            set
            {
                this.dropoffLocation = value;
                NotifyPropertyChanged("DropoffLocation");
            }
        }

        private DateTime pickupDay = DateTime.Now;
        public DateTime PickupDay
        {
            get
            {
                return pickupDay;
            }
            set
            {
                this.pickupDay = value;
                NotifyPropertyChanged("PickupDay");
            }
        }
        private DateTime dropoffDay = DateTime.Now;
        public DateTime DropoffDay
        {
            get
            {
                return dropoffDay;
            }
            set
            {
                this.dropoffDay = value;
                NotifyPropertyChanged("DropoffDay");
            }
        }
        public string PickupTime { get; set; }
        public string DropoffTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CarProposedReservation CreateProposedReservation()
        {
            var proposed = new CarProposedReservation();

            proposed.From = PickupDay;
            proposed.To = DropoffDay;
            proposed.PickupLocation = PickupLocation;

            return proposed;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
