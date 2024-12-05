using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    private Outline outline;

    [SerializeField] private Texture2D cursorNPC;
    [SerializeField] private Texture2D cursorPorDefecto;

    [SerializeField] private float tiempoRotacion;

    [SerializeField] private DialogoSO dialogo;

    // Start is called before the first frame update

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }


    public void Interactuar(Transform interactuador)
    {

        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogo.sistema.IniciarDialogo(dialogo));

        

    }







    private void OnMouseEnter()
    {
       Cursor.SetCursor(cursorNPC, new Vector2(0, 0), CursorMode.Auto);
       
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
       Cursor.SetCursor(cursorPorDefecto, new Vector2(0, 0), CursorMode.Auto);

       outline.enabled = false;
    }
}
