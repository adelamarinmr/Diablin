using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private NavMeshAgent agent;



    // Start is called before the first frame update
    void Awake()
    {
        main.Combate = this;
        
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
