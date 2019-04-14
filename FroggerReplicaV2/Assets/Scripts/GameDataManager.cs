using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static int carSize = 2;
    public static int frogSize = 2;
    public static int initialCarSpawnSpeed = 2;
    public static int initialCarSpeed = 2;
    public static bool musicEnabled = true;

    public static List<KeyValuePair<string, int>> highScores;

    public static string currentPlayerName;

    public static string highScoresFilePath = "frogGamePlusHighScores.txt";
    public static string optionsFilePath = "frogGamePlusOptions.txt";

    public static void LoadGameOptions()
    {
        string[] gameOptionsData;
        if (File.Exists(optionsFilePath))
        {
            gameOptionsData = File.ReadAllLines(optionsFilePath);

            foreach (string line in gameOptionsData)
            {
                string[] optionsDataEntry;
                if (line.Contains(","))
                {
                    optionsDataEntry = line.Trim().Split(',');

                    switch (optionsDataEntry[0])
                    {
                        case "carSize":
                            carSize = int.Parse(optionsDataEntry[1]);
                            break;
                        case "frogSize":
                            frogSize = int.Parse(optionsDataEntry[1]);
                            break;
                        case "initialCarSpawnSpeed":
                            initialCarSpawnSpeed = int.Parse(optionsDataEntry[1]);
                            break;
                        case "initialCarSpeed":
                            initialCarSpeed = int.Parse(optionsDataEntry[1]);
                            break;
                        case "musicEnabled":
                            musicEnabled = bool.Parse(optionsDataEntry[1]);
                            break;
                    }
                }
            }
        }
    }

    public static void LoadHighScores()
    {
        highScores = new List<KeyValuePair<string, int>>();
        string[] highScoresData;
        if (File.Exists(highScoresFilePath))
        {
            highScoresData = File.ReadAllLines(highScoresFilePath);
            highScores.Clear();

            foreach (string line in highScoresData)
            {
                string[] highScoresDataEntry;
                if (line.Contains(","))
                {
                    highScoresDataEntry = line.Trim().Split(',');

                    highScores.Add(new KeyValuePair<string, int>(highScoresDataEntry[0], int.Parse(highScoresDataEntry[1])));
                }
            }

            SortHighScores();
        }
    }

    public static void SaveGameOptions()
    {
        string[] gameOptionsData = {
            "carSize," + carSize,
            "frogSize," + frogSize,
            "initialCarSpawnSpeed," + initialCarSpawnSpeed,
            "initialCarSpeed," + initialCarSpeed,
            "musicEnabled," + musicEnabled,
        };

        File.WriteAllLines(optionsFilePath, gameOptionsData);
    }

    public static void SaveHighScores()
    {
        List<string> highScoresDataList = new List<string>();

        SortHighScores();

        foreach (KeyValuePair<string, int> highScore in highScores)
        {
            highScoresDataList.Add(highScore.Key + ',' + highScore.Value);
        }

        File.WriteAllLines(highScoresFilePath, highScoresDataList.ToArray());
    }

    public static void SortHighScores()
    {
        // Sort high scores by comparing their values - highest first
        highScores.Sort((x, y) => y.Value.CompareTo(x.Value));
    }
}
