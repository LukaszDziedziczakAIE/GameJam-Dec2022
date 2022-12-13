using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public BoxCollider BoxCollider; 
    [SerializeField] public WeaponAudio Audio;

    private void Awake()
    {
        if (BoxCollider == null) BoxCollider = GetComponent<BoxCollider>();
        if (Audio == null) Audio = GetComponent<WeaponAudio>();
    }
}
