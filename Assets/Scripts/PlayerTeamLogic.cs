using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int teamID = 0;
    [SerializeField] private int areaWinCounter = 0; // für später wenn dann unterschiedliche arenen es gibt (Free For All usw)

    public void SetTeamID(int newTeamID)
    {
        teamID = newTeamID;
    }
    public int GetTeamID()
    {
        return teamID;
    }
}
