using Common;
using Day1.Model;

namespace Day1;

public class Executor
{
    private readonly PuzzleInputReader _puzzleInputReader;
    private readonly CalibrationValueProvider _calibrationValueProvider;
    
    public Executor(PuzzleInputReader puzzleInputReader, CalibrationValueProvider calibrationValueProvider)
    {
        _puzzleInputReader = puzzleInputReader;
        _calibrationValueProvider = calibrationValueProvider;
    }

    public void Execute()
    {
        string[] rawCalibrationValues = _puzzleInputReader.Read();
        int sum = _calibrationValueProvider.Process(rawCalibrationValues);
        Console.WriteLine($"The result is {sum}");
    }
}