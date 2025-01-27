using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;


    [SerializeField]
    private ToggleMision[] toggleMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;
    }

    private void ActivarToggleMision(MisionSO mision)
    {

        toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
}
