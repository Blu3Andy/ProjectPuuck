using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class MusicLogic : MonoBehaviour
{
    public float durationOfEffect = 2f;
    private AudioLowPassFilter lowPassTrackFilter;
    private bool startTimer = false;
    private float timer = 0f;

    void Start()
    {
        lowPassTrackFilter = gameObject.GetComponent<AudioLowPassFilter>();
    }

    public void ChangeMusicFilter()
    {
        startTimer = true;
        timer = 0f;
        lowPassTrackFilter.cutoffFrequency = 22000;
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            float valueForLerp = timer / durationOfEffect;

            lowPassTrackFilter.cutoffFrequency = Mathf.Lerp(22000, 400, valueForLerp);

            if (valueForLerp >= 1f)
            {
                startTimer = false;
            }
        }
    }
    


}
