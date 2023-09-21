using UnityEngine;
using UnityEngine.UI;

public class ContadorSingleton : MonoBehaviour
{

    public static ContadorSingleton instancia;
    public int contador = 0;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text contadorTexto;

    public void ActualizarContador()
    {
        contadorTexto.text = "Monedas: " + contador.ToString();
    }


}


