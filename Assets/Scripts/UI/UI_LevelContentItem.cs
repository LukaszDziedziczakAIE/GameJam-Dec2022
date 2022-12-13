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
        print("clicked something to place");
        if (Game.isPlacing) return;

        if (!Game.PointSystem.CanBuy(placeableObject.Cost))
        {
            Debug.LogError("Cannot afford " + placeableObject.Cost);
            return;
        }

        if (characterObject != null)
        {
            print("about to place enemy character");
            EnemyCharacter enemy = Instantiate(characterObject.EnemyCharacterPrefab);
            enemy.configRef = characterObject.CharacterIndex;
            enemy.UpdateCharacter();
            enemy.Placeable.Set(characterObject);
            enemy.Placeable.Placing = true;
            Game.isPlacing = true;

            //enemy.Set(placeableObject);
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
