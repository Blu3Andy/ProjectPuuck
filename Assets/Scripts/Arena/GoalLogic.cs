using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalLogic : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent goalEvent;
    public int teamID;


    void OnTriggerEnter(Collider other)
    {
        if (Helper.IsInLayerMask(other.gameObject, layerMask))
        {
            goalEvent.Invoke();
        }
    }
    public int GetTeamIDFromGoal()
    {
        return teamID;
    }
}
