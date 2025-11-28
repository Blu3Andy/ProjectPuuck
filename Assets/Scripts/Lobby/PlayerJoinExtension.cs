using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJoinExtension : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> onJoinEvent;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        onJoinEvent.Invoke(playerInput.gameObject);
    }
}
