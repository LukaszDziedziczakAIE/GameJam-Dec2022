using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/ProgrammingObject")]
public class ProgrammingObjectConfig : ScriptableObject
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public Texture Icon { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
}