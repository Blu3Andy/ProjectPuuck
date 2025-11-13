using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerList;

    [SerializeField] private UnityEvent<int> updatePlayerCount;

    [SerializeField] private ArenaMixer arenaMixer;

    [SerializeField] private int playedRounds = 3;

    [SerializeField] private string[] maps;

    private void Start()
    {
        StaticData.gameRounds = 1;
        StaticData.currentGame = 0;
        StaticData.playersInGame.Clear();
    }

    public void AddJoinedPlayer(GameObject player)
    {
        playerList.Add(player);
        updatePlayerCount.Invoke(playerList.Count);

        DontDestroyOnLoad(player);
        StaticData.playersInGame.Add(player);
        print("player in static amount:" +StaticData.playersInGame.Count);
    }

    public void StartGame()
    {
        arenaMixer.createLevelPlaylist(playerList.Count, playedRounds);
        StaticData.gameRounds = playedRounds;
        updateMapList();
        SceneManager.LoadScene(StaticData.currentArenaPlaylist[StaticData.currentGame]);

    }
    
    private void updateMapList()
    {
        //print(Time.time);
        maps = StaticData.currentArenaPlaylist;
    }
}
