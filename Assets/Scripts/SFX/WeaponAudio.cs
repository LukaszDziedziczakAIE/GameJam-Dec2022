using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [Header("Swing")]
    [SerializeField] public AudioSource SwingSource;
    [SerializeField] public List<AudioClip> SwingClips;

    [Header("Woosh")]
    [SerializeField] public AudioSource WooshSource;
    [SerializeField] public List<AudioClip> WooshClips;

    [Header("Impact")]
    [SerializeField] public AudioSource ImapactSource;
    [SerializeField] public List<AudioClip> ImpactClips;

    void Start()
    {
        if (SwingSource != null)
        {
            SwingSource.loop = false;
        }

        if (WooshSource != null)
        {
            WooshSource.loop = false;
        }

        if (ImapactSource != null)
        {
            ImapactSource.loop = false;
        }
    }

    private AudioClip SwingClip
    {
        get
        {
            if (SwingClips.Count > 0)
            {
                return SwingClips[Random.Range(0, SwingClips.Count)];
            }

            return null;
        }
    }

    private AudioClip WooshClip
    {
        get
        {
            if (WooshClips.Count > 0)
            {
                return WooshClips[Random.Range(0, WooshClips.Count)];
            }

            return null;
        }
    }

    private AudioClip ImpactClip
    {
        get
        {
            if (ImpactClips.Count > 0)
            {
                return ImpactClips[Random.Range(0, ImpactClips.Count)];
            }

            return null;
        }
    }

    private void PlaySwingSource(AudioClip audioClip)
    {
        if (SwingSource != null && audioClip != null)
        {
            if (SwingSource.isPlaying) SwingSource.Stop();
            SwingSource.clip = audioClip;
            SwingSource.Play();
        }
    }

    private void PlayWooshSource(AudioClip audioClip)
    {
        if (WooshSource != null && audioClip != null)
        {
            if (WooshSource.isPlaying) WooshSource.Stop();
            WooshSource.clip = audioClip;
            WooshSource.Play();
        }
    }

    private void PlayImpactSource(AudioClip audioClip)
    {
        if (ImapactSource != null && audioClip != null)
        {
            if (ImapactSource.isPlaying) ImapactSource.Stop();
            ImapactSource.clip = audioClip;
            ImapactSource.Play();
        }
    }

    public void PlaySwing()
    {
        if (SwingClips.Count > 0)
        {
            PlaySwingSource(SwingClip);
        }
    }

    public void PlayWoosh()
    {
        if (WooshClips.Count > 0)
        {
            PlayWooshSource(WooshClip);
        }
    }

    public void PlayImpact()
    {
        if (ImpactClips.Count > 0)
        {
            PlayImpactSource(ImpactClip);
        }
    }
}
