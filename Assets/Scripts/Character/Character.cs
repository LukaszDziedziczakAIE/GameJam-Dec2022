using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public CharacterController controller;

    private void Awake()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
    }
}
