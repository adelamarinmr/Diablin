using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //Patron SINGLETON

    public static SistemaDialogo sistema;



    private void Awake()
    {
        if (sistema == null)
        {
            sistema = this;


            //no me destruyo entre escenas
            DontDestroyOnLoad(gameObject);
        }

        else 
        { 
          Destroy(this.gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
