using Day3.Data;

namespace Day3.Model;

public class MachineDataCalculator
{
    public int CalculateFrom(MachineData machineData)
    {
        int result = 0;
        foreach (Line line in machineData.Lines)
        {
            IEnumerable<Content> lineNumberContent = line.Content.Where(x => x.ContentType == ContentType.Number);
            HashSet<Address> supportingAddresses = GetAllSupportingAddresses(machineData, line);
            
            foreach (Content numberContent in lineNumberContent)
            {
                HashSet<Address> requestingAddressesForPartSymbol = numberContent.GetRequestingAddressesForPartSymbol();
                if (requestingAddressesForPartSymbol.Any(x=>supportingAddresses.Contains(x)))
                {
                    result += numberContent.ValueAsNumber.Value;
                }
            }
        }

        return result;
    }
    
    public double CalculatePart2(MachineData machineData)
    {
        double result = 0;
        foreach (Line line in machineData.Lines)
        {
            IEnumerable<Content> lineSymbolContent = line.Content.Where(x => x.ContentType == ContentType.Symbol);
            
            foreach (Content symbolContent in lineSymbolContent)
            {
                
                List<Content> allNumberContentsRequestingAddress = GetAllNumberContentsRequestingAddress(machineData, symbolContent.StartAddress);
                if (allNumberContentsRequestingAddress.Count == 2)
                {
                    result += allNumberContentsRequestingAddress[0].ValueAsNumber.Value *
                              allNumberContentsRequestingAddress[1].ValueAsNumber.Value;
                }
            }
        }

        return result;
    }

    private List<Content> GetAllNumberContentsRequestingAddress(MachineData machineData, Address startAddress)
    {
        List<Content> result = new();

        IEnumerable<Line> relevantLines = machineData.Lines.Where(x => x.LineNumber >= startAddress.LineNumber - 1 && x.LineNumber <= startAddress.LineNumber + 1);

        foreach (Line relevantLine in relevantLines)
        {
            foreach (Content content in relevantLine.Content.Where(x=>x.ContentType == ContentType.Number))
            {
                
                
                if(content.GetAdjacentAddresses().Contains(startAddress))
                    result.Add(content);
            }
        }

        return result;
    }
    
    private HashSet<Address> GetAllSupportingAddresses(MachineData machineData, Line line)
    {
        HashSet<Address> result = new();

        IEnumerable<Line> relevantLines = machineData.Lines.Where(x => x.LineNumber >= line.LineNumber - 1 && x.LineNumber <= line.LineNumber + 1);

        foreach (Line relevantLine in relevantLines)
        {
            foreach (Content content in relevantLine.Content)
            {
                foreach (Address supportingAddress in content.GetSupportingAddressesForPartSymbol())
                {
                    result.Add(supportingAddress);
                }
            }
        }

        return result;
    }
}