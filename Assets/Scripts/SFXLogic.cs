using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLogic : MonoBehaviour
{

    public AudioClip[] SFX;
    public AudioClip[] WallCollSFX;


    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public void PlayCollisionPuckPlayer()
    {
        PlayRandomSound(SFX);
    }
    public void PlayCollisionPuckWall()
    {
        PlayRandomSound(WallCollSFX);
    }


    private void PlayRandomSound(AudioClip[] SfxClips)
    {
        if (SfxClips.Length > 0)
        {
            audioSrc.clip = SfxClips[Random.Range(0, SfxClips.Length)];
            audioSrc.Play();
        }
    }
}
