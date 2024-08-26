namespace CarSimulator.Models
{
    public abstract class Pedal
    {
        protected  Engine Engine;
        public Pedal(Engine engine)
        {
            Engine = engine;
        }
        public abstract int Press();
    }
}
