using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.WPF.DataContracts;

namespace CarRental.WPF.ViewModels
{
    public interface ICarRentalViewModel
    {
        ICommand BookCommand { get; }
        ICommand SeeRatesCommand { get; }
        ObservableCollection<Car> Cars { get; }
        CarProposedReservationViewModel ProposedViewModel { get; }
        Car SelectedCar { get; set; }
    }
}
