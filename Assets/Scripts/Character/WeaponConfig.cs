using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public Weapon Prefab { get; private set; }
    [field: SerializeField] public bool LeftHanded { get; private set; }
}
