using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateWinScene : MonoBehaviour
{

    [SerializeField] private List<Transform> loserSpawns;
    [SerializeField] private List<Transform> winnerSpawns;

    [SerializeField] private PlayWinEffect winEffectOrange;
    [SerializeField] private PlayWinEffect winEffectBlue;

    private int leftSpawnIndex = 0;
    private int rightSpawnIndex = 0;

    private void Awake()
    {
        TogglePlayer(false);

        SpawnPlayer();

        TogglePlayer(true);

        StaticData.ResetTeamData();
        Invoke(nameof(PlayTransition), 10f);
        Invoke(nameof(EndWinScene), 10.5f);
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

            if (teamID == StaticData.winningTeamID)
            {
                player[i].transform.position = winnerSpawns[leftSpawnIndex].position;
                leftSpawnIndex++;
            }

            if (teamID != StaticData.winningTeamID)
            {
                player[i].transform.position = loserSpawns[rightSpawnIndex].position;
                rightSpawnIndex++;
            }
            
            if(StaticData.winningTeamID == 2) winEffectBlue.Play();
            if(StaticData.winningTeamID == 1) winEffectOrange.Play();
            controller.StopPlayer();     
        }
    }
    private void PlayTransition()
    {
        ScreenTransition.instance.Play();
    }

    private void EndWinScene()
    {
        DestroyList(StaticData.playersInGame);
        SceneManager.LoadScene("Lobby");
    }

    private void DestroyList(List<GameObject> toDestory)
    {
        for (int i = 0; i < toDestory.Count; i++)
        {
            Destroy(toDestory[i]);
        }
    }
}
