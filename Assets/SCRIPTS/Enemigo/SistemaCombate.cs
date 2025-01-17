using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaCombate;
    [SerializeField] private float danhoCombate;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;



    // awake vs OnEnabled vs Start VIP TEST
    void Awake()
    {
        main.Combate = this;
        
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaCombate;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (main.MainTarget != null && agent.CalculatePath(main.MainTarget.position, new NavMeshPath()))  
      {
            //EnfocarObjetivo();
            agent.SetDestination(main.MainTarget.position);

           if (agent.remainingDistance <= distanciaCombate) 
           {
                agent.isStopped = true;
                anim.SetBool("attacking", true);
           }

           else
           {
                //main.ActivarPatrulla();
           }
      }
    }

    #region Ejecutsods por eventos de anim
    private void Atacar()
    {
        main.MainTarget.GetComponent<Player>().HacerDanho(danhoCombate);
    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
        agent.isStopped = false;
    }



    #endregion

}