namespace Day3.Data;

public class MachineData
{
    public MachineData(List<Line> lines)
    {
        Lines = lines;
    }

    public List<Line> Lines { get; }
}