using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HUD : UI_Base
{
    
    [SerializeField] Button levelDesignButton;
    [SerializeField] Button characterDesignButton;
    [SerializeField] Button programingDesignButton;
    [SerializeField] Button testingButton;
    [SerializeField] Button publishButton;
    [field: SerializeField] public UI_LeveDesign LevelDesign { get; private set; }
    [field: SerializeField] public UI_CharacterDesign CharacterDesign { get; private set; }
    [field: SerializeField] public UI_Programing Programing { get; private set; }

    private void Start()
    {
        levelDesignButton.onClick.AddListener(OnLevelDesignButtonPress);
        characterDesignButton.onClick.AddListener(OnCharacterDesignButtonPress);
        programingDesignButton.onClick.AddListener(OnProgramingDesignButtonPress);
        testingButton.onClick.AddListener(OnTestingButtonnPress);
        publishButton.onClick.AddListener(OnPublishButtonPress);

        LevelDesign.gameObject.SetActive(false);
        CharacterDesign.gameObject.SetActive(false);
        Programing.gameObject.SetActive(false);

        OnLevelDesignButtonPress();
    }

    private void OnLevelDesignButtonPress()
    {
        Game.Camera.FaceLevel();
        Game.PlayerCharacter.SetPos_LevelStart();

        LevelDesign.Show();
        CharacterDesign.Hide();
        Programing.Hide();
    }

    private void OnCharacterDesignButtonPress()
    {
        Game.Camera.FaceCharacterCreator();
        Game.PlayerCharacter.SetPos_CharacterCreator();

        LevelDesign.Hide();
        CharacterDesign.Show();
        Programing.Hide();
    }

    private void OnProgramingDesignButtonPress()
    {
        Game.Camera.FaceProgramming();
        Game.PlayerCharacter.SetPos_LevelStart();

        LevelDesign.Hide();
        CharacterDesign.Hide();
        Programing.Show();
    }

    private void OnTestingButtonnPress()
    {
        LevelDesign.Hide();
        CharacterDesign.Show();
        Programing.Hide();
    }

    private void OnPublishButtonPress()
    {
        LevelDesign.Hide();
        CharacterDesign.Show();
        Programing.Hide();
    }
}
