using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private PlayerController playerController;

    private bool ragDollStarted = false;

    private float ragDollTimer;
    [SerializeField] private float ragDollDuration = 3f;

    private void Awake()
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
        playerController.enabled = true;
    }

    private void Update()
    {
        if (ragDollStarted && ragDollTimer > 0) ragDollTimer -= Time.deltaTime;

        if (ragDollTimer <= 0) endRagdoll();
    }
}
