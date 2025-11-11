using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class MusicLogic : MonoBehaviour
{
    public float durationOfEffect;
    private AudioLowPassFilter lowPassTrackFilter;
    private bool startTimer = false;
    public float initTime;

    void Start()
    {
        lowPassTrackFilter = gameObject.GetComponent<AudioLowPassFilter>();
        initTime = durationOfEffect;
    }

    public void ChangeMusicFilter()
    {
        startTimer = true;
        lowPassTrackFilter.cutoffFrequency = 22000;
    }

    void Update()
    {
        if (startTimer)
        {
            if (initTime >= 0.01f)
            {
                initTime -= Time.deltaTime;
            }
            else
            {
                lowPassTrackFilter.cutoffFrequency = 400;
                initTime = durationOfEffect;
                startTimer = false;
            }
        }
    }
    


}
