using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public static Eventos singleton;
   
   private void Awake() 
   {
    singleton = this;
   }

    public void PlayEvento(string evento)
    {
        FMODUnity.RuntimeManager.PlayOneShot(evento);

        //print (evento);
    }
}
