using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    //LOS EVENTOS SON "FUNCIONES" QUE PODEMOS ACTIVAR PARA LLAMAR A OBJETOS EN ESCENA Y QUE HAGAN ALGO
    public event Action<MisionSO> OnNuevaMision;  //EVENTO

    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;
    public void NuevaMision(MisionSO mision)
    {
        //AQUI LANZO LA NOTIFICACION X SI A ALGUIEN LE INTERESA
        //?. significa Invocación segura. Se asegura de que haya suscriptores.
        OnNuevaMision?.Invoke(mision); // si no es qcon invocacion segura crashea no entiendo
    }

    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision); 
    }

    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }
}
