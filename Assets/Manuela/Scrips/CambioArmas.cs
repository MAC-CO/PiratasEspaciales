using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArmas : MonoBehaviour
{
    public GameObject Army, Army1, Army2, Army3;

    private int numero;

    private void Update()
    {
        if(numero == 0)
        {
            Army.SetActive(true);
            Army1.SetActive(false);
            Army2.SetActive(false);
            Army3.SetActive(false);
        }
        if(numero == 1)
        {
            Army.SetActive(false);
            Army1.SetActive(true);
            Army2.SetActive(false);
            Army3.SetActive(false);
        }
        if (numero == 2)
        {
            Army.SetActive(false);
            Army1.SetActive(false);
            Army2.SetActive(true);
            Army3.SetActive(false);
        }
        if (numero == 3)
        {
            Army.SetActive(false);
            Army1.SetActive(false);
            Army2.SetActive(false);
            Army3.SetActive(true);
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
