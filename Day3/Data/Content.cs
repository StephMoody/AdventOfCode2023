namespace Day3.Data;

public class Content
{
    private HashSet<Address>? _adjacentAddresses;
    
    public Content(ContentType contentType, Address startAddress, Address endAddress, int? valueAsNumber = null)
    {
        ContentType = contentType;
        StartAddress = startAddress;
        EndAddress = endAddress;
        ValueAsNumber = valueAsNumber;
    }

    public ContentType ContentType { get; }

    public Address StartAddress { get; }

    public int? ValueAsNumber { get; }

    public Address EndAddress { get; }

    public HashSet<Address> GetSupportingAddressesForPartSymbol()
    {
        if (ContentType != ContentType.Symbol)
            return new HashSet<Address>();

        return GetAdjacentAddresses();
    }

    public HashSet<Address> GetRequestingAddressesForPartSymbol()
    {
        if (ContentType != ContentType.Number)
            return new HashSet<Address>();

        var result = new HashSet<Address>();
        for (int positionIndex = StartAddress.Position; positionIndex <= EndAddress.Position; positionIndex++)
        {
            Address address = new(StartAddress.LineNumber, positionIndex);
            result.Add(address);
        }

        return result;
    }

    public HashSet<Address> GetAdjacentAddresses()
    {
        if (_adjacentAddresses != null)
            return _adjacentAddresses;
        
        HashSet<Address> result = new();
        for (int lineNumber = StartAddress.LineNumber - 1; lineNumber <= StartAddress.LineNumber + 1; lineNumber++)
        {
            for (int positionIndex = StartAddress.Position-1; positionIndex <= EndAddress.Position+1; positionIndex++)
            {
                Address address = new(lineNumber, positionIndex);
                result.Add(address);
            }

        }

        _adjacentAddresses = result;
        return _adjacentAddresses;
    }
}