namespace CarSimulator.Models
{
    public class BrakePedal(Engine engine) : Pedal(engine)
    {
        public override int Press()
        {
            int decrement = Engine.Type switch
            {
                CarType.Truck => 6,
                _ => 10
            };

            return decrement;
        }
    }
}
