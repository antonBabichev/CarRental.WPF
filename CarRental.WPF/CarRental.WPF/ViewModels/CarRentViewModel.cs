using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.WPF.DataContracts;
using CarRental.WPF.Repository.Interfaces;
using CarRental.WPF.Commands;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CarRental.WPF.ViewModels
{
    [Export(typeof(ICarRentalViewModel))]
    public class CarRentViewModel : ICarRentalViewModel
    {
        private ICarRepository carRepo;
        private CarProposedReservation proposedReservation;
        public event PropertyChangedEventHandler PropertyChanged;

        [ImportingConstructor]
        public CarRentViewModel(ICarRepository carRepo)
        {
            this.carRepo = carRepo;

            if (this.carRepo == null)
                throw new InvalidOperationException("Failed to inject car repository!");

            BookCommand = new RelayCommand<string>(BookCar, CanBookCar);
            SeeRatesCommand = new RelayCommand<string>(SeeRates, CanSeeRates);

            Cars = new ObservableCollection<Car>();

            ProposedViewModel = new CarProposedReservationViewModel();
        }

        private void SeeRates(string s)
        {
            Cars.Clear();
            foreach (var car in carRepo.GetAvailableCars(ProposedViewModel.CreateProposedReservation()))
            {
                Cars.Add(car);
            }
        }

        private bool CanSeeRates(string s)
        {
            return carRepo != null;
        }

        private void ShowDialog(string message, bool isError = false)
        {
            MessageBox.Show(message, isError ? "Error" : "Success", MessageBoxButton.OK, isError ? MessageBoxImage.Error : MessageBoxImage.Information);
        }

        private void BookCar(string s)
        {
            bool isBooked = false;
            if (carRepo != null)
                isBooked = carRepo.BookACar(CreateReservation());
            if (isBooked)
            {
                ShowDialog("Your car was successfully booked!");
                Cars.Remove(SelectedCar);
            }
            else
                ShowDialog("There was an error processing request!", true);
        }

        private bool CanBookCar(string s)
        {
            return carRepo != null;
        }

        private CarReservation CreateReservation()
        {
            var carR = new CarReservation();
            carR.Car = SelectedCar;
            carR.Pickup = ProposedViewModel.PickupLocation;
            carR.Destination = ProposedViewModel.DropoffLocation;
            carR.From = ProposedViewModel.PickupDay;
            carR.To = ProposedViewModel.DropoffDay;
            return carR;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand BookCommand { get; private set; }
        public ICommand SeeRatesCommand { get; private set; }
        public ICommand ShowDialogCommand { get; private set; }
        public ObservableCollection<Car> Cars { get; private set; }
        public Car SelectedCar { get; set; }

        public CarProposedReservationViewModel ProposedViewModel
        {
            get; private set;
        }
    }
}
