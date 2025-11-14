using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BillboardTimerScript : MonoBehaviour
{
    public GameObject gameMaster;
    private Text textObj;
    private float time;
    private int boardtime;
    
    void Start()
    {
        time = gameMaster.GetComponent<GameMasterLogic>().GetTime();
        textObj = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        if (time >= 0.01f)
        {
            time -= Time.deltaTime;
            boardtime = (int)time;
            string seconds = TimeSpan.FromSeconds(boardtime).Seconds.ToString();
            if(seconds.Length < 2) seconds = "0" + TimeSpan.FromSeconds(boardtime).Seconds.ToString();
            textObj.text = TimeSpan.FromSeconds(boardtime).Minutes.ToString()+":"+ seconds;
        }
    }
}
