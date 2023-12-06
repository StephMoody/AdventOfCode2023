using System.Text.RegularExpressions;

namespace Day1.Model;

public class CalibrationValueProvider
{
    private readonly IReadOnlyDictionary<string, string> _valuesToReplace = new Dictionary<string, string>()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
    };
    
    public int Process(string[] rawCalibrationValues)
    {
        int result = 0;
        foreach (string rawCalibrationValue in rawCalibrationValues)
        {
            string firstValue = GetFirstValue(rawCalibrationValue);
            string lastValue = GetLastValue(rawCalibrationValue);
            
            result += int.Parse($"{firstValue}{lastValue}");
        }

        return result;
    }

    private string GetFirstValue(string rawCalibrationValue)
    {
        string intermediateString = string.Empty;
        
        foreach (char c in rawCalibrationValue)
        {
            intermediateString += c;
            if (TryGetValue(intermediateString, out string value)) 
                return value;
        }

        throw new InvalidOperationException($"Found no value in {rawCalibrationValue}");
    }

    private bool TryGetValue(string intermediateString, out string value)
    {
        value = string.Empty;
        foreach (KeyValuePair<string, string> keyValuePair in _valuesToReplace)
        {
            intermediateString = intermediateString.Replace(keyValuePair.Key, keyValuePair.Value);
        }
            
        MatchCollection matches = Regex.Matches(intermediateString, @"[0-9]");
        if (!matches.Any())
            return false;

        value = matches.First().Value;
        return true;
    }

    private string GetLastValue(string rawCalibrationValue)
    {
        string intermediateString = string.Empty;

        for (int i = rawCalibrationValue.Length - 1; i >= 0; i--)
        {
            intermediateString = rawCalibrationValue[i] + intermediateString;
            if (TryGetValue(intermediateString, out string value)) 
                return value;
        }
        
        throw new InvalidOperationException($"Found no value in {rawCalibrationValue}");
    }
}