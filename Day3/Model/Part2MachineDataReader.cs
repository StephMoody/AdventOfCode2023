using System.Text.RegularExpressions;
using Day3.Data;

namespace Day3.Model;

public class Part2MachineDataReader
{
    private const char DOT = '.';
    private const char STAR = '*';
    
    public MachineData ReadFrom(string[] lines)
    {
        List<Line> machineDataLines = new List<Line>();

        int lineNumber = 1;
        foreach (string line in lines)
        {
            machineDataLines.Add(ReadFrom(line, lineNumber));
            lineNumber++;
        }


        return new MachineData(machineDataLines);

    }

    private Line ReadFrom(string line, int lineNumber)
    {
        List<Content> content = new List<Content>();

        string? currentNumberContent = null;
        Address? currentContentStartAddress = null;

        int position = 1;
        foreach (char character in line)
        {
            try
            {
                string charAsString = character.ToString();
                if (Regex.IsMatch(charAsString, @"\d+"))
                {
                    currentNumberContent += charAsString;
                    currentContentStartAddress ??= new Address(lineNumber, position);
                }
                else
                {
                    if (currentNumberContent != null)
                    {
                        content.Add(new Content(ContentType.Number, currentContentStartAddress.Value , new Address(lineNumber, position-1), int.Parse(currentNumberContent)));
                        currentNumberContent = null;
                        currentContentStartAddress = null;
                    }
                    
                    if(character == STAR)
                        content.Add(new Content(ContentType.Symbol, new Address(lineNumber, position) , new Address(lineNumber, position)));
                }
            }
            finally
            {
                position++;
            }
        }
        
        if(currentNumberContent != null)
            content.Add(new Content(ContentType.Number, currentContentStartAddress.Value , new Address(lineNumber, position), int.Parse(currentNumberContent)));
        
        return new Line(content, lineNumber);
    }
}