using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEstadisticas : MonoBehaviour
{
    public GameObject objetoAActivar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Tecla Z presionada");
            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
                Debug.Log("Objeto activado");
            }
        }
    }
}
