using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamianMovement : MonoBehaviour
{
    public StarterAssets.ThirdPersonController controlador;
    public Vector2 velocidades;
    public InputActionProperty accion;
    public float saltando;
    public float aceleracion;
    public float t;
    public bool enMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VerificarMov());
    }

    // Update is called once per frame
    void Update()
    {
        float a = saltando;
        saltando = accion.action.ReadValue<float>();
        if(a < 0.1f && saltando > 0.5f)
        {
            t = Mathf.Clamp(t+aceleracion,0,1); 
            controlador.MoveSpeed = Mathf.Lerp(velocidades.x,velocidades.y,t);

        }      
        
    }

    IEnumerator VerificarMov()
    {
        while(true)
        {
            Vector3 bpos = transform.position;
            yield return new WaitForSeconds(0.3f);
            enMovimiento = ((bpos - transform.position).magnitude > 0.2f);
            if(!enMovimiento)
            {
                t = 0;
                controlador.MoveSpeed = Mathf.Lerp(velocidades.x,velocidades.y,t);
            }
        }
    }
}
