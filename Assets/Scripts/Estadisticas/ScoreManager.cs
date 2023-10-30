using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public string nombre;
    public Score score;


  
    void Start()
    {
        score = new Score(nombre, 0, 0);
        ScoreData.instance.AddScore(score);
    }

    [ContextMenu("Sumar score")]
   public void SumarScore()
    {
        score.score++;
        ScoreData.instance.UpdateScore(score);
    }

    [ContextMenu("Sumar Kills")]
    public void SumarKills()
    {
        score.kills++;
        ScoreData.instance.UpdateScore(score);
    }
}
