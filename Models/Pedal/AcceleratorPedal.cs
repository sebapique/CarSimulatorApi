namespace CarSimulator.Models
{
    public class AcceleratorPedal : Pedal
    {
        public AcceleratorPedal(Engine engine) : base(engine) {}

        public override int Press()
        {
            int increment = Engine.Type switch
            {
                CarType.Sport => 7,
                CarType.Truck => 4,
                _ => 5
            };
            return increment;
        }
    }
}
