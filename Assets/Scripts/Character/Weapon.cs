using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public BoxCollider BoxCollider; 
    [SerializeField] public WeaponAudio Audio;

    Character self;

    private void Awake()
    {
        if (BoxCollider == null) BoxCollider = GetComponent<BoxCollider>();
        if (Audio == null) Audio = GetComponent<WeaponAudio>();
        self = GetComponentInParent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character character) && character != self)
        {
            character.TakeDamage();
        }
    }
}
