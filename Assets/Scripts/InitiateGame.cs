using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiateGame : MonoBehaviour
{

    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;

    [SerializeField] private List <GameObject> team1;
    [SerializeField] private List <GameObject> team2;


    private void Awake()
    {
        TogglePlayer(false);

        SpawnPlayer();

        TogglePlayer(true);
    }

    private void TogglePlayer(bool toggle)
    {
        for (int i = 0; i < StaticData.playersInGame.Count; i++)
        {
            StaticData.playersInGame[i].SetActive(toggle);
        }
    }

    private void SpawnPlayer()
    {
        for (int i = 0; i < StaticData.playersInGame.Count; i++)
        {
            int playerTeamID = StaticData.playersInGame[i].GetComponent<PlayerTeamLogic>().getTeamID();
            if (playerTeamID == 1) team1.Add(StaticData.playersInGame[i]);
            if (playerTeamID == 2) team2.Add(StaticData.playersInGame[i]);
        
            //if (i % 2 == 0) StaticData.playersInGame[i].transform.position = rightSpawn.position;
            //if (i % 2 != 0) StaticData.playersInGame[i].transform.position = leftSpawn.position;
        }
    }
    
    
}
