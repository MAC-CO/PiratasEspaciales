using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DispersionUI : MonoBehaviour
{
    RectTransform rectTransform;
    public static DispersionUI Instance;

    public Vector2 tamanoDispersion = Vector2.zero;

    public GunData gunData;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        CambiarDispersion(gunData.GetDispersion());
    }

    public void CambiarDispersion(float d)
    {
        float t = d / 0.5f;
        float w = Mathf.Lerp(tamanoDispersion.x,tamanoDispersion.y, t);
        rectTransform.sizeDelta = Vector2.one * w;

        Debug.LogWarning("Disparo con " + d);
    }
}
