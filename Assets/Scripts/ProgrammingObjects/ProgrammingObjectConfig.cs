using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/ProgrammingObject")]
public class ProgrammingObjectConfig : ScriptableObject
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public Placeable Prefab { get; private set; }
    [field: SerializeField] public Color BlockColor { get; private set; }
    [field: SerializeField] public Texture Icon { get; private set; }
}