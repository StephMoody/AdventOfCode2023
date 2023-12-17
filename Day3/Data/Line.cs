namespace Day3.Data;

public class Line
{
    public Line(List<Content> content, int lineNumber)
    {
        Content = content;
        LineNumber = lineNumber;
    }

    public List<Content> Content { get; }

    public int LineNumber { get; }
}