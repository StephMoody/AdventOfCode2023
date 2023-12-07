namespace Day2.Data;

public class GameData(int id, IEnumerable<ColorGrab> grabs)
{
    public int Id { get; } = id;

    public IEnumerable<ColorGrab> Grabs { get; } = grabs;

    public double GetPowerOfMinimumRequiredColors()
    {
        int maxRed = GetMaxValue("red");
        int maxGreen = GetMaxValue("green");
        int maxBlue = GetMaxValue("blue");
        
        int result = Math.Max(1, maxRed) * Math.Max(1, maxGreen) * Math.Max(1, maxBlue);

        return result;
    }   

    private int GetMaxValue(string color)
    {
        int result = 1;
        foreach (ColorGrab colorGrab in Grabs)
        {
            if (colorGrab.GameColors.TryGetValue(color, out int amount))
            {
                result = Math.Max(amount, result);
            }
        }

        return result;
    }
}



