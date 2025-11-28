using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartBumperLogic : MonoBehaviour
{
    [SerializeField] private Text playerCountText;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent startGameEvent;

    private int activePlayer = 0;
    private int currentPlayerCount = 0;

    private bool areTeamsReady = false;

    private HashSet<GameObject> playersHashSet = new();

    private bool isActive = false;

    private void Update()
    {
        if (activePlayer == currentPlayerCount && currentPlayerCount > 1 && areTeamsReady && !isActive )
        {
            startGameEvent.Invoke();
            isActive = true;
        }

        if (currentPlayerCount < 2 && currentPlayerCount > 0)
        {
            if (!playerCountText) return;
            playerCountText.text = "Not enought Players!";
        }
        else if(!areTeamsReady)
        {
            playerCountText.text ="Choose a Team!";
        }
        else
        {
            playerCountText.text = activePlayer.ToString() + "/" + currentPlayerCount.ToString();
        }

        if (currentPlayerCount == 0) playerCountText.text = "";
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(!areTeamsReady) return;
        if (Helper.IsInLayerMask(collision.gameObject, layerMask))
        {
            DecideActivePlayer(collision.gameObject);
        }
    }
    
    private void DecideActivePlayer(GameObject input)
    {
        input.TryGetComponent(out ReadyMarkerVisual ready);
        print(ready);
        if (!playersHashSet.Contains(input))
        {
            playersHashSet.Add(input);
            activePlayer++;
            if(ready) ready.ToggleMarker();
        }
        else
        {
            playersHashSet.Remove(input);
            activePlayer--;
            if(ready) ready.ToggleMarker();
        }
    }

    public void TeamsReady(bool input)
    {
        print("Are teams ready? " + areTeamsReady);
        areTeamsReady = input;
    }

    public void SetCurrentPlayerCount(int set)
    {
        currentPlayerCount = set;
    }

    public int getCurrentPlayerCount()
    {
        return currentPlayerCount;
    }

    private void Deactivate()
    {
        this.enabled = false;
    }
}
