using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Programing : UI_Base
{
    [field: SerializeField] public int CurrentlySelected { get; private set; }
    [SerializeField] RectTransform CharacterBlocks;

    [Header("Buttons")]
    [SerializeField] Button enemyButton1;
    [SerializeField] Button enemyButton2;
    [SerializeField] Button enemyButton3;
    [SerializeField] Button enemyButton4;

    [Header("Content")]
    [SerializeField] RectTransform CodeBlockContent;
    [SerializeField] RectTransform CharacterBlocksContent;
    ProgrammingObjectConfig[] programmingObjectConfigs;

    [Header("Prefab")]
    [SerializeField] UI_ProgramingItem programingItemPrefab;
    [SerializeField] UI_ProgrammingCharacterItem programmingCharacterItem;
    List<UI_ProgramingItem> items = new List<UI_ProgramingItem>();
    List<UI_ProgrammingCharacterItem> characterItems = new List<UI_ProgrammingCharacterItem>();

    Character selectedCharacter;

    private void Start()
    {
        programmingObjectConfigs = Resources.LoadAll<ProgrammingObjectConfig>("ProgrammingBlocks/");

        enemyButton1.onClick.AddListener(OnEnemyButton1Press);
        enemyButton2.onClick.AddListener(OnEnemyButton2Press);
        enemyButton3.onClick.AddListener(OnEnemyButton3Press);
        enemyButton4.onClick.AddListener(OnEnemyButton4Press);
    }

    public override void Show()
    {
        base.Show();
        enemyButton1.gameObject.gameObject.SetActive(Game.CharacterConfig[1].active);
        enemyButton2.gameObject.gameObject.SetActive(Game.CharacterConfig[2].active);
        enemyButton3.gameObject.gameObject.SetActive(Game.CharacterConfig[3].active);
        enemyButton4.gameObject.gameObject.SetActive(Game.CharacterConfig[4].active);
        BuildBlockList();

        CurrentlySelected = 0;
        UpdateButtonInteractability();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void BuildBlockList()
    {
        if (programmingObjectConfigs.Length > 0 && programingItemPrefab != null && items.Count == 0)
        {
            foreach (ProgrammingObjectConfig config in programmingObjectConfigs)
            {
                UI_ProgramingItem item = Instantiate(programingItemPrefab, CodeBlockContent);
                item.Set(config);
                items.Add(item);
            }
        }
    }

    private void OnEnemyButton1Press()
    {
        CurrentlySelected = 1;
        enemyButton1.interactable = false;
        enemyButton2.interactable = true;
        enemyButton3.interactable = true;
        enemyButton4.interactable = true;
        BuildCharacterBlocks();
        UpdateButtonInteractability();
    }

    private void OnEnemyButton2Press()
    {
        CurrentlySelected = 2;
        enemyButton1.interactable = true;
        enemyButton2.interactable = false;
        enemyButton3.interactable = true;
        enemyButton4.interactable = true;
        BuildCharacterBlocks();
        UpdateButtonInteractability();
    }

    private void OnEnemyButton3Press()
    {
        CurrentlySelected = 3;
        enemyButton1.interactable = true;
        enemyButton2.interactable = true;
        enemyButton3.interactable = false;
        enemyButton4.interactable = true;
        BuildCharacterBlocks();
        UpdateButtonInteractability();
    }

    private void OnEnemyButton4Press()
    {
        CurrentlySelected = 4;
        enemyButton1.interactable = true;
        enemyButton2.interactable = true;
        enemyButton3.interactable = true;
        enemyButton4.interactable = false;
        BuildCharacterBlocks();
        UpdateButtonInteractability();
    }

    private CharacterConfig config
    {
        get
        {
            return Game.CharacterConfig[CurrentlySelected];
        }
    }

    public void BuildCharacterBlocks()
    {
        if (CurrentlySelected == 0) return;
        if (programmingCharacterItem == null)
        {
            Debug.LogError(name + " is missing programmingCharacterItem");
            return;
        }


        ClearCharacterBlocks();
        if (config.CodeBlocks.Count > 0)
        {
            foreach (CharacterConfig.CharacterCodeBlock block in config.CodeBlocks)
            {
                UI_ProgrammingCharacterItem charItem = Instantiate(programmingCharacterItem, CharacterBlocksContent);
                charItem.Set(block.CodeConfig);
                characterItems.Add(charItem);
            }
            
        }
        //else Debug.LogError("config.CodeBlocks.Count is " + config.CodeBlocks.Count + " in " + name);
        
    }

    private void ClearCharacterBlocks()
    {
        if (characterItems.Count > 0)
        {
            foreach (UI_ProgrammingCharacterItem item in characterItems)
            {
                Destroy(item.gameObject);
            }
            characterItems.Clear();
        }
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
            Game.ProgrammingPos,
            Quaternion.Euler(Game.ProgrammingRot));
        selectedCharacter.configRef = CurrentlySelected;
        selectedCharacter.UpdateCharacter();
        selectedCharacter.inLevel = false;
        if (selectedCharacter.TryGetComponent<Placeable>(out Placeable placeable))
        {
            placeable.Placing = false;
        }
    }

    private void ClearCharacter()
    {
        if (selectedCharacter != null)
        {
            Destroy (selectedCharacter.gameObject);
            selectedCharacter = null;
        }
    }

    private void UpdateButtonInteractability()
    {
        if (items.Count > 0)
        {
            bool interactable = CurrentlySelected != 0;
            foreach (UI_ProgramingItem item in items)
            {
                item.ButtonInteractability(interactable);
            }


        }
    }
}
