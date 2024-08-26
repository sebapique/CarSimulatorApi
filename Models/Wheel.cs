// This Class is not used for the challenge
namespace CarSimulator.Models
{
    public class Wheel
    {
        public int Pressure { get; private set; }
        public int Direction { get; private set; }
        public bool Locked { get; private set; }
        public Wheel(bool locked) {
            Locked = locked;
            Direction = 0;
        }

        public void Steer(int direction) {
            if (Locked) {
                return;
            }
            Direction = direction; 
        }
    }
}
