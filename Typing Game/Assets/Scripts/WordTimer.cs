using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {
    public WordManager wordManager;

    public float WordDelay { get; set; }
    private float initialWordDelay = 1.5f;
    private float nextWordTime = 0f;

    void Start ()
    {
        WordDelay = initialWordDelay;
    }

    void Update ()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + WordDelay;
            if (WordDelay > 0)
                WordDelay *= .99f;
        }

        GameDataManager.SpeedDecimalPercentage = 1f - WordDelay / initialWordDelay;
    }
}
