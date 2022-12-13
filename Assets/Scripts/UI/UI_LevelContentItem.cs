using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelContentItem : UI_Base
{
    [SerializeField] Button button;
    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI text;
    [Header("Debug")]
    [SerializeField] PlaceableObject placeableObject;
    [SerializeField] CharacterObject characterObject;

    private void Start()
    {
        button.onClick.AddListener(OnButtonPress);
    }

    public void Set(PlaceableObject placeableObject)
    {
        this.placeableObject = placeableObject;
        image.texture = this.placeableObject.Icon;
        text.text = "";
    }

    public void Set(CharacterObject characterObject)
    {
        this.characterObject = characterObject;
        image.texture = this.characterObject.Icon;
        text.text = "";
    }

    private void OnButtonPress()
    {
        if (Game.isPlacing)
        {
            Debug.LogError("Game is placing, exiting.");
            return;
        }

        int cost = 0;
        if (placeableObject != null) cost = placeableObject.Cost;
        else if (characterObject != null) cost = characterObject.Cost;

        if (!Game.PointSystem.CanBuy(cost))
        {
            Debug.LogError("Cannot afford " + placeableObject.Cost);
            return;
        }

        if (characterObject != null)
        {
            EnemyCharacter enemy = Instantiate(characterObject.EnemyCharacterPrefab);
            enemy.configRef = characterObject.CharacterIndex;
            enemy.UpdateCharacter();
            enemy.Placeable.Set(characterObject);
            enemy.Placeable.Placing = true;
            Game.isPlacing = true;
        }
        else if (placeableObject != null)
        {
            Placeable placeable = Instantiate(placeableObject.Prefab);
            placeable.Set(placeableObject);
            placeable.Placing = true;
            Game.isPlacing = true;
        }     
    }
}
