using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    void Awake ()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    void Start()
    {
        {
            Score score = new Score("Jugador1", 100, 10);
            AddScore(score);
        }
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.ToArray().OrderByDescending(x => x.score);
    }


    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
