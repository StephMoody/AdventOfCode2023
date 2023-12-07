using Day2.Data;

namespace Day2.Model;

public class GrabValidator
{
    public int SumAllIdsFittingForGrab(Dictionary<string, int> determinations, IEnumerable<GameData> gameDataRecords)
    {
        int result = 0;
        foreach (GameData gameData in gameDataRecords)
        {

            if (DeterminationFitsToGame(determinations, gameData))
                result += gameData.Id;
        }

        return result;
    }

    private bool DeterminationFitsToGame(Dictionary<string, int> determinations, GameData gameData)
    {
        foreach (KeyValuePair<string,int> determination in determinations)
        {
            foreach (ColorGrab gameDataGrab in gameData.Grabs)
            {
                if (gameDataGrab.GameColors.TryGetValue(determination.Key, out int amount) && amount > determination.Value)
                {
                    return false;
                }
            }
        }
        
        return true;
    }

}