using Day4.Data;

namespace Day4.Model;

public class CardCounter
{

    private readonly GamePointCalculator _gamePointCalculator;

    public CardCounter(GamePointCalculator gamePointCalculator)
    {
        _gamePointCalculator = gamePointCalculator;
    }

    public int Count(GameCards gameCards)
    {
        Dictionary<int, int> cardCache = new Dictionary<int, int>();

        foreach (Card card in gameCards.Cards)
        {
            cardCache[card.CardNumber] =1;
        }
        
        foreach (Card gameCard in gameCards.Cards)
        {
            int amountOfIterations = cardCache[gameCard.CardNumber];
            for (int iteratingIndex = 0; iteratingIndex < amountOfIterations; iteratingIndex++)
            {
                var winningMatches = _gamePointCalculator.GetWinningMatches(gameCard);
                for (int i = 1; i <= winningMatches.Count; i++)
                {
                    int cachingCardNumber = gameCard.CardNumber+i;
                    if(!cardCache.ContainsKey(cachingCardNumber))
                        break;
                    
                    cardCache[cachingCardNumber]++;
                }
            }
        }

        int result = cardCache.Sum(x => x.Value);
        return result;
    }
    
    
}