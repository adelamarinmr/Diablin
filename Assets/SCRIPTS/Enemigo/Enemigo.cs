using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    private Transform mainTarget;

    // acceder en otros scripts sin estar en public (encapsular)
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget; }

    public void Start()
    {
        patrulla.enabled = true; // empieza juego activo patrulla
    }


    public void ActivaCombate(Transform target)
    {
        mainTarget = target;

        combate.enabled = true; // nos dicen de activar combate
    }
}
