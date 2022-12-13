using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{




    [SerializeField] public AudioSource UIsource;


    [Header("TabClick")]
    [SerializeField] public List<AudioClip> TabClips;

    [Header("ObjectClick")]
    [SerializeField] public List<AudioClip> ClickClips;

    [Header("DropObject")]
    [SerializeField] public List<AudioClip> DropClips;


    void Start()
    {

        if (UIsource != null)
        {
            UIsource.GetComponent<AudioSource>();
            UIsource.loop = false;
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
        if (UIsource != null && audioClip != null)
        {
            if (UIsource.isPlaying) UIsource.Stop();
            UIsource.clip = audioClip;
            UIsource.Play();
        }
    }

    private void PlayClickSource(AudioClip audioClip)
    {
        if (UIsource != null && audioClip != null)
        {
            if (UIsource.isPlaying) UIsource.Stop();
            UIsource.clip = audioClip;
            UIsource.Play();
        }
    }

    private void PlayDropSource(AudioClip audioClip)
    {
        if (UIsource != null && audioClip != null)
        {
            if (UIsource.isPlaying) UIsource.Stop();
            UIsource.clip = audioClip;
            UIsource.Play();
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
