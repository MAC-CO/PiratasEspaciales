using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaccionConsumibles : MonoBehaviour
{
    public StarterAssets.ThirdPersonController movimiento; // Referencia al script de movimiento.
    public float aumentoDeVelocidad = 2.0f; // Aumento de velocidad cuando se consume un objeto.
    public float velocidadOriginalCaminar;
    public float velocidadOriginalCorrer;
    private bool restaurarVelocidad = false;
    public float saltoAumento = 5;
    public float saltoAlturaInicial;

    

    private void Start()
    {
        velocidadOriginalCaminar = movimiento.MoveSpeed;
        velocidadOriginalCorrer = movimiento.SprintSpeed;
        saltoAlturaInicial = movimiento.JumpHeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto colisionado tiene el tag "BuffVel".
        if (other.CompareTag("BuffVel"))
        {
            // Aumenta la velocidad llamando al método del script de movimiento.
            movimiento.MoveSpeed = movimiento.MoveSpeed + aumentoDeVelocidad;
            movimiento.SprintSpeed = movimiento.SprintSpeed + aumentoDeVelocidad;
            
            // Destruye el objeto consumible.
            Destroy(other.gameObject);

            // Programa la restauración de la velocidad después de 5 segundos.
            Invoke("RestaurarVelocidad", 5f);
        }
        if (other.CompareTag("BuffSalto")) {

             movimiento.JumpHeight = saltoAumento;
             Destroy(other.gameObject);
             Invoke("RestaurarVelocidad", 5f);
        }
        
    }

    private void RestaurarVelocidad()
    {
        // En esta parte se restauran los valores del script
        movimiento.MoveSpeed = velocidadOriginalCaminar;
        movimiento.SprintSpeed = velocidadOriginalCorrer;
        movimiento.JumpHeight = saltoAlturaInicial;

    }
}