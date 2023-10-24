using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioCharYArmy : MonoBehaviour
{
    public GameObject personajillo, personajillo1, personajillo2;

    private int numero;

    private void Update()
    {
        if(numero == 0)
        {
            personajillo.SetActive(true);
            personajillo1.SetActive(false);
            personajillo2.SetActive(false);
        }
        if(numero == 1)
        {
            personajillo.SetActive(false);
            personajillo1.SetActive(true);
            personajillo2.SetActive(false);
        }
        if (numero == 2)
        {
            personajillo.SetActive(false);
            personajillo1.SetActive(false);
            personajillo2.SetActive(true);
        }
    }

    public void izquierda()
    {
        if(numero>0)
        {
            numero -= 1;
        }
    }

    public void derecha()
    {
        if (numero < 3)
        {
            numero += 1;
        }
    }
}
