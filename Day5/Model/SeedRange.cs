namespace Day5.Model;

public record struct SeedRange
{
    public SeedRange(double start, double range)
    {
        Start = start;
        Range = range;
    }

    public double Start { get; }

    public double Range { get; }
}