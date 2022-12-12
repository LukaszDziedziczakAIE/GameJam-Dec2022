using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    void Start()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    void Update()
    {
        
    }

    public void QuitPressed()
    {
        Application.Quit();
    }

    public void CreatePressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CreditsPressed()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackPressed()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
