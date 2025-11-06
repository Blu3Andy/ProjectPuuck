using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class RagdollController : MonoBehaviour
{
    private PlayerController playerController;

    private bool ragDollStarted = false;

    private float ragDollTimer;
    [SerializeField] private float ragDollDuration = 3f;

    [SerializeField] private UnityEvent ragdollStopEvent;

    private void OnEnable()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }

    public void startRagdoll()
    {
        ragDollStarted = true;
        ragDollTimer = ragDollDuration;
        playerController.enabled = false;
    }

    private void endRagdoll()
    {
        ragDollStarted = false;
        ragdollStopEvent.Invoke(); 
    }

    private void Update()
    {
        if (ragDollStarted && ragDollTimer > 0) ragDollTimer -= Time.deltaTime;

        if (ragDollStarted && ragDollTimer <= 0) endRagdoll();
    }
}
