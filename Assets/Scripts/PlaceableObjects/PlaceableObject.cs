using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/PlaceableObject")]
public class PlaceableObject : ScriptableObject
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public Placeable Prefab { get; private set; }
    [field: SerializeField] public Texture Icon { get; private set; }
    [field: SerializeField] public float xPos { get; private set; } = 0;
    [field: SerializeField] public int Cost { get; private set; }
}
