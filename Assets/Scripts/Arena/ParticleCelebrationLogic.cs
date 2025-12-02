using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCelebrationLogic : MonoBehaviour
{
    public float nextEffectTimer = 1f;
    private float initEffectTimer;

    private GameObject[] effectArr;
    private bool startPlaying;
    private int index; 

 
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        initEffectTimer = nextEffectTimer;
        effectArr = GameObject.FindGameObjectsWithTag("Effect");

    }

    // Update is called once per frame
    void Update()
    {
        if(startPlaying && index <= effectArr.Length-1)
        {
            if(initEffectTimer >= 0.01f)
            {
                initEffectTimer -= Time.deltaTime;
            }
            else
            {
                effectArr[index].GetComponent<ParticleSystem>().Play();
                index++;
                initEffectTimer = nextEffectTimer;

                if(effectArr.Length == index)
                {
                    startPlaying = false;
                    index = 0;
                }
                
            }
        }
       
    }

    public void PlayFireworks()
    {
        startPlaying = true;
    }
}
