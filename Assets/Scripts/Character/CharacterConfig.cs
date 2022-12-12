using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public bool active { get; set; }
    [field: SerializeField] public int voiceRef { get; set; }
    [field: SerializeField] public int helmetRef { get; set; }
    [field: SerializeField] public int armourColourRef { get; set; }
    [field: SerializeField] public int weaponRef { get; set; }
    [field: SerializeField] public List<string> behaviours { get; set; } = new List<string>();

    public void Clear()
    {
        active = false;
        voiceRef = 0;
        helmetRef = 0;
        armourColourRef = 0;
        behaviours.Clear();
    }
}
