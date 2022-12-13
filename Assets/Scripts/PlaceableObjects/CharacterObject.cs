using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameJam/CharacterObject")]
public class CharacterObject : PlaceableObject
{
    [field: SerializeField] public EnemyCharacter EnemyCharacterPrefab { get; private set; }
    [field: SerializeField] public int CharacterIndex { get; private set; }

    public void SetPrefab(EnemyCharacter character)
    {
        EnemyCharacterPrefab = character;
    }
}
