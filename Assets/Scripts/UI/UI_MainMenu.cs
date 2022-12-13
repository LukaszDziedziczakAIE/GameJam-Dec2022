using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject loading;

    void Start()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        loading.SetActive(false);
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
        mainMenu.SetActive(false);
        loading.SetActive(true);
        SceneManager.LoadSceneAsync(1);
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
