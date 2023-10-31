using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Score> scores { get; set; }

    public ScoreData()
    {
        scores = new List<Score>();
    }

    public void AddScore(Score score)
    {
        scores.Add(score);
    }
}
