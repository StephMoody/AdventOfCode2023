namespace Day5.Model;

public class LowestLocationCalculator
{
    private readonly CategoryReader _categoryReader;
    private readonly PuzzleInputDivider _puzzleInputDivider;

    public LowestLocationCalculator(CategoryReader categoryReader, PuzzleInputDivider puzzleInputDivider)
    {
        _categoryReader = categoryReader;
        _puzzleInputDivider = puzzleInputDivider;
    }

    public double CalculateLowestCalculation()
    {
        List<CategoryMapping> categoryMappings = _categoryReader.Read();
        List<SeedRange> initialSeedRanges = _puzzleInputDivider.GetInitialSeedWithRange();

        double currentLowestCalculation = double.MaxValue;
        
        foreach (SeedRange seedRange in initialSeedRanges)
        {
            Console.WriteLine($"Calculate seed {initialSeedRanges.IndexOf(seedRange)+1} from {initialSeedRanges.Count}");

            for (int i = 0; i < seedRange.Range; i++)
            {
                // Console.WriteLine($"Calculate seed {i +1} from {seedRange.Range}");
                currentLowestCalculation = double.Min(currentLowestCalculation, CalculateLowest(seedRange.Start+i, categoryMappings));
            }
        }
        
        return currentLowestCalculation;
    }

    private double CalculateLowest(double seed, List<CategoryMapping> categoryMappings)
    {
        IOrderedEnumerable<CategoryMapping> orderedCategoryMappings = categoryMappings.OrderBy(x=>x.Index);

        double currentMappedValue = seed;
        foreach (CategoryMapping categoryMapping in orderedCategoryMappings)
        {
            // Console.WriteLine($"In {categoryMapping.Name} {currentMappedValue}");

            MappedRange? mappedRange = categoryMapping.Mappings.FirstOrDefault(x=>x.CoversValue(currentMappedValue));
            if (mappedRange != null)
                currentMappedValue = mappedRange.GetMappedValue(currentMappedValue);

            // Console.WriteLine($"Out {categoryMapping.Name} {currentMappedValue}");
            // Console.WriteLine();
        }
        
        return currentMappedValue;
    }
}