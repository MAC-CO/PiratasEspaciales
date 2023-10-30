using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        
        canvas.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            canvas.enabled = !canvas.enabled;
        }
    }
}
