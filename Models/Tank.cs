namespace CarSimulator.Models
{
    public class Tank(FuelType fuelType)
    {
        public FuelType FuelType { get; private set; } = fuelType;

        public void Refuel(FuelType fuelType)
        {
            FuelType = fuelType;
        }
    }
}
