using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] BoxCollider BoxCollider;

    private void Awake()
    {
        if (BoxCollider == null) BoxCollider = GetComponent<BoxCollider>();
    }
}
