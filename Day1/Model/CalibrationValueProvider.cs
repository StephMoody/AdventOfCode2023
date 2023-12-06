using System.Diagnostics;
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
            string replacedRawCalibrationValue = ReplaceValues(rawCalibrationValue);
            int value = ParseValue(replacedRawCalibrationValue);
            Debug.WriteLine($"Raw {rawCalibrationValue}, replaced {replacedRawCalibrationValue} Value {value}" );
            result += value;
        }

        return result;
    }

    private string ReplaceValues(string rawCalibrationValue)
    {
        string intermediateString = string.Empty;
        
        foreach (char c in rawCalibrationValue)
        {
            intermediateString += c;
            foreach (KeyValuePair<string, string> keyValuePair in _valuesToReplace)
            {
                intermediateString = intermediateString.Replace(keyValuePair.Key, keyValuePair.Value);
            }
        }
        
        return intermediateString;
    }
    
    private int ParseValue(string input)
    {
        MatchCollection matches = Regex.Matches(input, @"[0-9]");
        if (matches.Count == 0)
            return 0;

        string firstValue = matches.First().Value;
        string lastValue = matches.Count == 1 ? firstValue : matches.Last().Value;
        
        int result = int.Parse($"{firstValue}{lastValue}");
        return result;
    }
    
    
}