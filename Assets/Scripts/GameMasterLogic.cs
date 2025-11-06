using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterLogic : MonoBehaviour
{
    [SerializeField] private float timerInit = 180;
    [SerializeField] private int goalCounterTeam1 = 0;
    [SerializeField] private int goalCounterTeam2 = 0;

    public GameObject SignTeam1;
    public GameObject SignTeam2;

    private Vector3 savedPosition = new(0, 0, 0);

    void Update()
    {
        if (timerInit >= 0.1f)
        {
            timerInit -= Time.deltaTime;
        }
        else
        {
            EndGame();
        }
    }

    public void GoalsCounterUp(int teamID)
    {
        if (teamID == 1)
        {
            goalCounterTeam1++;
            //SignTeam1.GetComponent<GoalSignLogic>()?.CountUp();
            

        }
        else if(teamID == 2)
        {
            goalCounterTeam2++;
            //SignTeam2.GetComponent<GoalSignLogic>()?.CountUp();
        }
    }

    public void PuckReset(GameObject puckObj)
    {                   
        puckObj.transform.localPosition = savedPosition;
        puckObj.GetComponent<PuckLogic>().StopPuck();
        
    }

    void EndGame()
    {
        print("END");
        //Nächste Area Laden
    } 
}
