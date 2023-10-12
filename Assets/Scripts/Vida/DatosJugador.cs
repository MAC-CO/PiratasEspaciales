using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public int vidaPlayer;
    public Slider VidaVisual;
    public int maxHealth;
    public List<Transform> respawnPoints = new List<Transform>();
    public GameObject player;



    public void Start()
    {
        vidaPlayer = maxHealth;
    }

    private void Update()
    {

        VidaVisual.GetComponent <Slider>().value = vidaPlayer;

        if (vidaPlayer <=0 )
        {
            Debug.Log("jaja, te mataron");

            RespawnPlayer();

            vidaPlayer = maxHealth;
        }

    }

    public void ActualizarInterfaz()
    {
        VidaVisual.value = vidaPlayer;
    }


    public void RespawnPlayer()
    {
        Debug.Log("Se activa el Respawn");
        if (respawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, respawnPoints.Count);
            Transform selectedRespawnPoint = respawnPoints[randomIndex];

            // Mueve al jugador al punto de respawn seleccionado
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Ajusta la etiqueta "Player" según tu juego
            player.GetComponent<CharacterController>().Move(selectedRespawnPoint.position - transform.position);
            transform.position = selectedRespawnPoint.position;
            Debug.Log("DEberia respawmear");
        }
        else
        {
            Debug.LogWarning("No hay puntos de respawn disponibles.");
        }
    }








}
