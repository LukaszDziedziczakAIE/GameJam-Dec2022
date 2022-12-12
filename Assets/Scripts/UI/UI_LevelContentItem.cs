using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelContentItem : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI text;

    PlaceableObject placeableObject;
    CharacterObject characterObject;

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
        image.texture = this.placeableObject.Icon;
        text.text = "";
    }

    private void OnButtonPress()
    {
        if (characterObject != null)
        {
            EnemyCharacter enemy = Instantiate(characterObject.EnemyCharacterPrefab);
            //enemy.Set(placeableObject);
        }
        else if (placeableObject != null)
        {
            Placeable placeable = Instantiate(placeableObject.Prefab);
            placeable.Set(placeableObject);
        }
        
    }
}
