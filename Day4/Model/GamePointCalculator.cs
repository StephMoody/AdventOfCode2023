using Day4.Data;

namespace Day4.Model;

public class GamePointCalculator
{
    public double Calculate(GameCards gameCards)
    {
        double result = 0;
        foreach (Card gameCardsCard in gameCards.Cards)
        {
            result += CalculatePoints(gameCardsCard);
        }

        return result;
    }

    public List<int> GetWinningMatches(Card card)
    {
        List<int> winningMatches = new List<int>();
        foreach (int gameNumber in card.GameNumbers)
        {
            if (card.WinningNumbers.Contains(gameNumber))
            {
                winningMatches.Add(gameNumber);
            }
        }

        return winningMatches;
    }

    private double CalculatePoints(Card gameCard)
    {
        double result = 0;

        List<int> winningMatches = GetWinningMatches(gameCard);
        if (!winningMatches.Any())
            return 0;

        result = 1;
        foreach (int unused in winningMatches.Skip(1))
        {
            result *= 2;
        }

        return result;
    }
}