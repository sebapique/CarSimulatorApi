using CarSimulator.Services;
namespace CarSimulator.Models
{
    public class Engine
    {
        public CarType Type { get; private set; }

        public Engine(CarType type) {
            Type = type;
        }
    }
}
