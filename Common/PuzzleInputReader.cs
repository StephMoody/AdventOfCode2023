using System.Reflection;

namespace Common;

public class PuzzleInputReader
{
    public string[] Read()
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        string? directoryName = Path.GetDirectoryName(executingAssembly.Location);
        if (directoryName == null)
        {
            return new string[]{};
        }
        string pathToFile = Path.Combine(directoryName,  "PuzzleInput.txt");
        return File.ReadAllLines(pathToFile);
    }
}