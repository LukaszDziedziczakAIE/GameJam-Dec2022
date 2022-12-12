using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] public VoiceType voice;

    void Start()
    {
        if (voice.DeathSource != null)
        {
            voice.DeathSource.loop = false;
        }

        if (voice.VoiceSource != null)
        {
            voice.VoiceSource.loop = false;
        }
    }

    private AudioClip DeathClip
    {
        get
        {
            if (voice.DeathClips.Count > 0)
            {
                return voice.DeathClips[Random.Range(0, voice.DeathClips.Count)];
            }

            return null;
        }
    }

    private AudioClip ReactionClip
    {
        get
        {
            if (voice.ReactionClips.Count > 0)
            {
                return voice.ReactionClips[Random.Range(0, voice.ReactionClips.Count)];
            }

            return null;
        }
    }

    private AudioClip JumpClip
    {
        get
        {
            if (voice.JumpClips.Count > 0)
            {
                return voice.JumpClips[Random.Range(0, voice.JumpClips.Count)];
            }

            return null;
        }
    }

    private AudioClip AttackingClip
    {
        get
        {
            if (voice.AttackingClips.Count > 0)
            {
                return voice.AttackingClips[Random.Range(0, voice.AttackingClips.Count)];
            }

            return null;
        }
    }

    private void PlaySwingSource(AudioClip audioClip)
    {
        if (voice.DeathSource != null && audioClip != null)
        {
            if (voice.DeathSource.isPlaying) voice.DeathSource.Stop();
            voice.DeathSource.clip = audioClip;
            voice.DeathSource.Play();
        }
    }

    private void PlayVoiceSource(AudioClip audioClip)
    {
        if (voice.VoiceSource != null && audioClip != null)
        {
            if (voice.VoiceSource.isPlaying) voice.VoiceSource.Stop();
            voice.VoiceSource.clip = audioClip;
            voice.VoiceSource.Play();
        }
    }

    public void PlaySwing()
    {
        if (voice.DeathClips.Count > 0)
        {
            PlaySwingSource(DeathClip);
        }
    }

    public void PlayReaction()
    {
        if (voice.ReactionClips.Count > 0)
        {
            PlayVoiceSource(ReactionClip);
        }
    }

    public void PlayJump()
    {
        if (voice.JumpClips.Count > 0)
        {
            PlayVoiceSource(JumpClip);
        }
    }

    public void PlayAttack()
    {
        if (voice.AttackingClips.Count > 0)
        {
            PlayVoiceSource(AttackingClip);
        }
    }
}
