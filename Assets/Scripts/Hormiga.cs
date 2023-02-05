using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hormiga : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject go;
    private bool curado;
    private MoverHormiga2 mh;
    public GameObject jugador;


    void Start()
    {
        curado = false;
        mh = jugador.GetComponent("MoverHormiga2") as MoverHormiga2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!curado)
        {
           go = other.gameObject;
            if (go.tag == "Antidoto")
            {
                go.SetActive(false);
                curado = true;
                mh.pickedObject = null;
                // TODO: asegurarnos de que el jugador no tiene item
                // TODO: actualizar contador de hormigas en el GameManager
                if (this.gameObject.tag == "Reina"){
                    //TODO: victoria
                    Debug.Log("WIIIN");
                }
            }
        }
    }
}
