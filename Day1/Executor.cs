using Day1.Model;

namespace Day1;

public class Executor
{
    private readonly CalibrationInputReader _calibrationInputReader;
    private readonly CalibrationValueProvider _calibrationValueProvider;
    
    public Executor(CalibrationInputReader calibrationInputReader, CalibrationValueProvider calibrationValueProvider)
    {
        _calibrationInputReader = calibrationInputReader;
        _calibrationValueProvider = calibrationValueProvider;
    }

    public void Execute()
    {
        string[] rawCalibrationValues = _calibrationInputReader.Read();
        int sum = _calibrationValueProvider.Process(rawCalibrationValues);
        Console.WriteLine($"The result is {sum}");
    }
}