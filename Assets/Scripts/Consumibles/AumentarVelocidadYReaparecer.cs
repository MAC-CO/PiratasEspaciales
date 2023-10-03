using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarVelocidadYReaparecer : MonoBehaviour
{
    public float aumentoDeVelocidad = 2.0f; // El aumento de velocidad que deseas aplicar.
    public float tiempoDeReaparición = 10.0f; // Tiempo en segundos antes de reaparecer.

    private Vector3 posicionInicial;
    private bool objetoActivo = true;
    private float tiempoDeReaparicionActual = 0.0f;

    private void Start()
    {
        // Al inicio, guardamos la posición inicial del objeto.
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Si el objeto está inactivo y ha pasado el tiempo de reaparición, lo reactivamos.
        if (!objetoActivo)
        {
            tiempoDeReaparicionActual += Time.deltaTime;
            if (tiempoDeReaparicionActual >= tiempoDeReaparición)
            {
                // Reactivamos el objeto y lo posicionamos en su ubicación inicial.
                gameObject.SetActive(true);
                transform.position = posicionInicial;
                tiempoDeReaparicionActual = 0.0f;
                objetoActivo = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto colisionado tiene el tag "Player" y está activo.
        if (other.CompareTag("Player") && objetoActivo)
        {
            // Aumenta la velocidad del personaje multiplicando su velocidad actual por el aumento deseado.
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Aumenta la velocidad del personaje multiplicando su velocidad actual por el aumento deseado.
                playerRigidbody.velocity *= aumentoDeVelocidad;

                // Destruye el objeto "BuffVel".
                Destroy(gameObject);

                // Establece el objeto como inactivo y comienza el tiempo de reaparición.
                objetoActivo = false;
                tiempoDeReaparicionActual = 0.0f;
            }
        }
    }
}
