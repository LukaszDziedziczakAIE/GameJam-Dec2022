using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimEventHandler : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] new CharacterAudio audio;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
        audio = character.Audio;
    }

    private void PlayFootstep()
    {
        if (audio != null)
        {
            audio.PlayFootstep();
        }
    }
}
