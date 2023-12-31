using System.Text.RegularExpressions;

namespace Common;

public static class ContentParser
{
    public static List<double> ParseAllDoubles(string content)
    {
        List<double> result = new List<double>();
        if (string.IsNullOrEmpty(content))
        {
            return result;
        }

        MatchCollection matchCollection = Regex.Matches(content, @"\d+");
        result.AddRange(matchCollection.Select(x=> double.Parse(x.Value)));
        return result;
    }
}