using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiateGame : MonoBehaviour
{
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
            StaticData.playersInGame[i].GetComponent<PlayerController>().enabled = toggle;
        }
    }

    private void SpawnPlayer()
    {
        List<GameObject> player = StaticData.playersInGame;
        for (int i = 0; i < StaticData.playersInGame.Count; i++)
        {
            player[i].GetComponent<ReadyMarkerVisual>().Disable();
            var teamLogic = player[i].GetComponent<PlayerTeamLogic>();
            var controller = player[i].GetComponent<PlayerController>();

            int teamID = teamLogic.GetTeamID();

            if (teamID == 1)
            {
                team1.Add(player[i]);
                player[i].transform.position = leftSpawns[leftSpawnIndex].position;
                leftSpawnIndex++;
            }

            if (teamID == 2)
            {
                team2.Add(player[i]);
                player[i].transform.position = rightSpawns[rightSpawnIndex].position;
                rightSpawnIndex++;
            }
            
            controller.StopPlayer();     
            
            //if (i % 2 == 0) StaticData.playersInGame[i].transform.position = rightSpawn.position;
            //if (i % 2 != 0) StaticData.playersInGame[i].transform.position = leftSpawn.position;
        }
    }

    
    
}
