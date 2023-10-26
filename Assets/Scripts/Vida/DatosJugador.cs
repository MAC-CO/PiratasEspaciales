using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatosJugador : MonoBehaviour
{
    public float vidaPlayer;
    public TMP_Text TextoVida;

    public void Update()
    {
        //actualizartexto();
    }

    public void ActualizarTexto()
    {
        TextoVida.text = vidaPlayer.ToString();
    }

    public void CausarDano(float d)
    {
        vidaPlayer -= d;
        TextoVida.text = vidaPlayer.ToString();
        ActualizarTexto();
        if (vidaPlayer <=0 )
        {
            Debug.Log("Death!");
        }
    }
}
