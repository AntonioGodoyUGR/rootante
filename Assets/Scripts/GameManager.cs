using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 240.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public int numeroHormigas;

    void Start()
    {
        numeroHormigas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        timerText.text = "Timpo: " + timer.ToString("0");
        if (timer <= 0 ){
            SceneManager.LoadScene("Scenes/GameOver");
        }
        scoreText.text = "Hormigas: " + numeroHormigas.ToString() + "/4";
    }
}
