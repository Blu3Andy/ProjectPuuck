using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeamBumperLogic : MonoBehaviour
{
    public int teamID;
    public Material teamColor;
    void OnCollisionEnter(Collision collision)
    {
        GameObject player = collision.gameObject;
        player.GetComponent<PlayerTeamLogic>().SetTeam(teamID,teamColor); 
    }

    

    void HideBumper()
    {
        gameObject.SetActive(false);
    }



}
