using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList;
    
    public static bool LoadWordList (string wordFile)
    {
        try
        {
            wordList = File.ReadAllLines(@"Assets\Words\" + wordFile);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static string GetRandomWord ()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }

    public static bool IsReady ()
    {
        return wordList != null && wordList.Length > 0;
    }
}
