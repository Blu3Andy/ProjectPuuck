using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBumperLogic : MonoBehaviour
{
    public int teamID;
    void OnCollisionEnter(Collision collision)
    {
        // Team blue or orange
        collision.gameObject.GetComponent<PlayerTeamLogic>().SetTeamID(teamID); 
    }
}
