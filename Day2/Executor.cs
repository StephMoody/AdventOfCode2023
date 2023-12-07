using Day2.Data;
using Day2.Model;

namespace Day2;



public class Executor(GrabValidator grabValidator, GameDataProvider gameDataProvider)
{
    public void Execute()
    {
        Dictionary<string, int> determination = new()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        List<GameData> gameDataRecords = gameDataProvider.GetAllData();
        int sumOfAllIdsFittingForGrab = grabValidator.SumAllIdsFittingForGrab(determination, gameDataRecords);
        Console.WriteLine($"{sumOfAllIdsFittingForGrab}");

        double power = 0;
        foreach (GameData gameDataRecord in gameDataRecords)
        {
            power += gameDataRecord.GetPowerOfMinimumRequiredColors();
        }

        Console.WriteLine($"{power}");

    }
}