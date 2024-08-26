namespace CarSimulator.Models
{
    public class SteeringWheel
    {
        public int Direction { get; private set; }
        private List<Wheel> Wheels;

        public SteeringWheel() {
            Wheels = new List<Wheel>();
            CreateWheels();
            Direction = 0;
        }

        public void Steer(string direction, int degrees)
        {
            
            if (direction.ToLower() == "left")
            {
                Direction = (Direction - degrees + 360) % 360;
            }
            else if (direction.ToLower() == "right")
            {
                Direction = (Direction + degrees) % 360;
            }
            moveWheels();
        }
        private void CreateWheels()
        {
            int numberOfWheels = 4;
            for (int i = 0; i < numberOfWheels; i++)
            {
                bool locked = (i == 0 || i == 2);
                Wheels.Add(new Wheel(locked));
            }
        }

        private void moveWheels() {
            foreach (Wheel wheel in Wheels)
            {
                if (!wheel.Locked) {
                    wheel.Steer(Direction);
                }
            }
        }
    }
}
