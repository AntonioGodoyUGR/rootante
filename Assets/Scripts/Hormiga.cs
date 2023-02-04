using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hormiga : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject go;
    private bool curado;
    void Start()
    {
        curado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!curado)
        {
           go = other.gameObject;
            if (go.tag == "Antidoto")
            {
                go.SetActive(false);
                curado = true;
                // TODO: asegurarnos de que el jugador no tiene item
                if (this.gameObject.tag == "Reina"){
                    //TODO: victoria
                }
            }
        }
    }
}
