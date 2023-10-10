using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Score
{
    public string name;
    public int score;
    public int kills;

    public Score(string name, int score, int kills)
    {
        this.name = name;
        this.score = score;
        this.kills = kills;
    }
}

