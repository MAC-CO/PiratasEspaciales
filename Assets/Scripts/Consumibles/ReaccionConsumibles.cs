using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaccionConsumibles : MonoBehaviour
{
    public StarterAssets.ThirdPersonController movimiento; // Referencia al script de movimiento.
    public DatosJugador managerVida;
    public float aumentoDeVelocidad = 2.0f; // Aumento de velocidad cuando se consume un objeto.
    public float velocidadOriginalCaminar;
    public float velocidadOriginalCorrer;
    private bool restaurarVelocidad = false;
    public float saltoAumento = 5;
    public float saltoAlturaInicial;
    //public float DañoInicial; 
    //public float dañoAumento = 30;
    public float AumentoVida = 20;
    public float VidaActual;
    

    private void Start()
    {
        velocidadOriginalCaminar = movimiento.MoveSpeed;
        velocidadOriginalCorrer = movimiento.SprintSpeed;
        saltoAlturaInicial = movimiento.JumpHeight;
        VidaActual = managerVida.vidaPlayer;
       // DañoInicial = movimiento.damage;
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
        if (other.CompareTag("BuffSalto")) 
        {

             movimiento.JumpHeight = saltoAumento;
             Destroy(other.gameObject);
             Invoke("RestaurarVelocidad", 5f);
        }
        
      if (other.CompareTag("Regenerar"))
{
    VidaActual += AumentoVida; // Aumenta la vida actual.
    managerVida.vidaPlayer = (int)VidaActual; // Actualiza la vida del jugador en el script DatosJugador.
    Debug.Log("Recuperaste 20 de vida pedazo de gobernado");
    // Actualiza el valor del slider de vida.
    managerVida.VidaVisual.value = VidaActual;
}

    
         //if (other.CompareTag("BuffDaño")) 
         {

            // movimiento.damage = dañoAumento;
             //Destroy(other.gameObject);
             //Invoke("RestaurarDaño", 20);
         }

    }

    public void RestaurarVelocidad()
    {
        // En esta parte se restauran los valores del script
        movimiento.MoveSpeed = velocidadOriginalCaminar;
        movimiento.SprintSpeed = velocidadOriginalCorrer;
        movimiento.JumpHeight = saltoAlturaInicial;
        //movimiento.damage = DañoInicial;

    }
}
