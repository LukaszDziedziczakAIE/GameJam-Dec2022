using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [Header("TabClick")]
    [SerializeField] public AudioSource TabSource;
    [SerializeField] public List<AudioClip> TabClips;

    [Header("ObjectClick")]
    [SerializeField] public AudioSource ClickSource;
    [SerializeField] public List<AudioClip> ClickClips;

    [Header("DropObject")]
    [SerializeField] public AudioSource DropSource;
    [SerializeField] public List<AudioClip> DropClips;
    void Start()
    {
        if (TabSource != null)
        {
            TabSource.loop = false;
        }

        if (ClickSource != null)
        {
            ClickSource.loop = false;
        }

        if (DropSource != null)
        {
            DropSource.loop = false;
        }
    }

    private AudioClip TabClip
    {
        get
        {
            if (TabClips.Count > 0)
            {
                return TabClips[Random.Range(0, TabClips.Count)];
            }

            return null;
        }
    }

    private AudioClip ClickClip
    {
        get
        {
            if (ClickClips.Count > 0)
            {
                return ClickClips[Random.Range(0, ClickClips.Count)];
            }

            return null;
        }
    }
    private AudioClip DropClip
    {
        get
        {
            if (DropClips.Count > 0)
            {
                return DropClips[Random.Range(0, DropClips.Count)];
            }

            return null;
        }
    }

    private void PlayTabSource(AudioClip audioClip)
    {
        if (TabSource != null && audioClip != null)
        {
            if (TabSource.isPlaying) TabSource.Stop();
            TabSource.clip = audioClip;
            TabSource.Play();
        }
    }

    private void PlayClickSource(AudioClip audioClip)
    {
        if (ClickSource != null && audioClip != null)
        {
            if (ClickSource.isPlaying) ClickSource.Stop();
            ClickSource.clip = audioClip;
            ClickSource.Play();
        }
    }

    private void PlayDropSource(AudioClip audioClip)
    {
        if (DropSource != null && audioClip != null)
        {
            if (DropSource.isPlaying) DropSource.Stop();
            DropSource.clip = audioClip;
            DropSource.Play();
        }
    }

    public void PlayTabClip()
    {
        if (TabClips.Count > 0)
        {
            PlayTabSource(TabClip);
        }
    }
    public void PlayClickClip()
    {
        if (ClickClips.Count > 0)
        {
            PlayClickSource(ClickClip);
        }
    }

    public void PlayDropClip()
    {
        if (DropClips.Count > 0)
        {
            PlayDropSource(DropClip);
        }
    }
}
