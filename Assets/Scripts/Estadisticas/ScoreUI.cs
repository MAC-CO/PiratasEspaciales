using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private RowUI rowUI;
    [SerializeField]
    private ScoreManager scoreManager;

    
    void Start()
    {
        Debug.Log("Start() se está ejecutando");

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log("Nombre: " + scores[i].name + ", Puntuación: " + scores[i].score);
        }
        for (int i = 0; i < Mathf.Min(scores.Length, transform.childCount); i++)
        {
            var row = transform.GetChild(i).GetComponent<RowUI>();

            row.rank.text = (i + 1).ToString();
            row.names.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }








}
