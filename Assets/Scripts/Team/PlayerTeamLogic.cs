using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int teamID = 0;
    [SerializeField] private int areaWinCounter = 0; // für später wenn dann unterschiedliche arenen es gibt (Free For All usw)

    [SerializeField] private GameObject playerRing;

    public void SetTeam(int newTeamID, Material teamColor)
    {
        teamID = newTeamID;
        if (playerRing != null) playerRing.GetComponent<Renderer>().material = teamColor;
    }
    public int GetTeamID()
    {
        return teamID;
    }
}
