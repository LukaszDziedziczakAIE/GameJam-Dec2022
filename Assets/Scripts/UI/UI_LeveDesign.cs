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

    [Header("Content")]
    [SerializeField] RectTransform content;

    PlaceableObject[] enviromentalObjects;
    PlaceableObject[] interactableObjects;
    CharacterObject[] characterObjects;

    [Header("Debug")]
    [SerializeField] List<UI_LevelContentItem> objectItems = new List<UI_LevelContentItem>();


    private void Start()
    {
        enviromentButton.onClick.AddListener(OnEnviromentButtonPress);
        interactableButton.onClick.AddListener(OnInteractableButtonPress);
        characterButton.onClick.AddListener(OnCharacterButtonPress);

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
        BuildListEnviroment();
    }

    private void OnInteractableButtonPress()
    {
        BuildListInteractable();
    }

    private void OnCharacterButtonPress()
    {
        BuildListCharacter();
    }

    private void BuildListEnviroment()
    {
        ClearList();
        if (objectItems.Count == 0 && enviromentalObjects.Length > 0)
        {
            foreach (PlaceableObject placeableObject in enviromentalObjects)
            {
                UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, content);
                levelContentItem.Set(placeableObject);
                objectItems.Add(levelContentItem);
            }
        }
    }

    private void BuildListInteractable()
    {
        ClearList();
        if (objectItems.Count == 0 && interactableObjects.Length > 0)
        {
            
            foreach (PlaceableObject placeableObject in interactableObjects)
            {
                UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, content);
                levelContentItem.Set(placeableObject);
                objectItems.Add(levelContentItem);
            }
        }
    }

    private void BuildListCharacter()
    {
        ClearList();
        if (objectItems.Count == 0 && characterObjects.Length > 0)
        {
            foreach (CharacterObject characterObject in characterObjects)
            {
                if (Game.CharacterConfig[characterObject.CharacterIndex].active)
                {
                    UI_LevelContentItem levelContentItem = Instantiate(levelContentItemPrefab, content);
                    levelContentItem.Set(characterObject);
                    objectItems.Add(levelContentItem);
                }
                
            }
        }
    }

    public void ClearList()
    {
        if (objectItems.Count > 0)
        {
            foreach(var placeableObject in objectItems)
            {
                Destroy(placeableObject.gameObject);
            }
            objectItems.Clear();
        }
    }

    private void OnLeftClick()
    {
        if (Game.isPlacing) return;

        Ray ray = Game.Camera.Camera.ScreenPointToRay(Game.InputReader.MousePosition);
        RaycastHit hit;

        /*if (Physics.Raycast(ray, out hit, Game.RaycastDistance))
        {
            print("Raycasting on click hit " + hit.collider.name);
        }
        else print("Raycasting on click miss");*/

        if (Physics.Raycast(ray, out hit, Game.RaycastDistance) &&
            hit.collider.gameObject.TryGetComponent<Placeable>(out Placeable placeable))
        {
            placeable.RestartPlacement();
        }
    }
}
