using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera cam;




    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        // la barra mira a la camara (solo funciona en ortografico)
        transform.forward = -cam.transform.forward;
    }
}
