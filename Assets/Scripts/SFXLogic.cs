using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLogic : MonoBehaviour
{

    public AudioClip[] SFX;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        PlayRandomSound(SFX);
    }

    private void PlayRandomSound(AudioClip[] SfxClips)
    {
        if(audioSrc == null) return;
        if (SfxClips.Length > 0)
        {
            audioSrc.clip = SfxClips[Random.Range(0, SfxClips.Length)];
            audioSrc.Play();
        }
    }
}
