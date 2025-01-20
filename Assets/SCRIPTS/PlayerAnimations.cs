using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Player main;


    private void Awake()
    {
        anim = GetComponent<Animator>();

        main.PlayerAnimations=this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EjucutarAtaque()
    {
        anim.SetBool("attacking",true);
    }

    public void PararAtaque()
    {
        anim.SetBool("attacking", false);
    }



}
