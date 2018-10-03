using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WPF.DataContracts;

namespace CarRental.WPF.Repository.Interfaces
{
    public interface ICarRepository
    {
        List<Car> GetAvailableCars(CarProposedReservation proposedReservation);
        List<Car> GetBookedCars();
        bool BookACar(CarReservation reservation);
    }
}
