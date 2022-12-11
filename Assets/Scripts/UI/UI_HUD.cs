using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    [SerializeField] Button levelDesignButton;
    [SerializeField] Button characterDesignButton;
    [SerializeField] Button programingDesignButton;
    [SerializeField] Button testingButton;
    [SerializeField] Button publishButton;

    private void Awake()
    {
        
    }

    private void Start()
    {
        levelDesignButton.onClick.AddListener(OnLevelDesignButtonPress);
        characterDesignButton.onClick.AddListener(OnCharacterDesignButtonPress);
        programingDesignButton.onClick.AddListener(OnProgramingDesignButtonPress);
        testingButton.onClick.AddListener(OnTestingButtonnPress);
        publishButton.onClick.AddListener(OnPublishButtonPress);
    }

    private void OnLevelDesignButtonPress()
    {

    }

    private void OnCharacterDesignButtonPress()
    {

    }

    private void OnProgramingDesignButtonPress()
    {

    }

    private void OnTestingButtonnPress()
    {

    }

    private void OnPublishButtonPress()
    {

    }
}
