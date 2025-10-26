using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerList;

    [SerializeField] private UnityEvent<int> updatePlayerCount;

    public void AddJoinedPlayer(GameObject player)
    {
        playerList.Add(player);
        updatePlayerCount.Invoke(playerList.Count);

        DontDestroyOnLoad(player);
        StaticData.playersInGame.Add(player);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
