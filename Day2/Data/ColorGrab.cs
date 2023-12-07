namespace Day2.Data;

public class ColorGrab
{
    public ColorGrab(IReadOnlyDictionary<string, int> gameColors)
    {
        GameColors = gameColors;
    }

    public IReadOnlyDictionary<string, int> GameColors { get;}

}