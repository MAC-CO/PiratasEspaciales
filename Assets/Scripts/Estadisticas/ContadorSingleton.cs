using UnityEngine;
using UnityEngine.UI;

public class ContadorSingleton : MonoBehaviour
{
    public GameObject ObjetoMoneda;
    public static ContadorSingleton instancia;
    public int contador = 0;

    //void Awake()
    //{
    //    if (instancia == null)
    //    {
    //        instancia = this;
    //        DontDestroyOnLoad(ObjetoMoneda);
    //    }
    //    else
    //    {
    //        Destroy(ObjetoMoneda);
    //    }
    //}

    public void Update()
    {
        if (instancia == null)
        {
            instancia = this;
            //DontDestroyOnLoad(ObjetoMoneda);
        }
        else
        {
            Destroy(ObjetoMoneda);
        }
    }
    public Text contadorTexto;

    public void ActualizarContador()
    {
        contadorTexto.text = "Monedas: " + contador.ToString();
    }


}


