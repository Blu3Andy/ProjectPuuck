using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLogic : MonoBehaviour
{
    private AudioLowPassFilter lowPassTrackFilter;

    void Start()
    {
        lowPassTrackFilter = gameObject.GetComponent<AudioLowPassFilter>();
    }

    public void ChangeMusicFilter()
    {
        lowPassTrackFilter.cutoffFrequency = 22000;   
    }


}
