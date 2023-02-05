using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 240.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        timerText.text = "Timpo: " + timer.ToString("0");
        if (timer <= 0 ){
            //TODO: finaliza partida
        }
    }
}
