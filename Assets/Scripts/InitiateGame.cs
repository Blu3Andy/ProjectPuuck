using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiateGame : MonoBehaviour
{

    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;


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
            if (i % 2 == 0) StaticData.playersInGame[i].transform.position = rightSpawn.position;
            if (i % 2 != 0) StaticData.playersInGame[i].transform.position = leftSpawn.position;
        }
    }
    
    
}
