using System.Reflection;
using System.Resources;

namespace Day1.Model;

public class CalibrationInputReader
{
    public string[] Read()
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        string? directoryName = Path.GetDirectoryName(executingAssembly.Location);
        if (directoryName == null)
        {
            return new string[]{};
        }
        string pathToFile = Path.Combine(directoryName,  "CalibrationValue.txt");
        return File.ReadAllLines(pathToFile);
    }
}