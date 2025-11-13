using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiateGame : MonoBehaviour
{

    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;

    [SerializeField] private List<Transform> leftSpawns;
    [SerializeField] private List<Transform> rightSpawns;

    private int leftSpawnIndex = 0;
    private int rightSpawnIndex = 0;

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
            var teamLogic = StaticData.playersInGame[i].GetComponent<PlayerTeamLogic>();
            var controller = StaticData.playersInGame[i].GetComponent<PlayerController>();

            int teamID = teamLogic.GetTeamID();

            if (teamID == 1)
            {
                team1.Add(StaticData.playersInGame[i]);
                StaticData.playersInGame[i].transform.position = leftSpawns[leftSpawnIndex].position;
                leftSpawnIndex++;
            }

            if (teamID == 2)
            {
                team2.Add(StaticData.playersInGame[i]);
                StaticData.playersInGame[i].transform.position = rightSpawns[rightSpawnIndex].position;
                rightSpawnIndex++;
            }
            
            controller.StopPlayer();     
            
            //if (i % 2 == 0) StaticData.playersInGame[i].transform.position = rightSpawn.position;
            //if (i % 2 != 0) StaticData.playersInGame[i].transform.position = leftSpawn.position;
        }
    }

    
    
}
