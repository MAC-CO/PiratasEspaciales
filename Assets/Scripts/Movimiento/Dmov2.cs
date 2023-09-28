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
    public InputActionProperty Reload;
    public float Disparo;
    public float Apuntado;
    public float Recarga;

    public static Action shootInput;
    public static Action reloadInput;

    public float estaAgachado;

    //public Gun guninstanciado;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MecanicasDeDisparo();
        MecanicasDeApuntado();
        MecanicaDeRecarga();
        
        estaAgachado = agacharse.action.ReadValue<float>();

        controlador.Agachado(estaAgachado>0.5f);
    }

    public void MecanicasDeDisparo()
    {
        
        Disparo = Disparar.action.ReadValue<float>();
        if(Disparo >= 1)
        {
        shootInput?.Invoke();
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

    public void MecanicaDeRecarga()
    {
        Recarga = Reload.action.ReadValue<float>();

        if (Recarga >= 1)
        {
            reloadInput?.Invoke();
        }

    }

    

}
