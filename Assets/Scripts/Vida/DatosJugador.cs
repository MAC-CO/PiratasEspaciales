using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public int vidaPlayer;
    public Slider VidaVisual;

    private void Update()
    {

        VidaVisual.GetComponent <Slider>().value = vidaPlayer;

        if (vidaPlayer <=0 )
        {
            Debug.Log("jaja, te mataron");
        }
    }
}
