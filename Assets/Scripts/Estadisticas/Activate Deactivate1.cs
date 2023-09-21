using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate1 : MonoBehaviour
{
    [SerializeField] GameObject buttom;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (buttom.activeSelf)
            {
                buttom.SetActive(false);
            }

            else
            {
                buttom.SetActive(true);
            }
        }
    }
}

