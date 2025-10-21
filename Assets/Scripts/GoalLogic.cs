using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GoalLogic : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent goalEvent;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (IsInLayerMask(other.gameObject, layerMask))
        {
            goalEvent.Invoke();
        }   
    }

    public static bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return (mask == (mask | (1 << obj.layer)));
    }
    


}
