using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoBehaviour : MonoBehaviour
{
    public GameObject raiz1;
    public GameObject raiz2;
    public GameObject raiz3;

    private GameObject go;

    private int contador;
    public bool cocinada;

   
    void Start()
    {
        contador = 0;
        cocinada = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cocinada)
        {
           go = other.gameObject;
            if (go.tag == "Raiz") 
            {
                go.SetActive(false);
                contador = contador++;
                
                if (contador >= 3) cocinada = true;
                
            }
        }
    }
}
