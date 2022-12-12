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

    private void OnButtonPress()
    {
        Placeable placeable = Instantiate(placeableObject.Prefab);
        placeable.Set(placeableObject);
    }
}
