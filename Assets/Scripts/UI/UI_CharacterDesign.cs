using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterDesign : UI_Base
{
    int currentCharacterIndex = 0;
    Character selectedCharacter;

    [SerializeField] Texture enemyIcon;
    [SerializeField] Texture plusIcon;

    [SerializeField] int costPerEnemy;

    [Header("Title")]
    [SerializeField] TextMeshProUGUI title;

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
    }

    public override void Hide()
    {
        ClearCharacter();
        base.Hide();
    }

    private void OnPlayerButtonPress()
    {
        currentCharacterIndex = 0;
        deleteButton.gameObject.SetActive(false);
        title.text = "Player";
        SetStats();
        SetCharacterButtonVisibility();

        ClearCharacter();
        Game.PlayerCharacter.SetPos_CharacterCreator();
        selectedCharacter = Game.PlayerCharacter;
    }

    private void OnEnemy1ButtonPress()
    {
        if (!Game.CharacterConfig[1].active && !Game.PointSystem.CanBuy(costPerEnemy)) return;
        currentCharacterIndex = 1;
        SetCurrentActive();
        deleteButton.gameObject.SetActive(lastActiveIndex);
        title.text = "Enemy " + currentCharacterIndex;
        SetStats();
        SetCharacterButtonVisibility();
        SpawnCharacter();
    }

    private void OnEnemy2ButtonPress()
    {
        if (!Game.CharacterConfig[2].active && !Game.PointSystem.CanBuy(costPerEnemy)) return;
        currentCharacterIndex = 2;
        SetCurrentActive();
        deleteButton.gameObject.SetActive(lastActiveIndex);
        title.text = "Enemy " + currentCharacterIndex;
        SetStats();
        SetCharacterButtonVisibility();
        SpawnCharacter();
    }

    private void OnEnemy3ButtonPress()
    {
        if (!Game.CharacterConfig[3].active && !Game.PointSystem.CanBuy(costPerEnemy)) return;
        currentCharacterIndex = 3;
        SetCurrentActive();
        deleteButton.gameObject.SetActive(lastActiveIndex);
        title.text = "Enemy " + currentCharacterIndex;
        SetStats();
        SetCharacterButtonVisibility();
        SpawnCharacter();
    }

    private void OnEnemy4ButtonPress()
    {
        if (!Game.CharacterConfig[4].active && !Game.PointSystem.CanBuy(costPerEnemy)) return;
        currentCharacterIndex = 4;
        SetCurrentActive();
        deleteButton.gameObject.SetActive(lastActiveIndex);
        title.text = "Enemy " + currentCharacterIndex;
        SetStats();
        SetCharacterButtonVisibility();
        SpawnCharacter();
    }

    private void SetCurrentActive()
    {
        if (!Game.CharacterConfig[currentCharacterIndex].active && Game.PointSystem.CanBuy(costPerEnemy))
        {
            Game.CharacterConfig[currentCharacterIndex].active = true;

            switch(currentCharacterIndex)
            {
                case 1:
                    enemy1Image.texture = enemyIcon;
                    break;

                case 2:
                    enemy2Image.texture = enemyIcon;
                    break;

                case 3:
                    enemy3Image.texture = enemyIcon;
                    break;

                case 4:
                    enemy4Image.texture = enemyIcon;
                    break;
            }
            Game.PointSystem.AddArtPoints(costPerEnemy/3);
            Game.PointSystem.AddDesignPoints(costPerEnemy / 3);
            Game.PointSystem.AddProgrammingPoints(costPerEnemy / 3);
        }
    }


    private void OnPreviousVoiceButtonPress()
    {
        voiceIndex--;
        if (voiceIndex <= -1) voiceIndex = 1;
        if (voiceIndex == 0) voiceText.text = "Human";
        else if (voiceIndex == 1) voiceText.text = "Golbin";
        Game.CharacterConfig[currentCharacterIndex].voiceRef = voiceIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnNextVoiceButtonPress()
    {
        voiceIndex++;
        if (voiceIndex >= 2) voiceIndex = 0;
        if (voiceIndex == 0) voiceText.text = "Human";
        else if (voiceIndex == 1) voiceText.text = "Golbin";
        Game.CharacterConfig[currentCharacterIndex].voiceRef = voiceIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnPreviousHelmetButtonPress()
    {
        helmetIndex--;
        if (helmetIndex <= -1) helmetIndex = 2;
        if (currentCharacterIndex == 0)
        {
            if (helmetIndex == 0) helmetText.text = "Titan";
            else if (helmetIndex == 1) helmetText.text = "Bezerker";
            else if (helmetIndex == 2) helmetText.text = "Vanguard";
        }
        else if (currentCharacterIndex > 0)
        {
            if (helmetIndex == 0) helmetText.text = "Gitz";
            else if (helmetIndex == 1) helmetText.text = "Golfo";
            else if (helmetIndex == 2) helmetText.text = "Gollum";
        }
        Game.CharacterConfig[currentCharacterIndex].helmetRef = helmetIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnNextHelmetButtonPress()
    {
        helmetIndex++;
        if (helmetIndex >= 3) helmetIndex = 0;
        if(currentCharacterIndex == 0)
        {
            if (helmetIndex == 0) helmetText.text = "Titan";
            else if (helmetIndex == 1) helmetText.text = "Bezerker";
            else if (helmetIndex == 2) helmetText.text = "Vanguard";
        }
        else if (currentCharacterIndex > 0)
        {
            if (helmetIndex == 0) helmetText.text = "Gitz";
            else if (helmetIndex == 1) helmetText.text = "Golfo";
            else if (helmetIndex == 2) helmetText.text = "Gollum";
        }
        Game.CharacterConfig[currentCharacterIndex].helmetRef = helmetIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnColour1ButtonPress()
    {
        colourIndex = 0;
        Game.CharacterConfig[currentCharacterIndex].armourColourRef = colourIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnColour2ButtonPress()
    {
        colourIndex = 1;
        Game.CharacterConfig[currentCharacterIndex].armourColourRef = colourIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnColour3ButtonPress()
    {
        colourIndex = 2;
        Game.CharacterConfig[currentCharacterIndex].armourColourRef = colourIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnColour4ButtonPress()
    {
        colourIndex = 3;
        Game.CharacterConfig[currentCharacterIndex].armourColourRef = colourIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnColour5ButtonPress()
    {
        colourIndex = 4;
        Game.CharacterConfig[currentCharacterIndex].armourColourRef = colourIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnNextWeaponButtonPress()
    {
        weaponIndex++;
        if (weaponIndex >= 4) weaponIndex = 0;
        if (weaponIndex == 0) weaponText.text = "Knights Sword";
        else if (weaponIndex == 1) weaponText.text = "Crusader Blade";
        else if (weaponIndex == 2) weaponText.text = "Goblin Scimitar";
        else if (weaponIndex == 3) weaponText.text = "Bloody Warhammer";
        Game.CharacterConfig[currentCharacterIndex].weaponRef = weaponIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnPreviousWeaponButtonPress()
    {
        weaponIndex--;
        if (weaponIndex <= -1) weaponIndex = 3;
        if (weaponIndex == 0) weaponText.text = "Knights Sword";
        else if (weaponIndex == 1) weaponText.text = "Crusader Blade";
        else if (weaponIndex == 2) weaponText.text = "Goblin Scimitar";
        else if (weaponIndex == 3) weaponText.text = "Bloody Warhammer";
        Game.CharacterConfig[currentCharacterIndex].weaponRef = weaponIndex;
        selectedCharacter.UpdateCharacter();
    }

    private void OnDeleteButtonPress()
    {
        if (!lastActiveIndex) return;

        Game.CharacterConfig[currentCharacterIndex].Clear();
        OnPlayerButtonPress();

        Game.PointSystem.RemoveArtPoints(costPerEnemy/3);
        Game.PointSystem.RemoveDesignPoints(costPerEnemy / 3);
        Game.PointSystem.RemoveProgrammingPoints(costPerEnemy / 3);
    }

    private bool lastActiveIndex
    {
        get
        {
            int lastIndex;

            if (Game.CharacterConfig[4].active) lastIndex = 4;
            else if (Game.CharacterConfig[3].active && !Game.CharacterConfig[4].active) lastIndex = 3;
            else if (Game.CharacterConfig[2].active && !Game.CharacterConfig[3].active) lastIndex = 2;
            else if (Game.CharacterConfig[1].active && !Game.CharacterConfig[2].active) lastIndex = 1;
            else lastIndex = 0;

            return currentCharacterIndex == lastIndex;
        }
    }

    private void SetCharacterButtonVisibility()
    {
        if (!Game.CharacterConfig[1].active) enemy1Image.texture = plusIcon;
        else enemy1Image.texture = enemyIcon;
        if (!Game.CharacterConfig[2].active) enemy2Image.texture = plusIcon;
        else enemy2Image.texture = enemyIcon;
        if (!Game.CharacterConfig[3].active) enemy3Image.texture = plusIcon;
        else enemy3Image.texture = enemyIcon;
        if (!Game.CharacterConfig[4].active) enemy4Image.texture = plusIcon;
        else enemy4Image.texture = enemyIcon;

        if (!Game.CharacterConfig[1].active)
        {
            enemy1Button.gameObject.SetActive(true);
            enemy2Button.gameObject.SetActive(false);
            enemy3Button.gameObject.SetActive(false);
            enemy4Button.gameObject.SetActive(false);
        }
        else if (!Game.CharacterConfig[2].active)
        {
            enemy1Button.gameObject.SetActive(true);
            enemy2Button.gameObject.SetActive(true);
            enemy3Button.gameObject.SetActive(false);
            enemy4Button.gameObject.SetActive(false);
        }
        else if (!Game.CharacterConfig[3].active)
        {
            enemy1Button.gameObject.SetActive(true);
            enemy2Button.gameObject.SetActive(true);
            enemy3Button.gameObject.SetActive(true);
            enemy4Button.gameObject.SetActive(false);
        }
        else if (!Game.CharacterConfig[4].active)
        {
            enemy1Button.gameObject.SetActive(true);
            enemy2Button.gameObject.SetActive(true);
            enemy3Button.gameObject.SetActive(true);
            enemy4Button.gameObject.SetActive(true);
        }
    }

    private void SetStats()
    {
        voiceIndex = Game.CharacterConfig [currentCharacterIndex].voiceRef;
        if (voiceIndex == 0) voiceText.text = "Human";
        else if (voiceIndex == 1) voiceText.text = "Golbin";

        helmetIndex = Game.CharacterConfig [currentCharacterIndex].helmetRef;
        if (currentCharacterIndex == 0)
        {
            if (helmetIndex == 0) helmetText.text = "Titan";
            else if (helmetIndex == 1) helmetText.text = "Bezerker";
            else if (helmetIndex == 2) helmetText.text = "Vanguard";
        }
        else if (currentCharacterIndex > 0)
        {
            if (helmetIndex == 0) helmetText.text = "Gitz";
            else if (helmetIndex == 1) helmetText.text = "Gulfo";
            else if (helmetIndex == 2) helmetText.text = "Golem";
        }

        colourIndex = Game.CharacterConfig[currentCharacterIndex].armourColourRef;
        //set colour to index colour

        weaponIndex = Game.CharacterConfig[currentCharacterIndex].weaponRef;
        if (weaponIndex == 0) weaponText.text = "Knights Sword";
        else if (weaponIndex == 1) weaponText.text = "Crusader Blade";
        else if (weaponIndex == 2) weaponText.text = "Goblin Scimitar";
        else if (weaponIndex == 3) weaponText.text = "Bloody Warhammer";
    }

    private void SpawnCharacter()
    {
        if (Game.EnemyCharacterPrefab == null)
        {
            Debug.LogError("Missing enemy Prefab");
            return;
        }

        ClearCharacter();
        selectedCharacter = Instantiate(
            Game.EnemyCharacterPrefab, 
            Game.CharacterDesignPos, 
            Quaternion.Euler(Game.CharacterDesignRot));
        selectedCharacter.configRef = currentCharacterIndex;
        selectedCharacter.UpdateCharacter();
        selectedCharacter.inLevel = false;
        if(selectedCharacter.TryGetComponent<Placeable>(out Placeable placeable))
        {
            placeable.Placing = false;
        }
    }

    public void ClearCharacter()
    {
        if (selectedCharacter == null) return;

        if (selectedCharacter.configRef == 0)
        {
            Game.PlayerCharacter.SetPos_LevelStart();
            selectedCharacter = null;
        }
        else if (selectedCharacter != null)
        {
            Destroy(selectedCharacter.gameObject);
            selectedCharacter = null;
        }
    }
}
