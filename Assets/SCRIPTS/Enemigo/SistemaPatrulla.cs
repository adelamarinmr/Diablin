using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{


    [SerializeField] private Enemigo main;

    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();
    private Vector3 destinoActual;

    private int indiceRutaActual=-1;//marca el indice del nuevo pto al cual patrullar

    


    // Start is called before the first frame update
    private void Awake()
    {
        main.Patrulla = this; // comunico a main que sistpatrulla soy yo


        //voy recorriendo todoslos ptos que tiene mi ruta...
        foreach (Transform punto in ruta)
        {
            //y los añado a mi lista.
            listadoPuntos.Add(punto.position);
        }



        
    }

    private void Start()
    {
       

        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true) // Por siempre...
        {
            CalcularDestino(); //1. calculas un nuevo destino...
            agent.SetDestination(destinoActual); //2. se te marca dicho destino
            yield return new WaitUntil(()=> agent.pathPending && agent.remainingDistance <= 0.2f); //espera hasta que llegues a ese punto.
           
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f));


        }

    }
    private void CalcularDestino()
    {
        indiceRutaActual++;

        if(indiceRutaActual >= listadoPuntos.Count)// count en listas = length en arrays
        {
            //si no me quedan ptos, volvere al pto 0
            indiceRutaActual = 0;
        }
        
        destinoActual = listadoPuntos[indiceRutaActual];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
           
            StopAllCoroutines();//Paro corrutinas
            main.ActivaCombate(other.transform);
            this.enabled = false;//Deshabilito patrulla
        }
    }






}
