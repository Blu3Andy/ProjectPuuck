using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    [SerializeField] private GameObject puckObj;
    [SerializeField] private GameObject gameMaterObj;
    // Start is called before the first frame update
    void Start()
    {
        puckObj = GameObject.Find("Puck");
        gameMaterObj = GameObject.Find("GameMaster");
    }

    void OnTriggerEnter(Collider other)
    {
        gameMaterObj.GetComponent<GameMasterLogic>().GoalsCounterUp();
        gameMaterObj.GetComponent<GameMasterLogic>().PuckReset(puckObj);
    }  

}
