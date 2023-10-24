using UnityEngine;
using TMPro;

public class TxtBalas : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public static TxtBalas instance;

    private void Awake()
    {
        instance = this;
    }

    void ActualizarTexto(int balas)
    {
        textMeshPro.text = balas.ToString("00");
    }
}
