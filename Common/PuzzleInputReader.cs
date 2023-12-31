using System.Reflection;

namespace Common;

public class PuzzleInputReader
{

    private string[]? _content;
    
    public string[] Read()
    {
        if (_content != null)
        {
            return _content;
        }
        
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        string? directoryName = Path.GetDirectoryName(executingAssembly.Location);
        if (directoryName == null)
        {
            return new string[]{};
        }
        string pathToFile = Path.Combine(directoryName,  "PuzzleInput.txt");
        _content = File.ReadAllLines(pathToFile);
        return _content;
    }
}