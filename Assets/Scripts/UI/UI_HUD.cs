using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_HUD : UI_Base
{
    [SerializeField] Button xButton;
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
        xButton.onClick.AddListener(OnXButtonPress);
        levelDesignButton.onClick.AddListener(OnLevelDesignButtonPress);
        characterDesignButton.onClick.AddListener(OnCharacterDesignButtonPress);
        programingDesignButton.onClick.AddListener(OnProgramingDesignButtonPress);
        testingButton.onClick.AddListener(OnTestingButtonnPress);
        publishButton.onClick.AddListener(OnPublishButtonPress);

        LevelDesign.gameObject.SetActive(false);
        CharacterDesign.gameObject.SetActive(false);
        Programing.gameObject.SetActive(false);
    }

    private void OnLevelDesignButtonPress()
    {
        Game.Camera.FaceLevel();
        Game.PlayerCharacter.SetPos_LevelStart();

        LevelDesign.Show();
        CharacterDesign.Hide();
        Programing.Hide();
        TestingMode(false);
    }

    private void OnCharacterDesignButtonPress()
    {
        Game.Camera.FaceCharacterCreator();

        LevelDesign.Hide();
        CharacterDesign.Show();
        Programing.Hide();
        TestingMode(false);
    }

    private void OnProgramingDesignButtonPress()
    {
        Game.Camera.FaceProgramming();
        if (Game.PlayerCharacter.transform.position == Game.CharacterDesignPos) 
            Game.PlayerCharacter.SetPos_LevelStart();

        LevelDesign.Hide();
        CharacterDesign.Hide();
        Programing.Show();
        TestingMode(false);
    }

    private void OnTestingButtonnPress()
    {
        LevelDesign.Hide();
        CharacterDesign.Hide();
        Programing.Hide();
        TestingMode(true);
    }

    private void OnPublishButtonPress()
    {
        LevelDesign.Hide();
        CharacterDesign.Show();
        Programing.Hide();
        TestingMode(false);
    }

    private void OnXButtonPress()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void TestingMode(bool testing)
    {
        Game.TestingMode = testing;
        Game.PlayerCharacter.MapControls(testing);
    }
}
