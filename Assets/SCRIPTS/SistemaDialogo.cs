using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //Patron SINGLETON

    public static SistemaDialogo sistema; //ejemplo con el trono y un rey

    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo; //determina si el sist esta escribiendo o no
    private int IndiceFraseActual;// marca la frase x la q voy

    private DialogoSO dialogoActual; // para almacenar con q dialogo estamos trabajando


    private void Awake()
    {
        //si el trono esta vacio...
        if (sistema == null)
        {
            //reclamo el trono y me lo quedo.
            sistema = this;


            //no me destruyo entre escenas.
            DontDestroyOnLoad(gameObject);
        }

        else 
        { 
            //el falso se destruye
          Destroy(this.gameObject); 
        }
    }

    public void IniciarDialogo(DialogoSO dialogo)
    {
        dialogoActual= dialogo;
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());
    }

    
    private IEnumerator EscribirFrase() // q el texto aparezca letra x letra
    {
        escribiendo = true;

        textoDialogo.text = ""; //limpio el texto antes de poner una nueva frase

        char[] fraseEnLetras = dialogoActual.frases[IndiceFraseActual].ToCharArray();

        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }



    public void SiguienteFrase()
    {
        if (escribiendo) //si estamos escribiendo una frase...
        {
            CompletarFrase();
        }

        else
        {
            IndiceFraseActual++;
            if(IndiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }

            else
            {
                TerminarDialogo();
            }
        }
    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        //pongo la frase de golpe
        textoDialogo.text= dialogoActual.frases[IndiceFraseActual];
        escribiendo= false;
    }


    private void TerminarDialogo() // q el texto aparezca letra x letra
    {
        marcos.SetActive(false);
        StopAllCoroutines();
        IndiceFraseActual = 0;//para posteriores dialogos
        escribiendo=false;
        dialogoActual = null;//ya no tenemos ningun dialogo a no ser que me vuelvan a clickar
    }
}