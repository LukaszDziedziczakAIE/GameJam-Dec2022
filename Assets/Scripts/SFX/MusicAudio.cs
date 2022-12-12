using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour
{
    [Header("Soundtrack")]
    [SerializeField] public AudioSource SoundtrackSource;
    [SerializeField] public List<AudioClip> SoundtrackClips;

    [Header("Ambience")]
    [SerializeField] public AudioSource AmbienceSource;
    [SerializeField] public List<AudioClip> AmbienceClips;

    void Start()
    {
        if (SoundtrackSource != null)
        {
            SoundtrackSource.loop = true;
        }

        if (AmbienceSource != null)
        {
            AmbienceSource.loop = true;
        }
    }

    private AudioClip SoundtrackClip
    {
        get
        {
            if (SoundtrackClips.Count > 0)
            {
                return SoundtrackClips[Random.Range(0, SoundtrackClips.Count)];
            }

            return null;
        }
    }

    private AudioClip AmbienceClip
    {
        get
        {
            if (AmbienceClips.Count > 0)
            {
                return AmbienceClips[Random.Range(0, AmbienceClips.Count)];
            }

            return null;
        }
    }

    private void PlaySoundtrackSource(AudioClip audioClip)
    {
        if (SoundtrackSource != null && audioClip != null)
        {
            if (SoundtrackSource.isPlaying) SoundtrackSource.Stop();
            SoundtrackSource.clip = audioClip;
            SoundtrackSource.Play();
        }
    }

    private void PlayAmbienceSource(AudioClip audioClip)
    {
        if (AmbienceSource != null && audioClip != null)
        {
            if (AmbienceSource.isPlaying) AmbienceSource.Stop();
            AmbienceSource.clip = audioClip;
            AmbienceSource.Play();
        }
    }

    public void PlaySoundtrack()
    {
        if (SoundtrackClips.Count > 0)
        {
            PlaySoundtrackSource(SoundtrackClip);
        }
    }

    public void PlayAmbience()
    {
        if (AmbienceClips.Count > 0)
        {
            PlayAmbienceSource(AmbienceClip);
        }
    }
}
