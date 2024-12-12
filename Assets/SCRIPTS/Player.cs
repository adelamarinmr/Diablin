using DG.Tweening;
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

    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private float tiempoRotacion;

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
        if (ultimoClick && ultimoClick.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = distanciaInteraccion;

            //Comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            { 
                
                LanzarInteraccion(npc); 

            }
        }

       
        else if (ultimoClick)
        {

            agent.stoppingDistance = 0f;

        }
        
    }

    private void LanzarInteraccion(NPC npc)
    {
        npc.Interactuar(this.transform);
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
}

