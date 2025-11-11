using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArenaMixer : MonoBehaviour
{
    [SerializeField] private ArenaPrefix[] arenaPrefix;

    [SerializeField] private int matchSize = 3;

    [SerializeField] private ReadSceneNames sceneReader;

    private string[] pickedArenas = null;

    private ArenaPrefix empty = new("you have an error with the arena playlist", 0);

    public void createLevelPlaylist(int playerCount)
    {
        if (arenaPrefix.Count() < 0) return;

        pickedArenas = sceneReader.PrintScenes(pickArenaPrefix(playerCount).playListCue);

        print(pickedArenas.Count());

        pickRandomMaps();
    }

    private void pickRandomMaps()
    {
        string[] temp = new string[matchSize];
        HashSet<string> addedMaps = new();

        int i = 0;
        while (addedMaps.Count < matchSize)
        {
            var random = UnityEngine.Random.Range(0, pickedArenas.Count()-1);
            if (addedMaps.Contains(pickedArenas[random])) break;
            temp[i] = pickedArenas[random];
            addedMaps.Add(pickedArenas[random]);
            i++;
        }
        
        StaticData.currentArenaPlaylist = temp;
    }

    private ArenaPrefix pickArenaPrefix(int size)
    {
        for (int i = 0; i < arenaPrefix.Count(); i++)
        {
            if (arenaPrefix[i].playerCount == size) return arenaPrefix[i];
        }
        print(empty.playListCue); // debug if there is a problem with ArenaPrefix
        return empty;
    }
}
