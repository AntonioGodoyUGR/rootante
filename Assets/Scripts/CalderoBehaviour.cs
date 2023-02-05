using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoBehaviour : MonoBehaviour
{
    private GameObject go;

    public int contador;
    public bool cocinada;
    public SpriteRenderer calderoSR;
    public Sprite calderoHecho;
   
    void Start()
    {
        contador = 0;
        cocinada = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!cocinada)
        {
           go = other.gameObject;
            if (go.tag == "Raiz") 
            {
                go.SetActive(false);
                contador = contador + 1;

                if (contador >= 3)
                {
                    calderoSR.sprite = calderoHecho;
                    cocinada = true;
                }
            }
        }
    }
}
