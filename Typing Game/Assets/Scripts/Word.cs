using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    private WordDisplay display;

    public Word (string word, WordDisplay display)
    {
        this.word = word;
        this.display = display;

        typeIndex = 0;
        display.SetWord(word);
    }

    public char GetNextLetter ()
    {
        return word[typeIndex];
    }

    public void TypeLetter ()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool wordTyped ()
    {
        bool wordTyped = typeIndex >= word.Length;
        if (wordTyped)
            display.RemoveWord();

        return wordTyped;
    }

    public bool wordOutOfBounds ()
    {
        return display.transform.position.y <= -5f;
    }
}
