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

    private void PlayReactionVoice()
    {
        audio?.PlayReactionVoice();
    }

    private void PlayDeathVoice()
    {
        audio?.PlayDeathVoice();
    }

    private void PlayJumpVoice()
    {
        audio?.PlayJumpVoice();
    }

    private void PlayWoosh()
    {
        character?.Weapon?.Audio?.PlayWoosh();
    }

    private void PlaySwing()
    {
        character?.Weapon?.Audio?.PlaySwing();
    }

    private void PlayImpact()
    {
        character?.Weapon?.Audio?.PlayImpact();
    }

    private void ColiderOn()
    {
        character.Weapon.BoxCollider.enabled = true;  
    }
    private void ColiderOff()
    {
        character.Weapon.BoxCollider.enabled = false;

    }
}
