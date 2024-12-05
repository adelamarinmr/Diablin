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
    private int IndiceFraseActual;

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
        
        marcos.SetActive(true);
    }

    private void TerminarDialogo() // q el texto aparezca letra x letra
    {
        marcos.SetActive(false);
    }
    

    private void EscribirFrase()
    {
        
    }

    private void SiguienteFrase()
    {

    }

    private void FFFrase()
    {

    }
}
