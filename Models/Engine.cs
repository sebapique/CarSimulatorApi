using CarSimulator.Services;
namespace CarSimulator.Models
{
    public class Engine(CarType type)
    {
        public CarType Type { get; private set; } = type;
    }
}
