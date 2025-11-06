using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SFXOnCollision : MonoBehaviour
{

    public UnityEvent SFXEventObjectLayer = new();
    public UnityEvent SFXEventObject = new();
    public String layerMaskForColl;
    public void StopPuck()
    {
        Rigidbody rigForPuck = gameObject.GetComponent<Rigidbody>();
        rigForPuck.velocity = Vector3.zero;
        rigForPuck.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerMaskForColl))
        {
            SFXEventObjectLayer.Invoke();
        }
        else
        {
            SFXEventObject.Invoke();
        }
        
    }
}
