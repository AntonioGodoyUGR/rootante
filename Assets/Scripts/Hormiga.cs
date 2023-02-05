using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hormiga : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject go;
    private bool curado;
    private MoverHormiga2 mh;
    public GameObject jugador;
    public GameManager manager;

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
                manager.numeroHormigas += 1;
                // TODO: asegurarnos de que el jugador no tiene item
                // TODO: actualizar contador de hormigas en el GameManager
                if (this.gameObject.tag == "Reina"){
                    SceneManager.LoadScene("Scenes/GameWin");
                }
            }
        }
    }
}
