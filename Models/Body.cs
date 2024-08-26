namespace CarSimulator.Models
{
    public class Body
    {
        public CarType Type { get; private set; }
        public CarColor Color { get; private set; }
        private static readonly CarColor[] CarColors = (CarColor[]) Enum.GetValues(typeof(CarColor));
        public Body(CarType type) {
            Random random = new();
            Type = type;
            Color = CarColors[random.Next(CarColors.Length)];
        }
    }
}
