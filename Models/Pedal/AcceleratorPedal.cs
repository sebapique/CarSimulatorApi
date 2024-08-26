namespace CarSimulator.Models
{
    public class AcceleratorPedal(Engine engine) : Pedal(engine)
    {
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
