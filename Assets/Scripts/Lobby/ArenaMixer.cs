using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ArenaMixer : MonoBehaviour
{
    [SerializeField] private ArenaPrefix[] arenaPrefix;

    [SerializeField] private int matchSize = 3;

    [SerializeField] private ReadSceneNames sceneReader;

    private string[] pickedArenas = null;

    private ArenaPrefix empty = new("", 0);

    public void createLevelPlaylist(int playerCount)
    {
        if (arenaPrefix.Count() < 0) return;

        pickedArenas = sceneReader.PrintScenes(pickArenaPrefix(playerCount));
        if (pickedArenas == null) return;

        print(pickedArenas.Count());

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
            print("range: " + random);
            if (addedMaps.Contains(random)) continue;
            addedMaps.Add(random);
            temp[i] = pickedArenas[random];
            i++;
            print(addedMaps.Count);
        }
        print("loop end");
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
