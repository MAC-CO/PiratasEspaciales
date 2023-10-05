using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AumentarSaltoYReaparecer : MonoBehaviour
{
    public float aumentoDeAlturaDelSalto = 2.0f; 
    public float tiempoDeReaparición = 10.0f; 

    private Vector3 posicionInicial;
    private bool objetoActivo = true;
    private float tiempoDeReaparicionActual = 0.0f;

    private void Start()
    {
       
        posicionInicial = transform.position;
    }

    private void Update()
    {
       
        if (!objetoActivo)
        {
            tiempoDeReaparicionActual += Time.deltaTime;
            if (tiempoDeReaparicionActual >= tiempoDeReaparición)
            {
                
                gameObject.SetActive(true);
                transform.position = posicionInicial;
                tiempoDeReaparicionActual = 0.0f;
                objetoActivo = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && objetoActivo)
        {
            
            CharacterController characterController = other.GetComponent<CharacterController>();

            if (characterController != null)
            {
               
                characterController.slopeLimit *= aumentoDeAlturaDelSalto;

                
                Destroy(gameObject);

        
                objetoActivo = false;
                tiempoDeReaparicionActual = 0.0f;
            }
        }
    }
}
