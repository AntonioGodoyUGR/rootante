using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/DungenFinal");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void Back()
    {
        SceneManager.LoadScene("Scenes/LoadGame");
    }
    public void Controles()
    {
        SceneManager.LoadScene("Scenes/Controller");
    }

}
