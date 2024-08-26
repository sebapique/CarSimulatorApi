using CarSimulator.Models;
using System.Collections.Generic;

namespace CarSimulator.Services
{
    public class CarService : ICarService
    {
        public string CurrentSessionId { get; set; }

        private readonly Dictionary<string, Car> _sessionCars;

        public CarService()
        {
            CurrentSessionId = string.Empty;
            _sessionCars =  new Dictionary<string, Car>();
        }

        public void AddCar(string sessionId)
        {
            _sessionCars[sessionId] = new Car();
            CurrentSessionId = sessionId;
        }

        public string selectCar(string sessionId)
        {
            if (_sessionCars.ContainsKey(sessionId)) {
                CurrentSessionId = sessionId;
            }
            return CurrentSessionId;
        }

        private Car GetCar(string sessionId)
        {
            if (sessionId != string.Empty && _sessionCars.ContainsKey(sessionId))
            {
                return _sessionCars[sessionId];
            }
            throw new InvalidOperationException("sessionId invalid or not setted.");
        }

        public string GetCarType()
        {
            if (CurrentSessionId == null) {
                return "There is not a car in the session";
            }
            var car = GetCar(CurrentSessionId);
            return car.Type.ToString();
        }

        public void Accelerate()
        {
            var car = GetCar(CurrentSessionId);
            car.Accelerate();
        }

        public void Brake()
        {
            if (CurrentSessionId == null) {
                return;
            }

            var car = GetCar(CurrentSessionId);
            car.Brake();
        }

        public void Steer(string direction, int degrees)
        {
            if (CurrentSessionId == null) {
                return;
            }

            var car = GetCar(CurrentSessionId);
            car.Steer(direction, degrees);
        }

        public int GetSpeed()
        {
            if (CurrentSessionId == null) {
                return 0;
            }

            var car = GetCar(CurrentSessionId);
            return car.Speed;
        }

        public int GetDirection()
        {
            if (CurrentSessionId == null) {
                return 0;
            }

            var car = GetCar(CurrentSessionId);
            return car.GetDirection();
        }

        public void FillWith(string fuelType)
        {
            if (CurrentSessionId == null) {
                return;
            }

            var car = GetCar(CurrentSessionId);
            FuelType fuel = Enum.Parse<FuelType>(fuelType, true);
            car.FillWith(fuel);
        }

        public string Honk()
        {
            var car = GetCar(CurrentSessionId);
            return car.Honk();
        }
    }
}
