using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Startscreen;

    public void Start()
    {
        Startscreen = GameObject.FindGameObjectWithTag("StartScreen");
    }


    private void Awake()
    {
        Startscreen = GameObject.FindGameObjectWithTag("StartScreen");
    }
    public void PlayGame()
    {
        Destroy(Startscreen);
        SceneManager.LoadSceneAsync("LevelBuilder");


    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
