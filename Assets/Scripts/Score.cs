using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   //En este script se toma el textMeshPro y contiene un metodo que actualiza el
    //estado de las flores que recolecto el jugador y las actualiza dentro del
    //objeto de texto
    private float punto;
    private TextMeshProUGUI textMesh;

    private void Start ()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SumarPunto (float nuevoPunto)
    {
        punto+=nuevoPunto;
        textMesh.text = punto.ToString("0");
    }
}
