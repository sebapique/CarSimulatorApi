namespace CarSimulator.Models
{
    public class Tank
    {
        public FuelType FuelType { get; private set; }

        public Tank(FuelType fuelType)
        {
            FuelType = fuelType;
        }

         public void Refuel(FuelType fuelType)
        {
            FuelType = fuelType;
        }
    }
}
