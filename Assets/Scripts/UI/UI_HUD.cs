using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : MonoBehaviour
{
    [SerializeField] GameController Game; 
    [SerializeField] Button levelDesignButton;
    [SerializeField] Button characterDesignButton;
    [SerializeField] Button programingDesignButton;
    [SerializeField] Button testingButton;
    [SerializeField] Button publishButton;

    private void Awake()
    {
        if (Game == null) Game= FindObjectOfType<GameController>();
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
        Game.Camera.FaceLevel();
        Game.PlayerCharacter.SetPos_LevelStart();
    }

    private void OnCharacterDesignButtonPress()
    {
        Game.Camera.FaceCharacterCreator();
        Game.PlayerCharacter.SetPos_CharacterCreator();
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
