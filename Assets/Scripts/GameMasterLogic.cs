using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterLogic : MonoBehaviour
{
    [SerializeField] private float timerInit = 10;
    [SerializeField] private int goalCounterTeam1 = 0;
    [SerializeField] private int goalCounterTeam2 = 0;

    public GameObject SignTeam1;
    public GameObject SignTeam2;

    [SerializeField] private Transform savedPosition;

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
            SignTeam1.GetComponent<GoalSignLogic>()?.CountUp();
            

        }
        else if(teamID == 2)
        {
            goalCounterTeam2++;
            SignTeam2.GetComponent<GoalSignLogic>()?.CountUp();
        }
    }

    public void PuckReset(GameObject puckObj)
    {                   
        puckObj.transform.localPosition = savedPosition.transform.position;
        puckObj.GetComponent<PuckLogic>().StopPuck();
        
    }

    void EndGame()
    {
        StaticData.currentGame += 1;

        if (StaticData.currentGame == StaticData.gameRounds)
        {
            DestroyList(StaticData.playersInGame);
            SceneManager.LoadScene("Lobby");
            return;
        }

        SceneManager.LoadScene(StaticData.currentArenaPlaylist[StaticData.currentGame]);
    } 
    
    private void DestroyList(List<GameObject> toDestory)
    {
        for(int i = 0; i < toDestory.Count; i ++)
        {
            Destroy(toDestory[i]);
        }
    }
}
