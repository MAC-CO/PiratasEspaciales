using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreData : MonoBehaviour
{
    public List<Score> scores;
    public static ScoreData instance;
    public Text TextoUI;

    private void Awake()
    {
        instance = this;
    }
    public ScoreData()
    {
        scores = new List<Score>();
    }

    public void AddScore(Score score)
    {
        scores.Add(score);
        ActualizarUI();
    }

    public void UpdateScore(Score score)
    {
        for (int i = 0; i < scores.Count; i++)
        {
            if (score.name == scores[i].name)
            {
                scores[i] = score;
                print("actulizado " + score.name);
            }
        }
        print("fin " + score.name);

        Ordenar();

    }

    public void Ordenar()
    {
        List<Score> scores2 = new List<Score>();
        while (scores.Count > 0)
        {
            int k = -1;
            int iFinal = 0;
            for (int i = 0;i < scores.Count;i++) 
            {
                if (scores[i].kills >k)
                {
                    k = scores[i].kills;
                    iFinal = i;
                }
            }

            scores2.Add(scores[iFinal]);
            scores.RemoveAt(iFinal);
        }
        scores = scores2;
        ActualizarUI();
    }

    public void ActualizarUI()

    {
        string Texto = "";
        for (int i = 0; i < scores.Count; i++)
        {
            Texto = Texto + scores[i].kills + " - " + scores[i].name + "\n";
        }
        TextoUI.text = Texto;
    }
}
