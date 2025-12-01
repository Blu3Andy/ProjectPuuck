using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameMasterLogic : MonoBehaviour
{
    [SerializeField] private float timerInit;
    [SerializeField] private int goalCounterTeam1 = 0;
    [SerializeField] private int goalCounterTeam2 = 0;
    [SerializeField] private UnityEvent stopTimeEvent = new();

    public GameObject SignTeam1;
    public GameObject SignTeam2;

    [SerializeField] private Transform savedPosition;

    private bool ended = false;

    void Start()
    {
        stopTimeEvent.Invoke();
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

    private void EndGame()
    {
        if(ended) return;
        ended = true;

        HandleTeamData();

        if(StaticData.winningTeamID != 0)
        {
            ScreenTransition.instance.Play();
            Invoke(nameof(LoadWinScene), 0.5f);
            return;
        }

        StaticData.currentGame += 1;
        if (StaticData.currentGame == StaticData.gameRounds)
        {
            DestroyList(StaticData.playersInGame);
            ScreenTransition.instance.Play();
            Invoke(nameof(LoadLobby), 0.5f);
            return;
        }
        ScreenTransition.instance.Play();
        Invoke(nameof(LoadNextScene), 0.5f);
    }

    private void DestroyList(List<GameObject> toDestory)
    {
        for (int i = 0; i < toDestory.Count; i++)
        {
            Destroy(toDestory[i]);
        }
    }

    public void StartEndGame()
    {
        EndGame();
    }

    public float GetTime()
    {
        return timerInit;
    }

    private void HandleTeamData()
    {
        if(goalCounterTeam1 > goalCounterTeam2)
        {
            StaticData.team1Wins++;
        }
        else
        {
            StaticData.team2Wins++;
        }

        if(StaticData.team1Wins > 1) StaticData.winningTeamID = 1;
        if(StaticData.team2Wins > 1) StaticData.winningTeamID = 2;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(StaticData.currentArenaPlaylist[StaticData.currentGame]);
    }

    private void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
