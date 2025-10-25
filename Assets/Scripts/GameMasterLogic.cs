using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterLogic : MonoBehaviour
{
    // muss noch weiter gemacht werden weil mache es nur f+r ein Spieler, da noch kein KOOP drinne ist 

    [SerializeField] private float timerInit;
    private int goalCounter;
    private bool isStarting = false;
    private Vector3 savedPosition = new(0, 0, 0);

    void Start()
    {
        StartGame(); //Is erstmal nur Platzhalter 
    }

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

    public void GoalsCounterUp()
    {
        goalCounter++;
    }

    public void PuckReset(GameObject puckObj)
    {
        puckObj.transform.localPosition = savedPosition;
        puckObj.GetComponent<PuckLogic>().StopPuck();
    }

    void EndGame()
    {
        print("SPIEL vorbei");
        //Player disablen oder so 
        //Puck Disablen oder so
    }

    void StartGame()
    {
        goalCounter = 0;
        isStarting = true;
    }    
}
