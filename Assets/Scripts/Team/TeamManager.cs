using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeamManager : MonoBehaviour
{
    private int currentPlayerCount;
    private int playersInTeamOne = 0;
    private int playersInTeamTwo = 0;

    [SerializeField] private UnityEvent<bool> teamsReady;

    public void SetCurrentPlayerCount(int set)
    {
        currentPlayerCount = set;
    }

    public void SetPlayerInTeamOne(int input)
    {
        playersInTeamOne = input;
        AllInTeams();
    }

    public void SetPlayerInTeamTwo(int input)
    {
        playersInTeamTwo = input;
        AllInTeams();
    }

    private void AllInTeams()
    {
        int playerInTeams = playersInTeamOne + playersInTeamTwo;

        if(currentPlayerCount < 2)
        {
            teamsReady.Invoke(false);
            return;
        }
        if(playerInTeams == currentPlayerCount)
        {
            teamsReady.Invoke(true);  
            return;
        } 

        
        teamsReady.Invoke(false);
    }
}
