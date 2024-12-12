using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{


    //[SerializeField] private Enemigo enemigo;
    [SerializeField] private Transform ruta;
    private NavMeshAgent agent;
    List<Vector3> listadoPuntos = new List<Vector3>();
    private Vector3 destinoActual;

    // Start is called before the first frame update
    private void Awake()
    {
        //voy recorriendo todoslos ptos que tiene mi ruta...
        foreach (Transform punto in ruta)
        {
            //y los añado a mi lista.
            listadoPuntos.Add(punto.position);
        }



        CalcularDestino();
    }

    private void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        agent.SetDestination(destinoActual);
        yield return null;
    }

    private void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
}
