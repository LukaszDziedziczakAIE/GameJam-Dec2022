using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VoiceType
{
    [Header("Voice")]
    [field: SerializeField] public AudioSource VoiceSource;
    [field: SerializeField] public List<AudioClip> ReactionClips;
    [field: SerializeField] public List<AudioClip> JumpClips;
    [field: SerializeField] public List<AudioClip> AttackingClips;

    [Header("Death")]
    [field: SerializeField] public AudioSource DeathSource;
    [field: SerializeField] public List<AudioClip> DeathClips;
}
