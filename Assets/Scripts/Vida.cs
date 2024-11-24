using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    private float puntoVida;
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        puntoVida = 3;
    }
    public void RestarVida()
    {
        puntoVida -= 1;
        textMesh.text = puntoVida.ToString("0");
    }
}
