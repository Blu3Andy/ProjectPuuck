using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent onHitEvent;


    private void OnCollisionEnter(Collision collision)
    {
        if (Helper.IsInLayerMask(collision.gameObject, layerMask))
        {
            onHitEvent.Invoke();
        }
    }
}
