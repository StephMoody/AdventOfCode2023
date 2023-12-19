using System.Text.RegularExpressions;
using Common;
using Day4.Data;

namespace Day4.Model;

public class CardReader
{
    private readonly PuzzleInputReader _puzzleInputReader;

    public CardReader(PuzzleInputReader puzzleInputReader)
    {
        _puzzleInputReader = puzzleInputReader;
    }

    public GameCards ReadGameCards()
    {
        string[] inputLines = _puzzleInputReader.Read();


        List<Card> cards = new List<Card>();
        int cardNumber = 1;
        foreach (string inputLine in inputLines)
        {
            string gameInput = inputLine.Split(':')[1];

            string[] splittedGameInput = gameInput.Split('|');

            MatchCollection winningNumbersMatches = Regex.Matches(splittedGameInput[0], @"\d+");
            MatchCollection gameNumbersMatches = Regex.Matches(splittedGameInput[1], @"\d+");

            HashSet<int> winningNumbers = new HashSet<int>();
            HashSet<int> gameNumbers = new HashSet<int>();

            foreach (Match winningNumbersMatch in winningNumbersMatches)
            {
                winningNumbers.Add(int.Parse(winningNumbersMatch.Value));
            }
            
            foreach (Match gameNumbersMatch in gameNumbersMatches)
            {
                gameNumbers.Add(int.Parse(gameNumbersMatch.Value));
            }
            
            cards.Add(new Card(gameNumbers, winningNumbers, cardNumber));
            cardNumber++;

        }

        return new GameCards(cards);
    }
}