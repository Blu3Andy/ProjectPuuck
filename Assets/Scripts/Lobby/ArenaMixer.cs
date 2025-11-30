using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ArenaMixer : MonoBehaviour
{
    [SerializeField] private ArenaPrefix[] arenaPrefix;

    [SerializeField] private ReadSceneNames sceneReader;

    private int matchSize;

    private string[] pickedArenas = null;

    private ArenaPrefix empty = new("", 0);

    public void createLevelPlaylist(int playerCount, int matchSize)
    {
        if (arenaPrefix.Count() < 0) return;

        this.matchSize = matchSize;

        pickedArenas = sceneReader.PrintScenes(pickArenaPrefix(playerCount));
        if (pickedArenas == null || pickedArenas.Count()==0) return;

        

        pickRandomMaps();
    }

    private void pickRandomMaps()
    {
        string[] temp = new string[matchSize];
        HashSet<int> addedMaps = new();

        int i = 0;
        while (matchSize > addedMaps.Count)
        {
            var random = UnityEngine.Random.Range(0, pickedArenas.Count() );
            if (addedMaps.Contains(random)) continue;
            addedMaps.Add(random);
            temp[i] = pickedArenas[random];
            i++;
        }
        StaticData.currentArenaPlaylist = temp;
    }

    private string pickArenaPrefix(int size)
    {
        for (int i = 0; i < arenaPrefix.Count(); i++)
        {
            if (arenaPrefix[i].playerCount == size) return arenaPrefix[i].playListCue;
        }
        print("you have an error with the arena playlist"); // debug if there is a problem with ArenaPrefix
        return null;
    }
}
