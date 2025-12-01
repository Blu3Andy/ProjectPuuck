using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class StaticData
{
    public static List<GameObject> playersInGame = new();

    public static string[] currentArenaPlaylist;
    public static int currentGame = 1;
    public static int gameRounds = 0;

    public static int team1Wins = 0;
    public static int team2Wins = 0;

    public static int winningTeamID = 0;

    public static void ResetTeamData()
    {
        team1Wins = 0;
        team2Wins = 0;
        winningTeamID = 0;
    }
}
