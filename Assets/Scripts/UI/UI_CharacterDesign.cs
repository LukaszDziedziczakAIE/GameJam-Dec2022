using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterDesign : UI_Base
{
    int currentCharacterIndex;

    [SerializeField] Texture enemyIcon;
    [SerializeField] Texture plusIcon;

    [Header("Character Buttons")]
    [SerializeField] Button playerButton;
    [SerializeField] Button enemy1Button;
    [SerializeField] RawImage enemy1Image;

    [Header("Voice Buttons")]
    [SerializeField] Button previousVoiceButton;
    [SerializeField] Button nextVoiceButton;
    [SerializeField] TextMeshProUGUI voiceText;
    int voiceIndex = 0;

    private void Awake()
    {
        if (enemy1Button != null) enemy1Image = enemy1Button.GetComponentInChildren<RawImage>();
    }

    private void Start()
    {
        if (playerButton != null) playerButton.onClick.AddListener(OnPlayerButtonPress);
    }

    private void OnPlayerButtonPress()
    {

    }

    private void OnNextVoiceButtonPress()
    {
        voiceIndex++;
        if (voiceIndex >= 3) voiceIndex = 0;
        voiceText.text = "Voice " + (voiceIndex + 1);
        Game.CharacterConfig[currentCharacterIndex].voiceRef = voiceIndex;

    }




}
