namespace Day5.Model;

public class CategoryMapping
{
    public int Index { get; init; }
    
    public string Name { get;init; }

    public List<MappedRange> Mappings { get; init; } 
}