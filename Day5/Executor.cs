
using Day5.Model;

namespace Day5;

public class Executor
{
    private readonly LowestLocationCalculator _lowestLocationCalculator;

    public Executor(LowestLocationCalculator lowestLocationCalculator)
    {
        _lowestLocationCalculator = lowestLocationCalculator;
    }

    public void Execute()
    {
        double calculateLowestCalculation = _lowestLocationCalculator.CalculateLowestCalculation();
        Console.WriteLine($"{calculateLowestCalculation}");
    }
}