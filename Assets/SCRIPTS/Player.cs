using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;

    private NPC npcActual;//guardo la info del npc actual con el que quiero hablar

    [SerializeField] private float distanciaInteraccion;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        //si existe un npc al cual clické
        if(npcActual)
        {
            //Comprobar si he llegado al npc
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(this.transform);

                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
        }
        
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

                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    //y en ese caso ese es el npc es el actual
                    npcActual = npc;

                    // ahora mi distancia de parada es la de interaccion ( pararse a X metros del NPC)
                    agent.stoppingDistance = distanciaInteraccion;
                }
                agent.SetDestination(hit.point); //directo al punto del impacto
            }
        }
    }
}

