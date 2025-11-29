using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TeamBumperLogic : MonoBehaviour
{
    [SerializeField] private int teamID;
    [SerializeField] private Material teamColor;
    [SerializeField] private Material noTeamColor;
    [SerializeField] private int maxTeamSize = 2;

    [SerializeField] private UnityEvent<int> teamSizeUpdate;

    private GameObject player;
    private HashSet<GameObject> playersHashSet = new();

    void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject;
        if(playersHashSet.Count == maxTeamSize && !playersHashSet.Contains(player)) return;
        DecideActivePlayer(player); 

        TeamIsFullNotification();
    }

    private void DecideActivePlayer(GameObject player)
    {
        if (!playersHashSet.Contains(player))
        {
            playersHashSet.Add(player);
            player.GetComponent<PlayerTeamLogic>().SetTeam(teamID,teamColor); 
        }
        else
        {
            playersHashSet.Remove(player);
            if(IsInTeam(player))
            {
                player.GetComponent<PlayerTeamLogic>().SetTeam(0,noTeamColor);
                return;
            } 
            if(!IsInTeam(player))
            {
                player.GetComponent<PlayerTeamLogic>().SetTeam(teamID, teamColor);
                return;
            }
        }
    }

    private void TeamIsFullNotification()
    {
        teamSizeUpdate.Invoke(playersHashSet.Count);
    }
    
    void HideBumper()
    {
        gameObject.SetActive(false);
    }

    public void SetCurrentPlayerCount(int set)
    {
        if(set <2) return;
        maxTeamSize = set /2;
    }

    private bool IsInTeam(GameObject player)
    {

        
        return player.GetComponent<PlayerTeamLogic>().GetTeamID() == teamID;
    }



}
