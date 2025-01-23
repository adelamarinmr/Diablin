using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{

    public event Action OnNuevaMision;  //EVENTO
    public void NuevaMision()
    {
        //AQUI LANZO LA NOTIFICACION X SI A ALGUIEN LE INTERESA
        OnNuevaMision.Invoke();
    }
}
