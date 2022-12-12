using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [Header("Player Character")]
    [SerializeField] Vector3 pos_levelStart;
    [SerializeField] Vector3 pos_characterCreator;

    public void SetPos_LevelStart()
    {
        transform.position = pos_levelStart;
    }

    public void SetPos_CharacterCreator()
    {
        transform.position = pos_characterCreator;
    }
}
