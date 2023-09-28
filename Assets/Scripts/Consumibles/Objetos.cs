using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerObjeto : MonoBehaviour
{
    // Velocidad que se aumentará al recoger un Objeto1
    public float aumentoDeVelocidad = 10f;

    // Colisión entre objetos
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó tiene el tag "Objeto1"
        if (other.CompareTag("ConsumibleVel"))
        {
            // Destruir el objeto Objeto1
            Destroy(other.gameObject);

            // Aumentar la velocidad del jugador
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity += Vector3.forward * aumentoDeVelocidad;
            }
        }
    }
}
