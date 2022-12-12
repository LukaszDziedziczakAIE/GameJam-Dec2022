using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public CharacterController controller;

    public CharacterConfig Config { get; private set; }

    private void Awake()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
    }

    public void SetNewConfig(CharacterConfig newConfig) { Config = newConfig; }
}
