using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RowUI : MonoBehaviour
{
    public TextMeshProUGUI kills;
    public TextMeshProUGUI names;
    public TextMeshProUGUI score;
    public TextMeshProUGUI rank;

    private PlayerInfo playerInfo; 
    public void UpdateUI(PlayerInfo player)
    {
        kills.text = "Kills: " + player.Kills.ToString();
        names.text = "Name: " + player.Name;
        score.text = "Score: " + player.Score.ToString();
        rank.text = "Rank: " + player.Rank.ToString();
    }

    // Ejemplo de cómo usarlo en tu código
    private void Update()
    {
        // Supongamos que tienes una lista de jugadores
        List<PlayerInfo> players = GetPlayerData(); // Debes implementar esta función

        // Supongamos que quieres mostrar el primer jugador en la lista
        if (players.Count > 0)
        {
            UpdateUI(players[0]);
        }
    }

    // Función de ejemplo para obtener datos de jugadores
    private List<PlayerInfo> GetPlayerData()
    {
        List<PlayerInfo> players = new List<PlayerInfo>
        {
            new PlayerInfo("Player1", 10, 1000, 1),
            new PlayerInfo("Player2", 5, 500, 2),
            new PlayerInfo("Player3", 8, 800, 3)
        };

        return players;
    }
}


public class PlayerInfo
{
    public string Name;
    public int Kills;
    public int Score;
    public int Rank;

    public PlayerInfo(string name, int kills, int score, int rank)
    {
        Name = name;
        Kills = kills;
        Score = score;
        Rank = rank;
    }
}


