using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnMano : MonoBehaviour
{
    public ArmaVisual[] armasVisuales;
    public Animator animador;
    // Start is called before the first frame update
    void Start()
    {
        CambiarArma(0);
    }
    [ContextMenu("Arma0")]
    public void PonerArma0()
    {
        CambiarArma(0);
    }
    
    [ContextMenu("Arma1")]
    public void PonerArma1()
    {
        CambiarArma(1);
    }

    public void CambiarArma(int cual)
    {
        for(int i = 0; i < armasVisuales.Length;i++)
        {
            armasVisuales[i].grafico.SetActive(i==cual);
            animador.SetBool(armasVisuales[i].nombreAnim,i==cual);
        }
    }
}

[System.Serializable]
public class ArmaVisual{
    public string nombreAnim;
    public GameObject grafico;
    

}