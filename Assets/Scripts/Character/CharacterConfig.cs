using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public int voiceRef { get; set; }
    [field: SerializeField] public int helmetRef { get; set; }
    [field: SerializeField] public int armourColourRef { get; set; }
    [field: SerializeField] public int weaponRef { get; set; }
}
