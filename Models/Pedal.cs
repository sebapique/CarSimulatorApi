namespace CarSimulator.Models
{
    public abstract class Pedal(Engine engine)
    {
        protected  Engine Engine = engine;

        public abstract int Press();
    }
}
