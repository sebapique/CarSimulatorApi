using CarSimulator.Models;

namespace CarSimulator.Services
{
    public interface ICarService
    {
        string CurrentSessionId { get; set; }
        void AddCar(string sessionId);
        string selectCar(string sessionId);
        string GetCarType();
        void Accelerate();
        void Brake();
        void Steer(string direction, int degrees);
        int GetSpeed();
        int GetDirection();
        void FillWith(string fuelType);
        string Honk();
    }
}
