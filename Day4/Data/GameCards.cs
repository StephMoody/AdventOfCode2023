using System.Text.RegularExpressions;

namespace Day4.Data;

public class GameCards
{
    public GameCards(List<Card> cards)
    {
        Cards = cards;
    }

    public List<Card> Cards { get; }
}

public class Card
{
    public Card(HashSet<int> gameNumbers, HashSet<int> winningNumbers, int cardNumber)
    {
        GameNumbers = gameNumbers;
        WinningNumbers = winningNumbers;
        CardNumber = cardNumber;
    }

    public HashSet<int> GameNumbers { get; }
    public HashSet<int> WinningNumbers { get; }

    public int CardNumber { get; }
}





