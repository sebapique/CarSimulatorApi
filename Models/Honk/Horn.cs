using CarSimulator.Services;

public class Horn : IHonkDevice
{
    private string Sound = "Beep!";
    public string Honk()
    {
        return Sound;
    }
}