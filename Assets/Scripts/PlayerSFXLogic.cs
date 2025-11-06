using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WalkSFXLogic : MonoBehaviour
{
    //SLide
    public float walkSpeedSFX = 0.2f;
    [SerializeField] private bool isBeaterWalking = false;
    [SerializeField] private UnityEvent SFXWalkEvent = new();
    [SerializeField] private UnityEvent SFXSlideEvent = new();
    private float initTimer;
    private PlayerController player;

    void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.GetSpeed() > 0.05f && isBeaterWalking)
        {
            if (initTimer >= 0.01f)
            {
                initTimer -= Time.deltaTime;
            }
            else
            {
                initTimer = GetStepInterval();
                SFXWalkEvent.Invoke();
            }
        }
    }
    
    private float GetStepInterval()
    {
        return Mathf.Clamp(-(player.GetSpeed() / 10f) + 1f, 0.2f, 1f);
    }

    public void SetIsBeaterWalking(bool updateBool)
    {
        isBeaterWalking = updateBool;
    }

    public void PlaySlideSFX(bool isSliding)
    {
        if(isSliding == true)
        {
            SFXSlideEvent.Invoke();
        }
    }

    

    


}
