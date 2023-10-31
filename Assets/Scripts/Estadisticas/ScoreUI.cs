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
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();

            row.rank.text = (i + 1).ToString();
            row.names.text = scores[i].name;  // Asegúrate de usar row.names en lugar de row.name
            row.score.text = scores[i].score.ToString();
        }
    }
   







}
