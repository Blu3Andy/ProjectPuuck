using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudienceLogic : MonoBehaviour
{
    public float duration;
    private GameObject[] audienceArr;
    private bool startCelebrating;
    private float durationInit;
    private GameObject prevMember;

    void Start()
    {
        audienceArr = GameObject.FindGameObjectsWithTag("AudienceMember");
        durationInit = duration;
        
        if(audienceArr != null)
        {
            prevMember = audienceArr[0];
        }
    }


    void Update()
    {
        if (startCelebrating)
        {
            if (durationInit >= 0.01f)
            {
                durationInit -= Time.deltaTime;
            }
            else
            {
                startCelebrating = false;
                durationInit = duration;
            }

            int randomNumb = Random.Range(0, audienceArr.Length-1);

            if(prevMember != audienceArr[randomNumb])
            {
                audienceArr[randomNumb].GetComponent<JumpAudienceLogic>().StartMemberJumping();
                prevMember = audienceArr[randomNumb];
            }
        }
    }
    
    public void SetStartCelebrating()
    {
        startCelebrating = true;
    }
}
