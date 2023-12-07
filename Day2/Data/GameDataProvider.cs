using System.Text.RegularExpressions;
using Common;

namespace Day2.Data;

public class GameDataProvider(PuzzleInputReader puzzleInputReader)
{
    private readonly PuzzleInputReader _puzzleInputReader = puzzleInputReader;

    public List<GameData> GetAllData()
    {
        List<GameData> result = new();
        string[] inputLines = _puzzleInputReader.Read();
        foreach (string line in inputLines)
        {
            result.Add(Convert(line));
        }

        return result;
    }

    private GameData Convert(string input)
    {
        string[] split = input.Split(":");
        int id = GetGameId(split[0]);
        List<ColorGrab> grabs = GetGrabs(split[1]);

        return new GameData(id, grabs);

    }

    private int GetGameId(string input) => ParseNumber(input);

    private List<ColorGrab> GetGrabs(string input)
    {
        List<ColorGrab> result = new();
        foreach (string grab in input.Split(";"))
        {
            Dictionary<string, int> colorGrabs = new();
            foreach (string singleColor in grab.Split(","))
            {
                string color = ParseLetters(singleColor);
                int amountOfColors = ParseNumber(singleColor);
                colorGrabs[color] = amountOfColors;
            }
            
            result.Add(new ColorGrab(colorGrabs));
        }

        return result;
    }

    private string ParseLetters(string input)
    {
        return string.Join("", Regex.Matches(input, @"[a-z]"));
    }
    
    private int ParseNumber(string input)
    {
        string id = Regex.Matches(input, @"\d+").First().Value;
        return int.Parse(id);
    }
}