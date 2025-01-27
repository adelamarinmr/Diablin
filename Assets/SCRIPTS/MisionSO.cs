using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //"Recoge...
    public string ordenFinal; //"Vuelve a hablar con...

    public bool repetir;// Si la mision tiene varios pasos
    public int repeticionesTotales;

    public int estadoActual;

    public int indiceMision;//Identificador único


}
