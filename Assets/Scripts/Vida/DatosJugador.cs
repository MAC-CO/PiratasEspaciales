using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public float vidaPlayer;
    public Slider VidaVisual;
    private void Start()
    {
    }
    public void CausarDaño(float d)
    {
        vidaPlayer -= d;
        VidaVisual.value = vidaPlayer;

        if (vidaPlayer <=0 )
        {
            Debug.Log("Death!");
        }
    }
}
