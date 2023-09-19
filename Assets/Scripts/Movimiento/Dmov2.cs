using System;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class Dmov2 : MonoBehaviour
{
    public StarterAssets.ThirdPersonController controlador;
    public InputActionProperty agacharse;

    public float estaAgachado;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        estaAgachado = agacharse.action.ReadValue<float>();

        controlador.Agachado(estaAgachado>0.5f);
    }
}
