
using Common;
using Day3.Data;
using Day3.Model;

namespace Day3;



public class Executor(PuzzleInputReader puzzleInputReaders, MachineDataReader machineDataReader, MachineDataCalculator machineDataCalculator, Part2MachineDataReader part2MachineDataReader)
{
    private readonly PuzzleInputReader _puzzleInputReaders = puzzleInputReaders;
    private readonly MachineDataReader _machineDataReader = machineDataReader;
    private readonly MachineDataCalculator _machineDataCalculator = machineDataCalculator;
    private readonly Part2MachineDataReader _part2MachineDataReader = part2MachineDataReader;
    
    public void Execute()
    {
        string[] strings = _puzzleInputReaders.Read();
        MachineData machineData = _machineDataReader.ReadFrom(strings);
        int sum = _machineDataCalculator.CalculateFrom(machineData);

        MachineData part2MachineData = _part2MachineDataReader.ReadFrom(strings);
        double ratio = _machineDataCalculator.CalculatePart2(part2MachineData);

        Console.WriteLine(sum);
        Console.WriteLine(ratio);
    }
}