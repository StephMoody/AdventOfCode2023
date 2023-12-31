using System.Text.RegularExpressions;
using Common;

namespace Day5.Model;

public class PuzzleInputDivider
{
    private readonly PuzzleInputReader _puzzleInputReader;

    public PuzzleInputDivider(PuzzleInputReader puzzleInputReader)
    {
        _puzzleInputReader = puzzleInputReader;
    }

    public Dictionary<string, string[]>  GetCategoryParts()
    {
        Dictionary<string, string[]> result = new();

        string[] input = _puzzleInputReader.Read();

        IEnumerable<string> inputWithoutInitialSeeds = input.Skip(2);

        List<string> currentCategory = new List<string>();
        string currentCategoryName = null;
        bool lastLineWasEmpty = true;
        foreach (string line in inputWithoutInitialSeeds)
        {
            if (string.IsNullOrEmpty(line))
            {
                result[currentCategoryName] = currentCategory.ToArray();
                currentCategory.Clear();
                lastLineWasEmpty = true;
                continue;
            }

            if (lastLineWasEmpty)
                currentCategoryName = line.Split(' ')[0];
            else
            {
                currentCategory.Add(line);
            }

            lastLineWasEmpty = false;
        }
        
        result[currentCategoryName] = currentCategory.ToArray();
        return result;
    }

    public List<double> GetInitialSeed()
    {
        string[] input = _puzzleInputReader.Read();

        string firstLine = input[0];
        string numbers = firstLine.Split(":")[1];
        return ContentParser.ParseAllDoubles(numbers);

    }
    
    public List<SeedRange> GetInitialSeedWithRange()
    {
        List<SeedRange> result = new List<SeedRange>();
        
        string[] input = _puzzleInputReader.Read();

        string firstLine = input[0];
        string numbers = firstLine.Split(":")[1];
        List<double> seedRanges = ContentParser.ParseAllDoubles(numbers);

        for (int i = 0; i < seedRanges.Count; i++)
        {
            if (i % 2 > 0)
                continue;

            double start = seedRanges[i];
            double range = seedRanges[i + 1];

            result.Add(new SeedRange(start, range));
        }

        return result.ToList();
    }
}