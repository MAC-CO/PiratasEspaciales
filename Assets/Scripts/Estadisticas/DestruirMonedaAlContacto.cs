using UnityEngine;

public class DestruirMonedaAlContacto : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {
            Destroy(other.gameObject);
            ContadorSingleton.instancia.contador++;
            ContadorSingleton.instancia.ActualizarContador();
        }
    }
}










