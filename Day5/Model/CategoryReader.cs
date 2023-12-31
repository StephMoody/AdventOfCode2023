using Common;

namespace Day5.Model;

public class CategoryReader
{
    private readonly PuzzleInputDivider _puzzleInputDivider;

    public CategoryReader(PuzzleInputDivider puzzleInputDivider)
    {
        _puzzleInputDivider = puzzleInputDivider;
    }

    public List<CategoryMapping> Read()
    {
        List<CategoryMapping> result = new();

        Dictionary<string, string[]> categoryParts = _puzzleInputDivider.GetCategoryParts();

        int currentFrom = 1;
        foreach ((string categoryName, string[] categoryContent) in categoryParts)
        {
            result.Add(new CategoryMapping()
            {
                Index = currentFrom,
                Name = categoryName,
                Mappings = GetMappings(categoryContent)
            });

            currentFrom++;
        }

        return result;
    }

    private List<MappedRange> GetMappings(string[] categoryContent)
    {
        List<MappedRange> mappings = new();
        foreach (string content in categoryContent)
        {
            List<double> values = ContentParser.ParseAllDoubles(content);

            double source = values[1];
            double destination = values[0];
            double range = values[2];

            double difference = Math.Abs(source - destination);

            if (destination > source)
                difference = difference * -1;

            MappedRange mapping = new MappedRange()
            {
                From = source,
                To = source + (range -1),
                Difference = difference
            };
                
            mappings.Add(mapping);
        }

        return mappings;
    }
}