using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ArenaPrefix
{
    public string playListCue;
    public int playerCount;

    public ArenaPrefix(string playLCue, int plyCount)
    {
        playListCue = playLCue;
        playerCount = plyCount;
    }
}
