using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;
    
    private Word activeWord;
    private int typedLetterCount;
    private int validTypedLetterCount;

    void Start ()
    {
        GameDataManager.AccuracyDecimalPercentage = 1f;
        WordGenerator.LoadWordList(GameDataManager.WordsFile);
        typedLetterCount = 0;
        validTypedLetterCount = 0;
    }

    public void AddWord ()
    {
        if (WordGenerator.IsReady())
        {
            Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
            words.Add(word);
        }
    }

    public void TypeLetter (char letter)
    {
        if (activeWord != null)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
                increaseTypedLetterCount(true);
            }
            else
                increaseTypedLetterCount(false);
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    word.TypeLetter();
                    break;
                }
            }
            if (activeWord == null)
                increaseTypedLetterCount(false);
            else
                increaseTypedLetterCount(true);
        }

        if (activeWord != null && activeWord.wordTyped())
        {
            words.Remove(activeWord);
            activeWord = null;
            increaseAndUpdateScore();
        }

        updateAccuracy();
    }

    private void increaseTypedLetterCount (bool valid)
    {
        typedLetterCount++;
        if (valid)
            validTypedLetterCount++;
    }

    private void updateAccuracy ()
    {
        if (typedLetterCount > 0)
            GameDataManager.AccuracyDecimalPercentage = (float)validTypedLetterCount / (float)typedLetterCount;
    }

    private void increaseAndUpdateScore (int increaseBy = 1)
    {
        GameDataManager.Score += increaseBy;
    }

    void Update ()
    {
        foreach (Word word in words)
        {
            if (word.wordOutOfBounds())
                SceneManager.LoadScene("Outro");
        }
    }
}
