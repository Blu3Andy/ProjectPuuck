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

    private HashSet<GameObject> playersHashSet = new();

    private bool isActive = false;

    private void Update()
    {
        if (activePlayer == currentPlayerCount && currentPlayerCount > 1 && !isActive)
        {
            startGameEvent.Invoke();
            isActive = true;
        }

        if (currentPlayerCount < 2 && currentPlayerCount > 0)
        {
            if (playerCountText == null) return;
            playerCountText.text = "Not enought Players!";
        }
        else
        {
            playerCountText.text = activePlayer.ToString() + "/" + currentPlayerCount.ToString();
        }

        if (currentPlayerCount == 0) playerCountText.text = "";
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (Helper.IsInLayerMask(collision.gameObject, layerMask))
        {
            DecideActivePlayer(collision.gameObject);
        }
    }
    
    private void DecideActivePlayer(GameObject input)
    {
        if (!playersHashSet.Contains(input))
        {
            playersHashSet.Add(input);
            activePlayer++;
        }
        else
        {
            playersHashSet.Remove(input);
            activePlayer--;
        }
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
