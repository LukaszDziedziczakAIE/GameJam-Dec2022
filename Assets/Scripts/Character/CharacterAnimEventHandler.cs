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
        audio?.PlayFootstep();
    }

    private void PlayAttackVoice()
    {
        audio?.PlayAttackVoice();
    }

    private void PlayJumpVoice()
    {
        audio?.PlayJumpVoice();
    }
}
