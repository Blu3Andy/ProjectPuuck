using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterLogic : MonoBehaviour
{
    // muss noch weiter gemacht werden weil mache es nur f+r ein Spieler, da noch kein KOOP drinne ist 

    [SerializeField] private float timerInit;
    [SerializeField] private int goalCounterTeam1;
    [SerializeField] private int goalCounterTeam2;
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
        //goalCounter++;
    }

    public void PuckReset(GameObject puckObj)
    {
        puckObj.transform.localPosition = savedPosition;
        puckObj.GetComponent<PuckLogic>().StopPuck();
    }

    void EndGame()
    {
        print("SPIEL vorbei");
        //Nächste Area Laden
    }

    void StartGame()
    {
        goalCounterTeam1 = 0;
        goalCounterTeam2 = 0;
        isStarting = true;
    }    
}
