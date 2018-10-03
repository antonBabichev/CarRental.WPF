using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WPF.DataContracts;
using CarRental.WPF.Repository.Interfaces;

namespace CarRental.Wpf.DataModel.Implementations.Mock
{
    [Export(typeof(ICarRepository))]
    public class MockCarRepository : ICarRepository
    {
        private Dictionary<string, List<Car>> carsStorage = new Dictionary<string, List<Car>>();
        private Dictionary<int, Tuple<DateTime, DateTime>> bookedCars = new Dictionary<int, Tuple<DateTime, DateTime>>();
        private List<CarReservation> reservedCars = new List<CarReservation>();
        public MockCarRepository()
        {
            var bostonCars = new List<Car>();
            var car1 = new Car { Id=1, Class = CarClass.Economy, Size = CarSize.Small, HourlyRate=30, Description = "Chevy Cruz or similar" };
            var car2 = new Car { Id=2, Class = CarClass.Economy, Size = CarSize.Small, HourlyRate = 30, Description = "VW Beatle or similar" };
            bostonCars.Add(car1);
            bostonCars.Add(car2);
            carsStorage["boston"] = bostonCars;
        }

        public bool BookACar(CarReservation reservation)
        {
            if (reservedCars.FirstOrDefault(c => (c.Car.Id == reservation.Car.Id && ((reservation.From >= c.From && reservation.From <= c.To)
                                                     || (reservation.To <= c.To && reservation.To >= c.From)))) != null)
                return false;

            reservedCars.Add(reservation);
            return true;
        }

        public List<Car> GetAvailableCars(CarProposedReservation proposedReservation)
        {
            var cars = new List<Car>();
            var availableCars = new List<Car>();

            if (proposedReservation.PickupLocation == null)
                return availableCars;

            if (carsStorage.ContainsKey(proposedReservation.PickupLocation.ToLower()))
                cars = carsStorage[proposedReservation.PickupLocation];

            if(cars.Count > 0)
            {
                foreach(var car in cars)
                {
                    if(reservedCars.FirstOrDefault(c => ((proposedReservation.From >= c.From && proposedReservation.From <= c.To) 
                                                    || (proposedReservation.To <= c.To && proposedReservation.To >= c.From))) == null)

                    {
                        availableCars.Add(car);
                    }
                }
            }

            return availableCars;
        }

        public List<Car> GetBookedCars()
        {
            return null;
        }
    }
}
