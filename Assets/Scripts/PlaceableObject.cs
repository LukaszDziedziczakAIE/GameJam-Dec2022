using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/PlaceableObject")]
public class PlaceableObject : ScriptableObject
{
    [SerializeField] string objectName;
    [SerializeField] Placeable prefab;
    [SerializeField] Texture icon;
    [SerializeField] float xPos = 0;
}
