using CarSimulator.Services;
public class Trumpet : IHonkDevice
{
    private readonly string Sound = "Da-da-da-da-daah!";
    public string Honk()
    {
        return Sound;
    }
}