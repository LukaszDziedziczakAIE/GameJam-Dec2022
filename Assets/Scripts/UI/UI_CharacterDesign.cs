using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterDesign : UI_Base
{
    int currentCharacterIndex = 0;

    [SerializeField] Texture enemyIcon;
    [SerializeField] Texture plusIcon;

    [Header("Character Buttons")]
    [SerializeField] Button playerButton;
    [SerializeField] Button enemy1Button;
    [SerializeField] RawImage enemy1Image;
    [SerializeField] Button enemy2Button;
    [SerializeField] RawImage enemy2Image;
    [SerializeField] Button enemy3Button;
    [SerializeField] RawImage enemy3Image;
    [SerializeField] Button enemy4Button;
    [SerializeField] RawImage enemy4Image;

    [Header("Voice Buttons")]
    [SerializeField] Button previousVoiceButton;
    [SerializeField] Button nextVoiceButton;
    [SerializeField] TextMeshProUGUI voiceText;
    int voiceIndex = 0;

    [Header("Helmet Buttons")]
    [SerializeField] Button previousHelmetButton;
    [SerializeField] Button nextHelmetButton;
    [SerializeField] TextMeshProUGUI helmetText;
    int helmetIndex = 0;

    [Header("Colour Buttons")]
    [SerializeField] Button colour1Button;
    [SerializeField] Button colour2Button;
    [SerializeField] Button colour3Button;
    [SerializeField] Button colour4Button;
    [SerializeField] Button colour5Button;
    int colourIndex = 0;

    [Header("Weapon Buttons")]
    [SerializeField] Button previousWeaponButton;
    [SerializeField] Button nextWeaponButton;
    [SerializeField] TextMeshProUGUI weaponText;
    int weaponIndex = 0;

    [Header("Delete Button")]
    [SerializeField] Button deleteButton;

    protected override void Awake()
    {
        base.Awake();
        if (enemy1Button != null) enemy1Image = enemy1Button.GetComponentInChildren<RawImage>();
        if (enemy2Button != null) enemy2Image = enemy2Button.GetComponentInChildren<RawImage>();
        if (enemy3Button != null) enemy3Image = enemy3Button.GetComponentInChildren<RawImage>();
        if (enemy4Button != null) enemy4Image = enemy4Button.GetComponentInChildren<RawImage>();
    }

    private void Start()
    {
        if (playerButton != null) playerButton.onClick.AddListener(OnPlayerButtonPress);
        if (enemy1Button != null) enemy1Button.onClick.AddListener(OnEnemy1ButtonPress);
        if (enemy2Button != null) enemy2Button.onClick.AddListener(OnEnemy2ButtonPress);
        if (enemy3Button != null) enemy3Button.onClick.AddListener(OnEnemy3ButtonPress);
        if (enemy4Button != null) enemy4Button.onClick.AddListener(OnEnemy4ButtonPress);

        if (previousVoiceButton != null) previousVoiceButton.onClick.AddListener(OnPreviousVoiceButtonPress);
        if (nextVoiceButton != null) nextVoiceButton.onClick.AddListener(OnNextVoiceButtonPress);

        if (previousHelmetButton != null) previousHelmetButton.onClick.AddListener(OnPreviousHelmetButtonPress);
        if (nextHelmetButton != null) nextHelmetButton.onClick.AddListener(OnNextHelmetButtonPress);

        if (colour1Button != null) colour1Button.onClick.AddListener(OnColour1ButtonPress);
        if (colour2Button != null) colour2Button.onClick.AddListener(OnColour2ButtonPress);
        if (colour3Button != null) colour3Button.onClick.AddListener(OnColour3ButtonPress);
        if (colour4Button != null) colour4Button.onClick.AddListener(OnColour4ButtonPress);
        if (colour5Button != null) colour5Button.onClick.AddListener(OnColour5ButtonPress);

        if (previousWeaponButton != null) previousWeaponButton.onClick.AddListener(OnPreviousWeaponButtonPress);
        if (nextWeaponButton != null) nextWeaponButton.onClick.AddListener(OnNextWeaponButtonPress);

        if (deleteButton != null) deleteButton.onClick.AddListener(OnDeleteButtonPress);
    }

    public override void Show()
    {
        base.Show();
        OnPlayerButtonPress();
        SetCharacterButtonVisibility();
    }

    private void OnPlayerButtonPress()
    {
        currentCharacterIndex = 0;
        deleteButton.gameObject.SetActive(false);
    }

    private void OnEnemy1ButtonPress()
    {

    }

    private void OnEnemy2ButtonPress()
    {

    }

    private void OnEnemy3ButtonPress()
    {

    }

    private void OnEnemy4ButtonPress()
    {

    }

    private void OnPreviousVoiceButtonPress()
    {
        voiceIndex--;
        if (voiceIndex <= -1) voiceIndex = 3;
        voiceText.text = "Voice " + (voiceIndex + 1);
        Game.CharacterConfig[currentCharacterIndex].voiceRef = voiceIndex;
    }

    private void OnNextVoiceButtonPress()
    {
        voiceIndex++;
        if (voiceIndex >= 4) voiceIndex = 0;
        voiceText.text = "Voice " + (voiceIndex + 1);
        Game.CharacterConfig[currentCharacterIndex].voiceRef = voiceIndex;
    }

    private void OnPreviousHelmetButtonPress()
    {
        helmetIndex--;
        if (helmetIndex <= -1) helmetIndex = 3;
        helmetText.text = "Helmet " + (helmetIndex + 1);
        Game.CharacterConfig[currentCharacterIndex].helmetRef = helmetIndex;
    }

    private void OnNextHelmetButtonPress()
    {
        helmetIndex++;
        if (helmetIndex >= 4) helmetIndex = 0;
        helmetText.text = "Helmet " + (helmetIndex + 1);
        Game.CharacterConfig[currentCharacterIndex].helmetRef = helmetIndex;
    }

    private void OnColour1ButtonPress()
    {

    }

    private void OnColour2ButtonPress()
    {

    }

    private void OnColour3ButtonPress()
    {

    }

    private void OnColour4ButtonPress()
    {

    }

    private void OnColour5ButtonPress()
    {

    }

    private void OnNextWeaponButtonPress()
    {
        weaponIndex++;
        if (weaponIndex >= 2) weaponIndex = 0;
        if (weaponIndex == 0) weaponText.text = "Sword";
        else if (weaponIndex == 1) weaponText.text = "Bow";
        Game.CharacterConfig[currentCharacterIndex].weaponRef = weaponIndex;
    }

    private void OnPreviousWeaponButtonPress()
    {
        weaponIndex--;
        if (weaponIndex <= -1) weaponIndex = 1;
        if (weaponIndex == 0) weaponText.text = "Sword";
        else if (weaponIndex == 1) weaponText.text = "Bow";
        Game.CharacterConfig[currentCharacterIndex].weaponRef = weaponIndex;
    }

    private void OnDeleteButtonPress()
    {

    }

    private void SetCharacterButtonVisibility()
    {

    }
}
