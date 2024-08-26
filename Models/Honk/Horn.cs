using CarSimulator.Services;

public class Horn : IHonkDevice
{
    private readonly string Sound = "Beep!";
    public string Honk()
    {
        return Sound;
    }
}