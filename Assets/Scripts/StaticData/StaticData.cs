using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class StaticData
{
    public static List<GameObject> playersInGame = new();

    public static string[] currentArenaPlaylist;
    public static int currentGame = 1;
    public static int gameRounds = 0;
}
