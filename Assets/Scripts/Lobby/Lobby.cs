using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerList;

    [SerializeField] private UnityEvent<int> updatePlayerCount;

    [SerializeField] private ArenaMixer arenaMixer;

    [SerializeField] private string[] maps;

    public void AddJoinedPlayer(GameObject player)
    {
        playerList.Add(player);
        updatePlayerCount.Invoke(playerList.Count);

        DontDestroyOnLoad(player);
        StaticData.playersInGame.Add(player);
    }

    public void StartGame()
    {
        arenaMixer.createLevelPlaylist(playerList.Count);
        updateMapList();
        //SceneManager.LoadScene(StaticData.currentArenaPlaylist[StaticData.currentGame]);

    }
    
    private void updateMapList()
    {
        //print(Time.time);
        maps = StaticData.currentArenaPlaylist;
    }
}
