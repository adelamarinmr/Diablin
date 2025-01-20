using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;

    private Transform ultimoClick;//guardo la info del npc actual con el que quiero hablar

    [SerializeField] private float distanciaInteraccion=2f;
    [SerializeField] private float attackingDistance =2f;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private Animator anim;

    private PlayerAnimations playerAnimations;

    public PlayerAnimations PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==1)
        {
            Movimiento();
        }
        

        //si existe un npc al cual clické
        if (ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;

            //Comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            { 
                
                LanzarInteraccion(interactuable); 

            }
        }
        else if (ultimoClick.TryGetComponent(out Enemigo enemigo))
        {

            

        }

        else if (ultimoClick && ultimoClick)
        {

            agent.stoppingDistance = 0f;

        }
        
    }

    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }

    private void Movimiento()
    {

        //trazar un raycast desde lacam a la posicion del raton
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //mirar si el pto de inpacto tiene el script npc

               
                agent.SetDestination(hit.point); //directo al punto del impacto


                ultimoClick=hit.transform;

            }
        }
    }

    public void HacerDanho(float danhoCombate)
    {
        Debug.Log("Auch!");
    }
}

