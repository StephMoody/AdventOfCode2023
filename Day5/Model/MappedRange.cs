namespace Day5.Model;

public class MappedRange
{
    public double From { get; init; }

    public double To { get;  init;}

    public double Difference { get; init; }

    public bool CoversValue(double input)
    {
        return input >= From && input <= To;
    }
    
    public double GetMappedValue(double input)
    {
        if (!CoversValue(input))
            return input;

        return input - Difference;
    }
}