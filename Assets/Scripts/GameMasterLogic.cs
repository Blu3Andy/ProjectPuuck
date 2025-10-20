using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterLogic : MonoBehaviour
{
    // muss noch weiter gemacht werden weil mache es nur f+r ein Spieler, da noch kein KOOP drinne ist 

    public int winGoals;

    private int goalCounter;
    private Vector3 savedPosition = new(0, 0, 0);

    void Start()
    {
        goalCounter = 0;
    }

    public void GoalsCounterUp()
    {
        if (winGoals != goalCounter)
        {
            goalCounter++;
            Debug.Log(goalCounter);
        }
        else
        {
            EndGame();
        }

    }

    public void PuckReset(GameObject puckObj)
    {
        puckObj.transform.localPosition = savedPosition;
        puckObj.GetComponent<PuckLogic>().StopPuck();
    }

    void EndGame()
    {
        //Player disablen oder so 
        //Puck Disablen oder so
    }
    
}
