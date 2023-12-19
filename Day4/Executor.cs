

using Day4.Data;
using Day4.Model;

namespace Day4;



public class Executor(GamePointCalculator gamePointCalculator, CardReader cardReader, CardCounter cardCounter)
{

    private readonly GamePointCalculator _gamePointCalculator = gamePointCalculator;
    private readonly CardReader _cardReader = cardReader;
    private readonly CardCounter _cardCounter = cardCounter;
    
    public void Execute()
    {
        GameCards gameCards = _cardReader.ReadGameCards();
        double points = _gamePointCalculator.Calculate(gameCards);
        Console.WriteLine($"Result is {points}");
        Console.WriteLine($"Result is {_cardCounter.Count(gameCards)}");
    }
}