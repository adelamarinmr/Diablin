using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField]private Player player;
    private Vector3 distanciaPlayer;



    // Start is called before the first frame update
    void Start()
    {
        distanciaPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + distanciaPlayer;
    }
}
