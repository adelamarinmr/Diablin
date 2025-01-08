using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;



    // awake vs OnEnabled vs Start VIP TEST
    void Awake()
    {
        main.Combate = this;
        
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      agent.speed=velocidadCombate;
      agent.SetDestination(main.MainTarget.position);
    }
}
