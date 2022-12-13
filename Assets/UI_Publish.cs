using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_Publish : MonoBehaviour
{
    [Header("Art")]
    [SerializeField] Slider artBar;
    [SerializeField] TextMeshProUGUI artScore;
    [SerializeField] GameObject artReference;

    [Header("Design")]
    [SerializeField] Slider designBar;
    [SerializeField] TextMeshProUGUI designScore;
    [SerializeField] GameObject designReference;

    [Header("Programming")]
    [SerializeField] Slider programmingBar;
    [SerializeField] TextMeshProUGUI programmingScore;
    [SerializeField] GameObject programmingReference;

    [Header("Universal")]
    [SerializeField] GameObject mulitReference;
    [SerializeField] Button quitButton;
    [SerializeField] Button continueButton;

    GameController game;

    PointSystem pointSystem;

    private void Awake()
    {
        game = FindObjectOfType<GameController>();
    }

    void Start()
    {
        pointSystem = game.PointSystem;

        if (quitButton != null) quitButton.onClick.AddListener(OnQuitPressed);
        if (continueButton != null) continueButton.onClick.AddListener(OnContinuePressed);

        artReference.SetActive(false);
        designReference.SetActive(false);
        programmingReference.SetActive(false);
        mulitReference.SetActive(false);
    }

    void Update()
    {

    }

    public void PopulateMenu()
    {
        artBar.value = pointSystem.artPoints / (float)pointSystem.initialPoints;
        artScore.text = pointSystem.artPoints.ToString();

        designBar.value = pointSystem.designPoints / (float)pointSystem.initialPoints;
        designScore.text = pointSystem.designPoints.ToString();

        programmingBar.value = pointSystem.programmingPoints / (float)pointSystem.initialPoints;
        programmingScore.text = pointSystem.programmingPoints.ToString();

        if (isArt)
        {
            artReference.SetActive(true);
            designReference.SetActive(false);
            programmingReference.SetActive(false);
            mulitReference.SetActive(false);
        }
        else if (isDesign)
        {
            designReference.SetActive(true);
            artReference.SetActive(false);
            programmingReference.SetActive(false);
            mulitReference.SetActive(false);
        }
        else if (isProgramming)
        {
            artReference.SetActive(false);
            designReference.SetActive(false);
            programmingReference.SetActive(true);
            mulitReference.SetActive(false);
        }
        else
        {
            artReference.SetActive(false);
            designReference.SetActive(false);
            programmingReference.SetActive(false);
            mulitReference.SetActive(true);
        }
    }

    public bool isArt
    {
        get
        {
            if (pointSystem.artPoints > pointSystem.designPoints && pointSystem.artPoints > pointSystem.programmingPoints) return true;
            else return false;
        }
    }

    public bool isDesign
    {
        get
        {
            if (pointSystem.designPoints > pointSystem.artPoints && pointSystem.designPoints > pointSystem.programmingPoints) return true;
            else return false;
        }
    }

    public bool isProgramming
    {
        get
        {
            if (pointSystem.programmingPoints > pointSystem.artPoints && pointSystem.programmingPoints > pointSystem.designPoints) return true;
            else return false;
        }
    }

    private void OnQuitPressed()
    {
        SceneManager.LoadScene("StartScreen");
    }

    private void OnContinuePressed()
    {
        game.HUD.OnLevelDesignButtonPress();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        PopulateMenu();
    }
}
