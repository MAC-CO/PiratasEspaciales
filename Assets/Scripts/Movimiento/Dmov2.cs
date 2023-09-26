using System;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class Dmov2 : MonoBehaviour
{
    public StarterAssets.ThirdPersonController controlador;
    public InputActionProperty agacharse;
    public InputActionProperty Apuntar;
    public InputActionProperty Disparar;
    public float Disparo;
    public float Apuntado;

    public float estaAgachado;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MecanicasDeDisparo();
        MecanicasDeApuntado();
        
        estaAgachado = agacharse.action.ReadValue<float>();

        controlador.Agachado(estaAgachado>0.5f);
    }

    public void MecanicasDeDisparo()
    {
        
        Disparo = Disparar.action.ReadValue<float>();
        if(Disparo >= 1)
        {
        Debug.Log("el sujeto ha disparado");    
        }
        
    }

    public void MecanicasDeApuntado()
    {
        Apuntado = Apuntar.action.ReadValue<float>();

        if(Apuntado >= 1)
        {
        Debug.Log("el sujeto esta apuntando");  
        }else{
        Debug.Log("No esta apuntando");   
        }
        
        
    }

    

}
