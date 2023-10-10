using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : MonoBehaviour
{
    public List<Score> scores;
    public ScoreData()
    {
        scores = new List<Score>();
    }

    public void AddScore(Score score)
    {
        scores.Add(score);
    }
}
