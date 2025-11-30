using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BillboardTimerScript : MonoBehaviour
{
    public GameObject gameMaster;
    public float timePauseDuration;
    [SerializeField] private UnityEvent gameEndEvent;
    private Text textObj;
    private float initPauseDuration;
    private bool stopTimer;
    private float time;
    private int boardtime;
    
    void Start()
    {
        time = gameMaster.GetComponent<GameMasterLogic>().GetTime();
        textObj = gameObject.GetComponent<Text>();
        initPauseDuration = timePauseDuration;
    }
    
    void Update()
    {
        if(!stopTimer)
        {
            if (time >= 0.01f)
            {
                time -= Time.deltaTime;
                boardtime = (int)time;
                string seconds = TimeSpan.FromSeconds(boardtime).Seconds.ToString();
                if(seconds.Length < 2) seconds = "0" + TimeSpan.FromSeconds(boardtime).Seconds.ToString();
                textObj.text = TimeSpan.FromSeconds(boardtime).Minutes.ToString()+":"+ seconds;
            }
            else 
            {
                gameEndEvent.Invoke();
            }
        }
        else
        {
            if(initPauseDuration >= 0.01f)
            {
                initPauseDuration -= Time.deltaTime;
            }
            else
            {
                stopTimer = false;
                initPauseDuration = timePauseDuration;
            }
        }
    }

    public void StopTime()
    {
        stopTimer = true;
    }
}
