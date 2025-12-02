using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject controllerMap;
    InputMaster input;

    private bool isOpen = false;

    void Awake()
    {
        input = new();
        DontDestroyOnLoad(gameObject);

        input.Player.Controls.performed += i => ControllInteract();
    }

    private void ControllInteract()
    {
        isOpen = !isOpen;
        controllerMap.SetActive(isOpen);
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
