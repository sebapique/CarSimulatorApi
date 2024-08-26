using System;
using CarSimulator.Services;

namespace CarSimulator.Models
{
    public class Car
    {
        public int Speed { get; private set; }
        public CarType Type { get; private set; }
        private Body Body;
        private Tank Tank;
        private Engine Engine;
        private AcceleratorPedal AcceleratorPedal;
        private BrakePedal BrakePedal;
        private SteeringWheel SteeringWheel;
        private IHonkDevice HonkDevice;
        private static readonly CarType[] CarTypes = (CarType[]) Enum.GetValues(typeof(CarType));
    
        public Car()
        {
            Type = genterateType();
            Tank = new Tank(FuelType.Regular);
            Body = new Body(Type);
            Engine = new Engine(Type);
            AcceleratorPedal = new AcceleratorPedal(Engine);
            BrakePedal = new BrakePedal(Engine);
            SteeringWheel = new SteeringWheel();
            HonkDevice = CreateHonkDevice();
            
        }

        public int GetDirection() {
            return SteeringWheel.Direction;
        }

        public void Accelerate()
        {
            int increment = 0;
            if (Tank.FuelType == FuelType.Premium && Body.Type != CarType.Truck)
            {
                increment += 1;
            }
            increment += AcceleratorPedal.Press();
            Speed = Speed + increment;
        }

        public void Brake()
        {
            int decrement = BrakePedal.Press();
            Speed = Math.Max(Speed - decrement, 0);
        }

        public void Steer(string direction, int degrees)
        {
           SteeringWheel.Steer(direction, degrees);
        }

        public void FillWith(FuelType fuelType)
        {
            Tank.Refuel(fuelType);
        }

        public string Honk()
        {
            return HonkDevice.Honk();
        }

        private IHonkDevice CreateHonkDevice() 
        {
            if (Body.Type.ToString() == "truck") {
                return new Trumpet();
            } else {
                Random random = new Random();
                return random.Next(10) < 9 ? (IHonkDevice)new Horn() : (IHonkDevice)new Trumpet();
            }
        }

        private CarType genterateType() {
            Random random = new Random();
            return CarTypes[random.Next(CarTypes.Length)];
        }
    }
}