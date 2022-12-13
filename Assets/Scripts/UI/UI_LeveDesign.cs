using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LeveDesign : UI_Base
{
    [Header("Refs")]
    [SerializeField] UI_LevelContentItem levelContentItemPrefab;

    [Header("Buttons")]
    [SerializeField] Button enviromentButton;
    [SerializeField] Button interactableButton;
    [SerializeField] Button characterButton;

    [Header("Tabs")]
    [SerializeField] RectTransform enviromentTab;
    [SerializeField] RectTransform interactableTab;
    [SerializeField] RectTransform characterTab;
    [SerializeField] RectTransform enviromentContent;
    [SerializeField] RectTransform interactableContent;
    [SerializeField] RectTransform characterContent;

    PlaceableObject[] enviromentalObjects;
    PlaceableObject[] interactableObjects;
    CharacterObject[] characterObjects;

    // tab lists
    List<UI_LevelContentItem> enviromentalObjectItems = new List<UI_LevelContentItem>();
    List<UI_LevelContentItem> interactableObjectsItems = new List<UI_LevelContentItem>();
    List<UI_LevelContentItem> characterObjectsItems = new List<UI_LevelContentItem>();

    private void Start()
    {
        enviromentButton.onClick.AddListener(OnEnviromentButtonPress);
        interactableButton.onClick.AddListener(OnInteractableButtonPress);
        characterButton.onClick.AddListener(OnCharacterButtonPress);

        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(false);

        enviromentalObjects = Resources.LoadAll<PlaceableObject>("Enviroment/");
        interactableObjects = Resources.LoadAll<PlaceableObject>("Interactable/");
        characterObjects = Resources.LoadAll<CharacterObject>("Character/");

        //Debug.Log("Loaded " + interactableObjects.Length + " interactable object to place.");
    }

    public override void Show()
    {
        base.Show();
        OnEnviromentButtonPress();
        Game.PlayerCharacter.Animator.StopPlayback();
        Game.InputReader.LeftMouseEvent += OnLeftClick;
    }

    public override void Hide()
    {
        Game.InputReader.LeftMouseEvent -= OnLeftClick;
        base.Hide();
    }

    private void OnEnviromentButtonPress()
    {
        enviromentTab.gameObject.SetActive(true);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(false);
        
        BuildListEnviroment();
    }

    private void OnInteractableButtonPress()
    {
        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(true);
        characterTab.gameObject.SetActive(false);

        BuildListInteractable();
    }

    private void OnCharacterButtonPress()
    {
        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(true);

        BuildListCharacter();
    }

    private void BuildListEnviroment()
    {
        if (enviromentalObjectItems.Count == 0 && enviromentalObjects.Length > 0)
        {
            foreach (PlaceableObject placeableObject in enviromentalObjects)
            {
                UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, enviromentContent);
                levelContentItem.Set(placeableObject);
                enviromentalObjectItems.Add(levelContentItem);
            }
        }
    }

    private void BuildListInteractable()
    {
        
        if (interactableObjectsItems.Count == 0 && interactableObjects.Length > 0)
        {
            
            foreach (PlaceableObject placeableObject in interactableObjects)
            {
                UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, interactableContent);
                levelContentItem.Set(placeableObject);
                enviromentalObjectItems.Add(levelContentItem);
            }
        }


    }

    private void BuildListCharacter()
    {
        if (characterObjectsItems.Count == 0 && characterObjects.Length > 0)
        {
            foreach (CharacterObject characterObject in characterObjects)
            {
                if (Game.CharacterConfig[characterObject.CharacterIndex].active)
                {
                    UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, characterContent);
                    levelContentItem.Set(characterObject);
                    enviromentalObjectItems.Add(levelContentItem);
                }
                
            }
        }
    }

    private void OnLeftClick()
    {
        if (Game.isPlacing) return;

        Ray ray = Game.Camera.Camera.ScreenPointToRay(Game.InputReader.MousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Game.RaycastDistance) && 
            hit.collider.TryGetComponent<Placeable>(out Placeable placeable))
        {
            placeable.Placing = true;
        }
    }
}
