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

    private void DecideActivePlayer(GameObject input)
    {
        if (!playersHashSet.Contains(input))
        {
            playersHashSet.Add(input);
            player.GetComponent<PlayerTeamLogic>().SetTeam(teamID,teamColor); 
        }
        else
        {
            playersHashSet.Remove(input);
            player.GetComponent<PlayerTeamLogic>().SetTeam(0,noTeamColor); 
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
        print(set);
        if(set <2) return;
        maxTeamSize = set /2;
    }



}
